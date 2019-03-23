using System;
using System.Drawing;
using MyPhotoshop.Filters.Transform;

namespace MyPhotoshop.Filters
{
    public class TransformFilter : TransformFilter<EmptyParameters>
    {
        public TransformFilter(string filterName, Func<Size, Size> sizeTransformer,
            Func<Point, Size, Point?> pointTransformer)
            : base(filterName, new FreeTransformer(sizeTransformer, pointTransformer))
        {
        }
    }
}