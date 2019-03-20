using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public class LighteningFilter : PixelFilter<LighteningParameters>
    {
        public override Pixel ProcessPixel(Pixel pixel, LighteningParameters parameter) => pixel * parameter.Coefficient;

        public override string ToString() => "Осветление/затемнение";
    }
}