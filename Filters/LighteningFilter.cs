using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public class LighteningFilter : PixelFilter
    {
       public LighteningFilter() : base(new LighteningParameters())
        {
        }


        public override Pixel ProcessPixel(Pixel pixel, IParameters parameter)
        {
            return pixel * ((LighteningParameters) parameter).Coefficient;
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}