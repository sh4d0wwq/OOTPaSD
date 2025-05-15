using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp1.Core.Shapes;
using System.IO;
using System.Windows.Controls;

namespace WpfApp1.Core.Serialization
{
    public static class ShapeSerializer
    {
        public static void SaveShapes(List<Shape> shapes, string path)
        {
            var dtos = shapes.Select(s => s.ToDto()).ToList();
            string json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            });
            File.WriteAllText(path, json);
        }

        public static List<Shape> LoadShapes(string path, Canvas canvas)
        {
            string json = File.ReadAllText(path);
            var doc = JsonDocument.Parse(json);
            var shapes = new List<Shape>();

            foreach (var element in doc.RootElement.EnumerateArray())
            {
                string typeName = element.GetProperty("Type").GetString();
                var shapeDto = JsonSerializer.Deserialize<ShapeDto>(element.GetRawText());

                Type shapeType = ShapeRegistry.GetShapeType(typeName);

                if (shapeType == null) continue;

                var fromDtoMethod = shapeType.GetMethod("FromDto", BindingFlags.Public | BindingFlags.Static);

                if (fromDtoMethod == null) continue;

                var shape = fromDtoMethod.Invoke(null, new object[] { canvas, shapeDto }) as Shape;

                if (shape != null)
                {
                    if (shapeDto.Settings != null)
                    {
                        shape.settings = new ShapeSettings
                        {
                            borderColor = BrushConverterHelper.StringToBrush(shapeDto.Settings.BorderColor),
                            fillColor = BrushConverterHelper.StringToBrush(shapeDto.Settings.FillColor),
                            lineWidth = shapeDto.Settings.LineWidth
                        };
                    }

                    shapes.Add(shape);
                }
            }

            return shapes;
        }
    }
}
