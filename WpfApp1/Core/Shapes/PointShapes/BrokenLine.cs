﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Shapes.PointShapeFiles
{
    class BrokenLine : PointShape
    {
        public static int id = 5;
        

        public BrokenLine(Canvas canvas, int x, int y, int width)
            : base(canvas, x, y, width)
        {
            pointCollection.RemoveAt(num - 1);
            num--;


        }

        public BrokenLine(Canvas canvas, int x, int y)
            : base(canvas, x, y, 0)
        {
            pointCollection = new PointCollection();
            pointCollection.Add(new System.Windows.Point(x, y));
            num++;
        }



        override public System.Windows.UIElement draw()
        {

            Polyline tr = new Polyline();

            tr.Points = pointCollection;
            brush = new SolidColorBrush(new Color
            {
                A = 0,
                R = 0x27,
                G = 0x27,
                B = 0x27
            });
            init(tr);

            canvas.Children.Add(tr);

            return tr;

        }

        public override Shape copy()
        {
            BrokenLine clone = new BrokenLine(canvas, x, y);

            for (int i = 1; i<pointCollection.Count; i++)
            {
                clone.AddPoint((int)pointCollection[i].X, (int)pointCollection[i].Y);
            }

            clone.pen = pen.Clone();
            clone.brush = brush.Clone();

            return clone;
        }

        public override void finalize()
        {
            draw();
        }
    }
}
