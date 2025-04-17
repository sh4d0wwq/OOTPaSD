using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Core.Shapes.PointShapes;


namespace WpfApp1.Core.Drawing
{
    
    public static class Draw
    {
        public static WpfApp1.Core.Shapes.Shape curShape = null;

        public static PointShape? currentPoly = null;
        public static Canvas mainCanvas = null;

        private static int xStart;
        private static int yStart;
        private static bool onDrawing = false;

        public static DrawManager drawManager = null;


        public static void onMouseDown(MouseButtonEventArgs e)
        {
            if (!onDrawing)
            {
                xStart = (int)e.GetPosition(mainCanvas).X;
                yStart = (int)e.GetPosition(mainCanvas).Y;
                onDrawing = true;
            }
        }

        public static void onMouseMove(int xFinish, int yFinish, ConstructorInfo constructor, ShapeSettings s)
        {
            if (onDrawing) {
                                
                if (curShape != null)
                {
                    drawManager.removeLast();
                }

                setShape(xFinish, yFinish, constructor, s);
            }

        }


        private static void setShape(int xFinish, int yFinish, ConstructorInfo constructor, ShapeSettings s)
        {
            WpfApp1.Core.Shapes.Shape temp = (WpfApp1.Core.Shapes.Shape)constructor.Invoke(new object[] { mainCanvas, xStart, yStart, xFinish, yFinish });

            temp.settings = s;


            drawManager.add(temp);
            drawManager.reDraw();

            curShape = temp;

        }
        public static void onMouseUp(int xFinish, int yFinish, ConstructorInfo constructor, ShapeSettings s)
        {
            if (onDrawing)
            {
                onMouseMove(xFinish, yFinish, constructor, s);
            }
            onDrawing = false;
            curShape = null;
        }


        public static void onPolyMouseDown(MouseButtonEventArgs e)
        {
            if (!onDrawing)
            {
                xStart = (int)e.GetPosition(mainCanvas).X;
                yStart = (int)e.GetPosition(mainCanvas).Y;
                onDrawing = true;
            }
        }

        public static void onPolyMouseMove(int xFinish, int yFinish, ConstructorInfo constructor, ShapeSettings s)
        {
            if (curShape != null)
            {
                if (((PointShape)curShape).pointCollection.Count > 1)
                {
                    ((PointShape)curShape).RemoveLastPoint();
                }

                ((PointShape)curShape).AddPoint(xFinish, yFinish);

                drawManager.reDraw();
            }

        }

        public static void onPolyMouseUp(int xFinish, int yFinish, ConstructorInfo constructor, ShapeSettings s)
        {
            bool isEnd = false;
            if (curShape != null)
            {
                isEnd = ((PointShape)curShape).AddPoint(xFinish, yFinish);
                drawManager.reDraw();
            }
            else
            {
                curShape = (PointShape)constructor.Invoke(new object[] { mainCanvas, xFinish, yFinish });
                drawManager.add(curShape);
            }
            curShape.settings = s;
            drawManager.reDraw();

            if (isEnd)
            {
                s.isLast = true;
                ((PointShape)curShape).RemoveLastPoint();
                drawManager.reDraw();
                
                curShape = null;

            }
        
        }
        public static void finishCurrentPoly()
        {
            if (currentPoly != null)
            {
                currentPoly.finalize();
                currentPoly = null;
            }
        }
    }

}

