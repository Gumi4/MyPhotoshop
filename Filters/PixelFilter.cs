using System;

namespace MyPhotoshop.Filters
{
    public class PixelFilter<TParameter> : ParametrizedFilter<TParameter>
        where TParameter : IParameters, new()
    {
        private readonly string name;
        private readonly Func<Pixel, TParameter, Pixel> processor;

        public PixelFilter(string filterName, Func<Pixel, TParameter, Pixel> processor)
        {
            name = filterName;
            this.processor = processor;
        }

        public override Photo Process(Photo original, TParameter parameters)
        {
            var result = new Photo(original.width, original.height);

            for (var x = 0; x < result.width; x++)
            for (var y = 0; y < result.height; y++)
                result[x, y] = processor(original[x, y], parameters);

            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}