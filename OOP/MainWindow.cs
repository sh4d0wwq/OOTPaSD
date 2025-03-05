using OOTPaSD.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace OOTPaSD
{
    
    public partial class MainWindow: Form
    {
        private ShapeManager shapeManager = new ShapeManager();
        private bool isDrawing = false;
        private bool isPreDrawing = false;
        private Shape tempShape;
        private Point currentPoint;
        private List<Point> pointArray = new List<Point>();
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
                btnBrushColor.BackColor = brushColor;
            }
        }

        private void btnPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                penColor = colorDialog.Color;
                btnPenColor.BackColor = penColor;
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
            if (e.Button == MouseButtons.Left)
            {
                if (selectedShape != ShapeENum.BrokenLine && selectedShape != ShapeENum.Polygon)
                {
                    if (!isDrawing)
                    {
                        isDrawing = true;
                        startPoint = e.Location;
                    }
                    else
                    {
                        shapeManager.AddShape(tempShape);
                        tempShape = null;
                        isDrawing = false;
                        drawPanel.Invalidate();
                    }
                }            
                else
                {
                    if (isPreDrawing)
                    {
                        isDrawing = true;
                    }
                    isPreDrawing = true;
                    pointArray.Add(e.Location);
                }
            }
            else if (e.Button == MouseButtons.Right && isDrawing)
            {
                tempShape = null;
                pointArray.Clear();
                isDrawing = false;
                isPreDrawing = false;
                drawPanel.Invalidate();
            }
            else if (e.Button == MouseButtons.Middle && isDrawing)
            {
                shapeManager.AddShape(tempShape);
                tempShape = null;
                pointArray.Clear();
                isDrawing = false;
                isPreDrawing = false;
                drawPanel.Invalidate();
            }
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            currentPoint = e.Location;

            switch (selectedShape)
            {
                case ShapeENum.Line:
                    tempShape = new Line(penColor, penWidth, startPoint, currentPoint);
                    break;
                case ShapeENum.BrokenLine:
                    pointArray[pointArray.Count - 1] = e.Location;
                    tempShape = new BrokenLine(penColor, penWidth, pointArray.ToArray());
                    break;
                case ShapeENum.Rectangle:
                    tempShape = new MyRectangle(penColor, brushColor, penWidth, startPoint,
                                                currentPoint.X - startPoint.X,
                                                currentPoint.Y - startPoint.Y);
                    break;
                case ShapeENum.Ellipse:
                    tempShape = new Ellipse(penColor, brushColor, penWidth, startPoint,
                                            currentPoint.X - startPoint.X,
                                            currentPoint.Y - startPoint.Y);
                    break;
                case ShapeENum.Polygon:
                    pointArray[pointArray.Count - 1] = e.Location;
                    tempShape = new Polygon(penColor, brushColor, penWidth, pointArray.ToArray());
                    break;
            }

            drawPanel.Invalidate();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            shapeManager.DrawAll(e.Graphics);

            if (isDrawing && tempShape != null)
            {
                tempShape.Draw(e.Graphics);
            }
        }
    }
}
