﻿using System.Drawing;


namespace OOTPaSD.Shapes
{
    class Polygon: Shape
    {
        public Point[] points { get; set; }
        public Polygon(Color penColor, Color brushColor, int penWidth, Point[] points)
        {
            this.penColor = penColor;
            this.brushColor = brushColor;
            this.penWidth = penWidth;
            this.points = points;
        }

        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(brushColor))
            using (var pen = new Pen(penColor, penWidth))
            {
                g.FillPolygon(brush, points);
                g.DrawPolygon(pen, points);
            }
        }
    }
}
