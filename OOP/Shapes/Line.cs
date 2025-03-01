using System.Drawing;

namespace OOP.Shapes
{
    public class Line : Shape
    {
        public Point endPos { get; set; }

        public Line(Color penColor, int penWidth, Point start, Point end)
        {
            this.penColor = penColor;
            this.penWidth = penWidth;
            this.position = start;
            this.endPos = end;
        }

        public override void Draw(Graphics g)
        {
            using (var pen = new Pen(penColor, penWidth))
            {
                g.DrawLine(pen, position, endPos);
            }
        }
    }
}
