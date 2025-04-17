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
        
        override protected void init(System.Windows.Shapes.Shape s)
        {
            brush = settings.fillColor;
            Pen.Brush = settings.borderColor;
            pen.Thickness = settings.lineWidth;

            s.Stroke = pen.Brush;
            s.StrokeDashArray = pen.DashStyle.Dashes;
            s.StrokeThickness = pen.Thickness;
            s.StrokeDashCap = pen.DashCap;

            if (!settings.isLast)
            {
                s.MouseUp += settings.mouseUp;
            }
        }

        public override void finalize()
        {
            draw();
        }
    }
}
