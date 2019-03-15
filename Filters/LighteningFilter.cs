namespace MyPhotoshop
{
    public class LighteningFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new[]
            {
                new ParameterInfo {Name = "Коэффициент", MaxValue = 10, MinValue = 0, Increment = 0.1, DefaultValue = 1}
            };
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);

            for (var x = 0; x < result.width; x++)
            for (var y = 0; y < result.height; y++)
                result[x, y] = original[x, y] * parameters[0];

            return result;
        }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}