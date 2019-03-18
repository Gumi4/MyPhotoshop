using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter
    {
        public GrayscaleFilter() : base(new EmptyParameters())
        {
        }

        public override Pixel ProcessPixel(Pixel original, IParameters parameters)
        {
            var lightness = original.Red + original.Blue + original.Green;
            lightness /= 3;
            return new Pixel(lightness, lightness, lightness);
        }

        public override string ToString()
        {
            return "В оттенках серого";
        }
    }
}