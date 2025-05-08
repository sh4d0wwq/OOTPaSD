using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using WpfApp1.Core;
using WpfApp1.Core.Shapes;
using WpfApp1.Core.Shapes.PointShapes;
using System.Reflection;

public class PointDto
{
    public double X { get; set; }
    public double Y { get; set; }
    public PointDto() { }

    public PointDto(Point p)
    {
        X = p.X;
        Y = p.Y;
    }

    public Point ToPoint() => new Point(X, Y);
}

public class ShapeDto
{
    public string Type { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public List<PointDto> Points { get; set; }
    public ShapeSettingsDto Settings { get; set; }
}

public class ShapeSettingsDto
{ 
    public string BorderColor { get; set; }
    public string FillColor { get; set; }
    public double LineWidth { get; set; }
}

public static class BrushConverterHelper
{
    private static readonly BrushConverter converter = new BrushConverter();

    public static string BrushToString(Brush brush) =>
        brush is SolidColorBrush solid ? solid.Color.ToString() : "#000000";

    public static Brush StringToBrush(string str) =>
        (Brush)converter.ConvertFromString(str);
}

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

