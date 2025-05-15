using System.Windows.Controls;
using WpfApp1.Core.Shapes;

namespace WpfApp1.Core.Drawing
{

    public class DrawManager
    {
        
        public List<Shape> shapeList = new List<Shape>();
        private Canvas canvas;
        private Stack<Shape> undoStack = new Stack<Shape>();
        public int drawCount = 0;

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

        public void Draw()
        {
            shapeList[^1].draw();
        }
        public void DrawAll()
        {
            foreach (var shape in shapeList)
            {
                shape.draw();
            }
        }
        public void reDraw()
        {
            if (canvas.Children.Count > 0)
            {
                canvas.Children.RemoveAt(canvas.Children.Count - 1);
            }
            shapeList[^1].draw();
        }
        public int size()
        {
            return shapeList.Count();
        }

        public void add(Shape s)
        {
            shapeList.Add(s);
            undoStack.Clear();
        }

        public void removeLast()
        {
            shapeList.RemoveAt(size() - 1);
        }

        public Shape last()
        {
            return shapeList.Last();
        }

        public void Undo()
        {
            if (drawCount > 0)
            {
                var shape = shapeList[^1];
                shapeList.RemoveAt(shapeList.Count - 1);
                undoStack.Push(shape);
                canvas.Children.RemoveAt(canvas.Children.Count - 1);
                drawCount--;
            }
        }

        public void Redo()
        {
            if (undoStack.Count > 0)
            {
                var shape = undoStack.Pop();
                shapeList.Add(shape);
                shapeList[^1].draw();
                drawCount++;
            }
        }

        public void Clear()
        {
            canvas.Children.Clear();
            shapeList.Clear();
            undoStack.Clear();
            drawCount = 0;
        }
    }
}
