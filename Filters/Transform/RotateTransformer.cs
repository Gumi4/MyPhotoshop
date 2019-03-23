using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters.Transform
{
    public class RotateTransformer : ITransformer<RotationParameters>
    {
        public Size OriginalSize;

        public void Prepare(Size size, RotationParameters parameters)
        {
            OriginalSize = size;
            Angle = Math.PI * parameters.Angle / 180;
            ResultSize = new Size(
                (int)(size.Width * Math.Abs(Math.Cos(Angle)) + size.Height * Math.Abs(Math.Sin(Angle))),
                (int)(size.Height * Math.Abs(Math.Cos(Angle)) + size.Width * Math.Abs(Math.Sin(Angle)))
            );
        }
        public Size ResultSize{get; private set;}
        public double Angle { get; private set; }

        public Point? MapPoint(Point point)
        {
            var newPoint = new Point(point.X - ResultSize.Width / 2, point.Y - ResultSize.Height / 2);
            var x = OriginalSize.Width / 2 + (int)(newPoint.X * Math.Cos(Angle) + newPoint.Y * Math.Sin(Angle));
            var y = OriginalSize.Height / 2 + (int)(-newPoint.X * Math.Sin(Angle) + newPoint.Y * Math.Cos(Angle));
            if (x < 0 || x >= OriginalSize.Width || y < 0 || y >= OriginalSize.Height) return null;
            return new Point(x, y);
        }
    }
}
