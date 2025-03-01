using System.Drawing;

namespace OOP.Shapes
{
    public class MyRectangle : Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public MyRectangle(Color penColor, Color brushColor, int penWidth, Point position, int width, int height)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                Rectangle rect = new Rectangle(position.X, position.Y, width, height);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
