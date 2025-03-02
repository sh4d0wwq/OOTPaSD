using OOTPaSD.Shapes;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace OOTPaSD
{
    
    public partial class MainWindow: Form
    {
        private ShapeManager shapeManager = new ShapeManager();
        private enum ShapeENum { Line, BrokenLine, Rectangle, Ellipse, Polygon}
        private ShapeENum selectedShape = ShapeENum.Line;
        private Button selectedButton = null;
        private Point startPoint;

        public Color penColor = Color.Black;
        public Color brushColor = Color.Black;
        public int penWidth = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectShape(ShapeENum shape, Button button)
        {
            selectedShape = shape;

            if (selectedButton != null)
                selectedButton.BackColor = SystemColors.Control;

            selectedButton = button;
            selectedButton.BackColor = Color.LightGray;
        }

        private void btnBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                brushColor = colorDialog.Color;
            }
        }

        private void btnPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
            }
        }

        private void penWidthNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            penWidth = (int)penWidthNumUpDown.Value;
        }

        private void btnLine_Click(object sender, EventArgs e) => SelectShape(ShapeENum.Line, (Button)sender);

        private void btnBrLine_Click(object sender, EventArgs e) => SelectShape(ShapeENum.BrokenLine, (Button)sender);

        private void btnRect_Click(object sender, EventArgs e) => SelectShape(ShapeENum.Rectangle, (Button)sender);

        private void btnPolygon_Click(object sender, EventArgs e) => SelectShape(ShapeENum.Polygon, (Button)sender);

        private void btnEllipse_Click(object sender, EventArgs e) => SelectShape(ShapeENum.Ellipse, (Button)sender);

        private void drawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (selectedShape)
            {
                case ShapeENum.Line:
                    shapeManager.AddShape(new Line(penColor, penWidth, startPoint, e.Location));
                    break;
                case ShapeENum.BrokenLine:

                    break;
                case ShapeENum.Rectangle:
                    shapeManager.AddShape(new MyRectangle(penColor, brushColor, penWidth, startPoint, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y));
                    break;
                case ShapeENum.Polygon:

                    break;
                case ShapeENum.Ellipse:
                    shapeManager.AddShape(new Ellipse(penColor, brushColor, penWidth, startPoint, e.Location.X - startPoint.X, e.Location.Y - startPoint.Y));
                    break;
            }
            shapeManager.DrawAll(drawPanel.CreateGraphics());
        }
    }
}
