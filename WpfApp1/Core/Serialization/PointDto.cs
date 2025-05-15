

using System.Windows;

namespace WpfApp1.Core.Serialization
{
    public class PointDto
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointDto() { }

        public PointDto(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point ToPoint() => new Point(X, Y);
    }
}
