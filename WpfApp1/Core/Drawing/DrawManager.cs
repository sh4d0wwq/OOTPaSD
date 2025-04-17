using System.Windows.Controls;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Drawing
{

    public class DrawManager
    {

        private List<Shape> shapeList = new List<Shape>();
        private Canvas canvas;

        public Shape? this[int index]
        {
            get {
                if (shapeList.Count <= index)
                {
                    return null;
                } else
                {
                    return shapeList[index];
                }
            }
            set
            {
                if (shapeList.Count > index)
                {
                    shapeList[index] = value;
                }
            }
        }

        public DrawManager(int n, Canvas canvas)
        {
            shapeList = new List<Shape>(n);
            this.canvas = canvas;
        }


        public void reDraw()
        {
            canvas.Children.Clear();
            for (int i = 0; i<size(); i++)
            {
                shapeList[i].draw();
            }
        }
        public int size()
        {
            return shapeList.Count();
        }


        public void add(Shape s)
        {
            shapeList.Add(s);
        }

        public void removeLast()
        {
            shapeList.RemoveAt(size() - 1);
        }

        public Shape last()
        {
            return shapeList.Last();
        }
    }
}
