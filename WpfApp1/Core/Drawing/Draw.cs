using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Maui.Layouts;
using WpfApp1.Core.Shapes.PointShapes;


namespace WpfApp1.Core.Drawing
{
    
    public static class Draw
    {
        public static WpfApp1.Core.Shapes.Shape curShape = null;

        public static Canvas mainCanvas = null;

        private static int xStart;
        private static int yStart;
        private static bool onDrawing = false;

        public static DrawManager drawManager = null;

        public static void onMouseDown(MouseButtonEventArgs e, ConstructorInfo constructor, ShapeSettings s)
        {
            if (!onDrawing)
            {
                xStart = (int)e.GetPosition(mainCanvas).X;
                yStart = (int)e.GetPosition(mainCanvas).Y;
                onDrawing = true;

                WpfApp1.Core.Shapes.Shape temp = (WpfApp1.Core.Shapes.Shape)constructor.Invoke(new object[] { mainCanvas, xStart, yStart, xStart, yStart });

                temp.settings = s;


                drawManager.add(temp);
                drawManager.Draw();

                curShape = temp;
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
            drawManager.drawCount++;
        }
        public static void onPolyMouseDown(MouseButtonEventArgs e, ConstructorInfo constructor, ShapeSettings s)
        {
            if (!onDrawing)
            {
                xStart = (int)e.GetPosition(mainCanvas).X;
                yStart = (int)e.GetPosition(mainCanvas).Y;
                onDrawing = true;
                curShape = (PointShape)constructor.Invoke(new object[] { mainCanvas, xStart, yStart });
                drawManager.add(curShape);
                curShape.draw();
                curShape.settings = s;
            }
            else
            {
                int xFinish = (int)e.GetPosition(mainCanvas).X;
                int yFinish = (int)e.GetPosition(mainCanvas).Y;

                ((PointShape)curShape).AddPoint(xFinish, yFinish);
                curShape.settings = s;
                drawManager.reDraw();

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

        public static void finishCurrentPoly()
        {
            curShape = null;
            onDrawing = false;
            drawManager.drawCount++;
        }

        public static void Undo()
        {
            drawManager.Undo();
        }
        public static void Redo()
        {
            drawManager.Redo();
        }
    }

}

