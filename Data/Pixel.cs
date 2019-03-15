using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double blue;
        private double green;
        private double red;

        public double Red
        {
            get => red;
            set => red = CheckValue(value);
        }

        public double Green
        {
            get => green;
            set => green = CheckValue(value);
        }

        public double Blue
        {
            get => blue;
            set => blue = CheckValue(value);
        }

        private double CheckValue(double value)
        {
            if (value < 0 || value > 1)
                throw new Exception("Value must be  from 0 to 1");
            return value;
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public Pixel(double red, double green, double blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public static Pixel operator *(Pixel pixel, double coef)
        {
            return new Pixel(Trim(pixel.red * coef), Trim(pixel.green * coef), Trim(pixel.blue * coef));
        }

        public static Pixel operator *(double coef, Pixel pixel)
        {
            return pixel * coef;
        }
    }
}