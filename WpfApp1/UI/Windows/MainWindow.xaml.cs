using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static WpfApp1.Core.Drawing.Draw;
using System.Reflection;
using WpfApp1.Core.Drawing;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using WpfApp1.UI;
using WpfApp1.Core;
using WpfApp1.Core.Serialization;
using WpfApp1.Core.Shapes;

namespace WpfApp1;

public partial class MainWindow : Window
{
    private DrawHandlers _drawingLogic;
    private ToggleButton[] shapeButtons;
    private ToggleButton[] widthButtons;

    private bool isUpdatingFromSlider = false;

    private int curShape = -1;
    private int curWidth = 0;

    private double[] allStrokeWidths = { 1, 1.5, 2, 3, 5};
    
    private List<Type> shapeTypeList;

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

        widthButtons = new ToggleButton[allStrokeWidths.Length];
        FillUIElements.setDropdownPopup(DropdownPopup,allStrokeWidths, widthButtons, new RoutedEventHandler(widthButtonClick), curWidth);

        Type ourtype = typeof(WpfApp1.Core.Shapes.Shape);
        shapeTypeList = ClassLoader.LoadShapeTypes(ourtype);

        shapeButtons = new ToggleButton[shapeTypeList.Count];

        FillUIElements.setShapeButtons(shapeButtonList,shapeTypeList,shapeButtons, new RoutedEventHandler(ShapeButtonClick));
        chosenEllipse = borderEllipse;
        chosenEllipse.Stroke = Brushes.LightSteelBlue;
        chosenEllipse.StrokeThickness = 2;
        fillEllipse.StrokeThickness = 0;
    }

    private void SetSlidersFromColor(Color color)
    {
        SliderR.Value = color.R;
        SliderG.Value = color.G;
        SliderB.Value = color.B;
    }
    private void CanvasLeftMouseDown(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.CanvasLeftMouseDown(sender, e);
    }

    private void CanvasRightMouseDown(object sender, MouseButtonEventArgs e)
    {
        _drawingLogic.CanvasRightMouseDown(sender, e);
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
        for (int i = 0; i < shapeTypeList.Count; i++)
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

    private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (isUpdatingFromSlider) return;

        byte r = (byte)SliderR.Value;
        byte g = (byte)SliderG.Value;
        byte b = (byte)SliderB.Value;

        var brush = new SolidColorBrush(Color.FromRgb(r, g, b));

        chosenEllipse.Fill = brush;
        _drawingLogic.SetBorderColor(borderEllipse.Fill);
        _drawingLogic.SetFillColor(fillEllipse.Fill);

        isUpdatingFromSlider = true;
        string hex = $"#{r:X2}{g:X2}{b:X2}";
        isUpdatingFromSlider = false;
        HexColorDisplay.Text = hex;
    }

    private void chooseFill(object sender, MouseButtonEventArgs e)
    {
        chosenEllipse = fillEllipse;
        chosenEllipse.Stroke = Brushes.LightSteelBlue;
        chosenEllipse.StrokeThickness = 2;
        borderEllipse.StrokeThickness = 0;
        SetSlidersFromColor(((SolidColorBrush)fillEllipse.Fill).Color);
    }

    private void chooseBorder(object sender, MouseButtonEventArgs e)
    {
        chosenEllipse = borderEllipse;
        chosenEllipse.Stroke = Brushes.LightSteelBlue;
        chosenEllipse.StrokeThickness = 2;
        fillEllipse.StrokeThickness = 0;
        SetSlidersFromColor(((SolidColorBrush)borderEllipse.Fill).Color);
    }

    private void LoadedCanvas(object sender, RoutedEventArgs e)
    {
        Draw.mainCanvas = (Canvas)sender;
        Draw.drawManager = new DrawManager(0, Draw.mainCanvas);
        _drawingLogic = new DrawHandlers(mainCanvas, shapeTypeList, allStrokeWidths);
    }

    

    private void UndoCommandBinding_Executed(object sender, RoutedEventArgs e)
    {
        _drawingLogic.Undo();
    }

    private void OpenCommandBinding_Executed(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
        openFileDialog.DefaultExt = ".json";
        openFileDialog.AddExtension = true;

        if (openFileDialog.ShowDialog() == true)
        {
            string filePath = openFileDialog.FileName;

            Draw.drawManager.Clear();
            Draw.drawManager.shapeList = ShapeSerializer.LoadShapes(filePath, Draw.mainCanvas);
            
            Draw.drawManager.DrawAll();
        }
    }

    private void SaveCommandBinding_Executed(object sender, RoutedEventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
        saveFileDialog.DefaultExt = ".json";
        saveFileDialog.AddExtension = true;

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;
            ShapeSerializer.SaveShapes(Draw.drawManager.shapeList, filePath);
        }
    }

    private void RedoCommandBinding_Executed(object sender, RoutedEventArgs e)
    {
        _drawingLogic.Redo();
    }

    private void NewFileCommandBinding_Executed(object sender, RoutedEventArgs e)
    {
        Draw.drawManager.Clear();
    }

    private void HexColorDisplay_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (isUpdatingFromSlider) return;

        string hex = HexColorDisplay.Text;

        if (!Regex.IsMatch(hex, @"^#([0-9A-Fa-f]{6})$")) return;

        try
        {
            byte r = Convert.ToByte(hex.Substring(1, 2), 16);
            byte g = Convert.ToByte(hex.Substring(3, 2), 16);
            byte b = Convert.ToByte(hex.Substring(5, 2), 16);

            isUpdatingFromSlider = true;
            SliderR.Value = r;
            SliderG.Value = g;
            SliderB.Value = b;
            isUpdatingFromSlider = false;

            Color color = Color.FromRgb(r, g, b);
            SolidColorBrush brush = new SolidColorBrush(color);

            chosenEllipse.Fill = brush;
        }
        catch
        {
        }
    }

    private void LoadPluginFromFile(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "DLL files (*.dll)|*.dll",
            Title = "Выберите файл плагина"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            string dllPath = openFileDialog.FileName;

            try
            {
                var asm = Assembly.LoadFrom(dllPath);
                ShapeRegistry.RegisterAssembly(asm);

                var newTypes = asm.GetTypes()
                    .Where(t => typeof(WpfApp1.Core.Shapes.Shape).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                    .ToList();

                foreach (var type in newTypes)
                {
                    if (!shapeTypeList.Contains(type))
                    {
                        shapeTypeList.Add(type);
                    }
                }
                shapeButtons = new ToggleButton[shapeTypeList.Count];
                FillUIElements.setShapeButtons(shapeButtonList, shapeTypeList, shapeButtons, new RoutedEventHandler(ShapeButtonClick));

                MessageBox.Show("Плагин загружен.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки плагина: " + ex.Message);
            }
        }
    }

}


