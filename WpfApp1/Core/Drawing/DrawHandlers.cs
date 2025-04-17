using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Core.Shapes.PointShapes;

namespace WpfApp1.Core.Drawing
{
    public class DrawHandlers
    {
        private Canvas _mainCanvas;
        private Type[] _shapeTypeList;
        private int _curShape;
        private double[] _allStrokeWidths;
        private int _curWidth;
        private Brush _borderColor;
        private Brush _fillColor;

        public DrawHandlers(Canvas mainCanvas, Type[] shapeTypeList, double[] allStrokeWidths)
        {
            _mainCanvas = mainCanvas;
            _shapeTypeList = shapeTypeList;
            _allStrokeWidths = allStrokeWidths;
            _curShape = -1; 
            _curWidth = 0; 
            _borderColor = Brushes.Black;
            _fillColor = Brushes.Transparent; 
        }

        public void SetShape(int shapeIndex)
        {
            _curShape = shapeIndex;
        }

        public void SetBorderColor(Brush color)
        {
            _borderColor = color;
        }

        public void SetFillColor(Brush color)
        {
            _fillColor = color;
        }

        public void SetLineWidth(int widthIndex)
        {
            _curWidth = widthIndex;
        }

        public void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_curShape < 0) return;

            int x = (int)e.GetPosition(_mainCanvas).X;
            int y = (int)e.GetPosition(_mainCanvas).Y;

            ShapeSettings s = new ShapeSettings
            {
                mouseUp = new MouseButtonEventHandler(CanvasMouseUp),
                borderColor = _borderColor,
                fillColor = _fillColor,
                lineWidth = _allStrokeWidths[_curWidth],
                isLast = false
            };

            if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
            {
                if (e.ClickCount == 2)
                {
                    Draw.finishCurrentPoly();
                }
                else
                {
                    ConstructorInfo constructor = _shapeTypeList[_curShape]
                        .GetConstructors().FirstOrDefault(c => c.GetParameters().Length == 2);
                    if (constructor != null)
                        Draw.onPolyMouseDown(e);
                }
            }
            else
            {
                Draw.onMouseDown(e);
            }
        }

        public void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_curShape >= 0)
            {
                ShapeSettings s = new ShapeSettings();
                int x = (int)e.GetPosition(_mainCanvas).X;
                int y = (int)e.GetPosition(_mainCanvas).Y;
                s.mouseUp = new MouseButtonEventHandler(CanvasMouseUp);
                s.borderColor = _borderColor;
                s.fillColor = _fillColor;
                s.lineWidth = _allStrokeWidths[_curWidth];

                if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
                {
                    s.isLast = false;
                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 3).First();
                    Draw.onPolyMouseUp(x, y, constructor, s);
                }
                else
                {
                    s.isLast = false;

                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 5).First();
                    Draw.onMouseUp(x, y, constructor, s);
                }
            }
        }

        public void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (_curShape >= 0)
            {
                ShapeSettings s = new ShapeSettings();
                int x = (int)e.GetPosition(_mainCanvas).X;
                int y = (int)e.GetPosition(_mainCanvas).Y;
                s.mouseUp = new MouseButtonEventHandler(CanvasMouseUp);
                s.borderColor = _borderColor;
                s.fillColor = _fillColor;
                s.lineWidth = _allStrokeWidths[_curWidth];

                if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
                {
                    s.isLast = false;
                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 3).First();
                    Draw.onPolyMouseMove(x, y, constructor, s);
                }
                else
                {
                    s.isLast = false;
                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 5).First();
                    Draw.onMouseMove(x, y, constructor, s);
                }
            }
        }
    }
}
