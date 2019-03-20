using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter<EmptyParameters>
    {
        public override Pixel ProcessPixel(Pixel original, EmptyParameters parameters)
        {
            var lightness = original.Red + original.Blue + original.Green;
            lightness /= 3;
            return new Pixel(lightness, lightness, lightness);
        }

        public override string ToString() => "В оттенках серого";
    }
}