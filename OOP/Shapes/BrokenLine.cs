using System.Drawing;

namespace OOTPaSD.Shapes
{
    class BrokenLine: Shape
    {
        public Point[] points { get; set; }
        public BrokenLine(Color penColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.points = points;
        }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLines(pen, points);
            }
        }
    }
}
