namespace MyPhotoshop.Filters
{
    public abstract class PixelFilter <TParameter> : ParametrizedFilter <TParameter>
        where TParameter : IParameters, new()
    {
        public abstract Pixel ProcessPixel(Pixel original, TParameter parameters);

        public override Photo Process(Photo original, TParameter parameters)
        {
            var result = new Photo(original.width, original.height);

            for (var x = 0; x < result.width; x++)
            for (var y = 0; y < result.height; y++)
                result[x, y] = ProcessPixel(original[x, y], parameters);

            return result;
        }

        
    }
}