using System;

namespace MyPhotoshop
{
    public class Photo
    {
        private readonly Pixel[,] data;
        public readonly int height;
        public readonly int width;

        public Photo(int width, int height)
        {
            this.width = width;
            this.height = height;
            data = new Pixel[width, height];

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                data[x, y] = new Pixel();
        }

        public Pixel this[int x, int y]
        {
            get
            {
                if (x < 0 || x > width || y < 0 || y > height) throw new IndexOutOfRangeException();
                return data[x, y];
            }
            set => data[x,y] = value;
        }
    }
}