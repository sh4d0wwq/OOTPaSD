using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Shapes.PointShapes
{
    class Polygon: PointShape
    {

        public static int id = 4;

        public Polygon(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {
            isPointShape = true;
           
        }

        public Polygon(Canvas canvas, int x, int y)
            : base(canvas, x, y, 0)
        {
            pointCollection = new PointCollection();
            pointCollection.Add(new System.Windows.Point(x , y));
            num++;
            isPointShape = true;

        }

        override public System.Windows.UIElement draw()
        {

            System.Windows.Shapes.Polygon tr = new System.Windows.Shapes.Polygon();

            tr.Points = pointCollection;
            tr.IsHitTestVisible = false;
            init(tr);

            canvas.Children.Add(tr);

            return tr;

        }

        public override void finalize()
        {
            draw();
        }

        public override ShapeDto ToDto()
        {
            return new ShapeDto
            {
                Type = GetType().Name,
                X = X,
                Y = Y,
                Width = Width,
                Points = pointCollection.Select(p => new PointDto(p)).ToList(),
                Settings = new ShapeSettingsDto
                {
                    BorderColor = BrushConverterHelper.BrushToString(settings.borderColor),
                    FillColor = BrushConverterHelper.BrushToString(settings.fillColor),
                    LineWidth = settings.lineWidth
                }
            };
        }

        public static Shape FromDto(Canvas canvas, ShapeDto dto)
        {
            var polygonDto = dto as ShapeDto;

            if (polygonDto == null)
                throw new ArgumentException("Invalid DTO for Polygon");

            var settings = new ShapeSettings
            {
                borderColor = BrushConverterHelper.StringToBrush(polygonDto.Settings.BorderColor),
                fillColor = BrushConverterHelper.StringToBrush(polygonDto.Settings.FillColor),
                lineWidth = polygonDto.Settings.LineWidth
            };

            Polygon result = new Polygon(canvas, polygonDto.X, polygonDto.Y);
            result.settings = settings;
            result.pointCollection = new PointCollection(polygonDto.Points.Select(p => p.ToPoint()));

            return result;
        }
    }
}
