using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Core.Serialization;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Shapes.FrameShapes
{
    public class MyLine : FrameShape
    {
        public static int id = 1;
        
        public MyLine(Canvas canvas, int x1, int y1, int x2, int y2)
            : base(canvas, x1, y1, x2, y2)
        {
            
        }
        public MyLine(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {

        }

        public override UIElement draw()
        {

            Line tr = new Line();
            tr.X1 = x;
            tr.Y1 = y;
            tr.X2 = width;
            tr.Y2 = height;
            tr.IsHitTestVisible = false;
            init(tr);

            canvas.Children.Add(tr);

            return tr;
            
        }
        public override ShapeDto ToDto()
        {
            return new ShapeDto
            {
                Type = GetType().Name,
                X = x,
                Y = y,
                Width = width,
                Height = height,
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

            return new MyLine(canvas, dto.X, dto.Y, dto.Width, dto.Height)
            {
                settings = settings
            };
        }
    }
}
