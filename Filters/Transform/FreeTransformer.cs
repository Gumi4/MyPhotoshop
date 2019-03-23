using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters.Transform
{
    class FreeTransformer : ITransformer<EmptyParameters>
    {
        private Func<Size, Size> sizeTransformer;
        private Func<Point, Size, Point?> pointTransformer;
        private Size oldSize;

        public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point?> pointTransformer)
        {
            this.pointTransformer = pointTransformer;
            this.sizeTransformer = sizeTransformer;
        }
        public void Prepare(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransformer(oldSize);
        }

        public Size ResultSize { get; private set; }
        public Point? MapPoint(Point point)
        {
            return pointTransformer(point, oldSize);
        }
    }
}
