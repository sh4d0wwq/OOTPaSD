using System.Drawing;

namespace OOTPaSD.Shapes
{
    public abstract class Shape
    {
        public Color penColor { get; set; }
        public Color brushColor { get; set; }
        public int penWidth { get; set; }
        public Point position { get; set; }
        public abstract void Draw(Graphics g);
    }
}
