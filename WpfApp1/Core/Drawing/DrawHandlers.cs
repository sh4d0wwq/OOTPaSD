using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Core.Shapes.FrameShapes;
using WpfApp1.Core.Shapes.PointShapes;

namespace WpfApp1.Core.Drawing
{
    public class DrawHandlers
    {
        private Canvas _mainCanvas;
        private List<Type> _shapeTypeList;
        private int _curShape;
        private double[] _allStrokeWidths;
        private int _curWidth;
        private Brush _borderColor;
        private Brush _fillColor;

        public DrawHandlers(Canvas mainCanvas, List<Type> shapeTypeList, double[] allStrokeWidths)
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

        public void CanvasLeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_curShape < 0) return;

            int x = (int)e.GetPosition(_mainCanvas).X;
            int y = (int)e.GetPosition(_mainCanvas).Y;

            ShapeSettings s = new ShapeSettings
            {
                borderColor = _borderColor,
                fillColor = _fillColor,
                lineWidth = _allStrokeWidths[_curWidth],
            };

            if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
            {
                ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 3).First();
                Draw.onPolyMouseDown(e, constructor, s);
            }
            else
            {
                ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 5).First();
                Draw.onMouseDown(e, constructor, s);
            }
        }
        public void CanvasRightMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_curShape < 0) return;

            if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
            {
                Draw.finishCurrentPoly();
            }
        }

        public void CanvasMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_curShape >= 0)
            {
                ShapeSettings s = new ShapeSettings();
                int x = (int)e.GetPosition(_mainCanvas).X;
                int y = (int)e.GetPosition(_mainCanvas).Y;
                s.borderColor = _borderColor;
                s.fillColor = _fillColor;
                s.lineWidth = _allStrokeWidths[_curWidth];

                if (_shapeTypeList[_curShape].IsSubclassOf(typeof(FrameShape)))
                {

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
                s.borderColor = _borderColor;
                s.fillColor = _fillColor;
                s.lineWidth = _allStrokeWidths[_curWidth];

                if (_shapeTypeList[_curShape].IsSubclassOf(typeof(PointShape)))
                {
                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 3).First();
                    Draw.onPolyMouseMove(x, y, constructor, s);
                }
                else
                {
                    ConstructorInfo constructor = _shapeTypeList[_curShape].GetConstructors().Where(_ => _.GetParameters().Length == 5).First();
                    Draw.onMouseMove(x, y, constructor, s);
                }
            }
        }

        public void Undo()
        {
            Draw.Undo();
        }

        public void Redo()
        {
            Draw.Redo();
        }
    }

    
}
