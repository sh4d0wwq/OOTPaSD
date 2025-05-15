using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using WpfApp1.Core.Shapes.FrameShapes;
using WpfApp1.Core;
using WpfApp1.Core.Serialization;

namespace TrapezoidPlugin
{
    public class TrapezoidShape : FrameShape
    {
        public TrapezoidShape(Canvas canvas, int x1, int y1, int x2, int y2)
            : base(canvas, x1, y1, x2, y2)
        {
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }

            if (y1 > y2)
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

        public TrapezoidShape(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {
        }

        private PointCollection CreateTrapezoidPoints(double x, double y, double width, double height)
        {
            double offset = width * 0.2;

            return new PointCollection
            {
                new Point(x + offset, y),
                new Point(x + width - offset, y),
                new Point(x + width, y + height),
                new Point(x, y + height)
            };
        }

        public override UIElement draw()
        {
            var polygon = new Polygon
            {
                Points = CreateTrapezoidPoints(x, y, width, height)
            };

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

        public static WpfApp1.Core.Shapes.Shape FromDto(Canvas canvas, ShapeDto dto)
        {
            var settings = new ShapeSettings
            {
                borderColor = BrushConverterHelper.StringToBrush(dto.Settings.BorderColor),
                fillColor = BrushConverterHelper.StringToBrush(dto.Settings.FillColor),
                lineWidth = dto.Settings.LineWidth
            };

            var shape = new TrapezoidShape(canvas, dto.X, dto.Y, dto.X + dto.Width, dto.Y + dto.Height)
            {
                settings = settings
            };

            return shape;
        }
    }
}
