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
            init(tr);

            canvas.Children.Add(tr);

            return tr;

        }

        public override void finalize()
        {
            draw();
        }
    }
}
