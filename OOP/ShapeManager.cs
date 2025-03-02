using OOTPaSD.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPaSD
{
    class ShapeManager
    {
        private List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }
        public void DrawAll(Graphics g)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }
    }
}
