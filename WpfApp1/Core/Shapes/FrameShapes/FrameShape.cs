using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Shapes.FrameShapes
{
    public abstract class FrameShape: Shape 
    {

        public FrameShape(Canvas canvas, int x, int y, int width, int height):base(canvas,x,y,width,height)
        {
            
        }
        public FrameShape(Canvas canvas, int x, int y, int width) : base(canvas, x, y, width)
        {
            isPointShape = false;
        }
    }
}
