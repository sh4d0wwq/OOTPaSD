using WpfApp1.Core.Serialization;
using WpfApp1.Core.Shapes.FrameShapes;
using WpfApp1.Core;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Core.Shapes;
using System.Windows.Media;

namespace Plugin
{
    public class StarShape: FrameShape
    {
        public StarShape(Canvas canvas, int x1, int y1, int x2, int y2)
            : base(canvas, x1, y1, x2, y2)
        {
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }

            if (y1 >= y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
            }

            x = x1;
            y = y1;
            width = Math.Abs(x2 - x1);
            height = Math.Abs(y2 - y1);
        }
        public StarShape(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {

        }
        private PointCollection CreateStarPoints(double x, double y, double width, double height, int numPoints, double innerRadiusRatio)
        {
            PointCollection points = new PointCollection();
            double centerX = x + width / 2;
            double centerY = y + height / 2;
            double outerRadius = Math.Min(width, height) / 2;
            double innerRadius = outerRadius * innerRadiusRatio;

            double angleStep = Math.PI / numPoints;

            for (int i = 0; i < numPoints * 2; i++)
            {
                double angle = i * angleStep - Math.PI / 2;
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                double px = centerX + radius * Math.Cos(angle);
                double py = centerY + radius * Math.Sin(angle);
                points.Add(new Point(px, py));
            }

            return points;
        }

        public override UIElement draw()
        {
            var polygon = new System.Windows.Shapes.Polygon();
            polygon.Points = CreateStarPoints(x, y, width, height, 5, 0.5);
            init(polygon);
            polygon.IsHitTestVisible = false;
            canvas.Children.Add(polygon);

            return polygon;

        }

        public override ShapeDto ToDto()
        {
            return new ShapeDto
            {
                Type = GetType().Name,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
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
            var settings = new ShapeSettings
            {
                borderColor = BrushConverterHelper.StringToBrush(dto.Settings.BorderColor),
                fillColor = BrushConverterHelper.StringToBrush(dto.Settings.FillColor),
                lineWidth = dto.Settings.LineWidth
            };

            StarShape result = new StarShape(canvas, dto.X, dto.Y, dto.X + dto.Width, dto.Y + dto.Height);
            result.settings = settings;
            return result;
        }
    }

}
