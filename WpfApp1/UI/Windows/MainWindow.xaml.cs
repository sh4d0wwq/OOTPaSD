using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static WpfApp1.Core.Drawing.Draw;
using System.Reflection;
using WpfApp1.Core.Drawing;

namespace WpfApp1;
using UI;
using WpfApp1.Core;
using WpfApp1.Core.Shapes;
using WpfApp1.Core.Shapes.PointShapes;

public partial class MainWindow : Window
{
    private DrawHandlers _drawingLogic;
    private ToggleButton[] shapeButtons;
    private ToggleButton[] widthButtons;

    private int curShape = -1;
    private int curWidth = 0;

    private double[] allStrokeWidths = { 1, 1.5, 2, 3, 5};
    
    private Color[] allColors = { Colors.Red, Colors.LightGray, Colors.Green, Colors.LightGray, Colors.LightGreen, Colors.DarkGray, Colors.LightBlue, Colors.LavenderBlush, Colors.LightCoral, Colors.White, Colors.Black };
    
    private Type[] shapeTypeList;

    Ellipse chosenEllipse;

    bool widthPopUpVisible = false;
    
    public void widthListButtonMouthDown(object sender, RoutedEventArgs e)
    {
        widthPopUpVisible = !widthPopUpVisible;
        DropdownPopup.IsOpen = widthPopUpVisible;
    }

    public static int compareTypes(Type a, Type b)
    {
        int i1 = (int)a.GetField("id", BindingFlags.Static | BindingFlags.Public).GetValue(null);
        int i2 = (int)b.GetField("id", BindingFlags.Static | BindingFlags.Public).GetValue(null);

        return i1.CompareTo(i2);
    }

    public MainWindow()
    {
        InitializeComponent();

        FillUIElements.setColorList(colorList,allColors, new MouseButtonEventHandler(colorMouseDown));

        widthButtons = new ToggleButton[allStrokeWidths.Length];
        FillUIElements.setDropdownPopup(DropdownPopup,allStrokeWidths, widthButtons, new RoutedEventHandler(widthButtonClick), curWidth);

        Type ourtype = typeof(Shape);
        shapeTypeList = ClassLoader.LoadShapeTypes(ourtype);

        shapeButtons = new ToggleButton[shapeTypeList.Length];

        FillUIElements.setShapeButtons(shapeButtonList,shapeTypeList,shapeButtons, new RoutedEventHandler(ShapeButtonClick));
        chosenEllipse = borderEllipse;
        chosenEllipse.Stroke = Brushes.LightSteelBlue;
        chosenEllipse.StrokeThickness = 2;
        fillEllipse.StrokeThickness = 0;
    }

    private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.CanvasMouseDown(sender, e);
    }

    private void CanvasMouseUp(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.CanvasMouseUp(sender, e);
    }

    private void CanvasMouseMove(object sender, MouseEventArgs e)
    {
        _drawingLogic.CanvasMouseMove(sender, e);
    }

    private void ShapeButtonClick(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < shapeTypeList.Length; i++)
        {
            if (shapeButtons[i] == (ToggleButton)sender)
            {
                curShape = i;
                _drawingLogic.SetShape(i);
                shapeButtons[i].IsChecked = true;
            }
            else
            {
                shapeButtons[i].IsChecked = false;
            }
        }
    }

    private void widthButtonClick(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < allStrokeWidths.Length; i++)
        {
            if (widthButtons[i] == (ToggleButton)sender)
            {
                curWidth = i;
                _drawingLogic.SetLineWidth(i);
                widthButtons[i].IsChecked = true;
            }
            else
            {
                widthButtons[i].IsChecked = false;
            }
        }
    }

    private void colorMouseDown(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.SetBorderColor(((Ellipse)sender).Fill);
    }

    private void chooseFill(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.SetFillColor(((Ellipse)sender).Fill); 
    }

    private void LoadedCanvas(object sender, RoutedEventArgs e)
    {
        Draw.mainCanvas = (Canvas)sender;
        Draw.drawManager = new DrawManager(0, Draw.mainCanvas);
        _drawingLogic = new DrawHandlers(mainCanvas, shapeTypeList, allStrokeWidths);
    }

    private void chooseBorder(object sender, MouseButtonEventArgs e)
    {
        chosenEllipse = borderEllipse;
        chosenEllipse.Stroke = Brushes.LightSteelBlue;
        chosenEllipse.StrokeThickness = 2;
        fillEllipse.StrokeThickness = 0;
    }


}
