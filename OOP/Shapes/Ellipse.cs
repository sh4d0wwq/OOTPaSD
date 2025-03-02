using System.Drawing;

namespace OOTPaSD.Shapes
{
    class Ellipse: Shape
    {
        public int width { get; set; }
        public int height { get; set; }
        public Ellipse(Color penColor, Color brushColor, int penWidth, Point position, int width, int height)
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
                g.FillEllipse(brush, rect);
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
