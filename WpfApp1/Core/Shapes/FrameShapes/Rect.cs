﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Shapes.FrameShapes
{
    public class MyRect : FrameShape
    {

        public static int id = 0;

        public MyRect(Canvas canvas, int x1, int y1, int x2, int y2)
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
        public MyRect(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {

        }
        override public UIElement draw()
        {
            Rectangle tr = new Rectangle();
            tr.Width = width;
            tr.Height = height;

            init(tr);
            tr.IsHitTestVisible = false;
            canvas.Children.Add(tr);
            Canvas.SetLeft(tr, x);
            Canvas.SetTop(tr, y);

            return tr;

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
           
            MyRect result = new MyRect(canvas, dto.X, dto.Y, dto.Width, dto.Height);
            result.settings = settings;
            return result;
        }

    }

}

    

