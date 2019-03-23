using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using MyPhotoshop.Filters.Transform;

namespace MyPhotoshop.Filters
{
    public class TransformFilter<TParameter> : ParametrizedFilter<TParameter>
        where TParameter : IParameters, new()
    {
        private ITransformer<TParameter> transformer;
        private readonly string name;
        public TransformFilter(string filterName, ITransformer<TParameter> transformer)
        {
            name = filterName;
            this.transformer = transformer; 
        }

        public override Photo Process(Photo original, TParameter parameters)
        {
            var oldSize = new Size(original.width,original.height);
            transformer.Prepare(oldSize, parameters);
            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);
            for (var x = 0; x < result.width; x++)
            for (var y = 0; y < result.height; y++)
            {
                var point = new Point(x,y);
                var oldPoint = transformer.MapPoint(point);
                if (oldPoint.HasValue)
                    result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
            }

            return result;
        }

        public override string ToString() => name;
    }
}
