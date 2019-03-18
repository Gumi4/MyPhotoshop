namespace MyPhotoshop.Filters
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters parameters) : base(parameters)
        {
        }

        public abstract Pixel ProcessPixel(Pixel original, IParameters parameters);

        public override Photo Process(Photo original, IParameters parameters)
        {
            var result = new Photo(original.width, original.height);

            for (var x = 0; x < result.width; x++)
            for (var y = 0; y < result.height; y++)
                result[x, y] = ProcessPixel(original[x, y], parameters);

            return result;
        }
        
    }
}