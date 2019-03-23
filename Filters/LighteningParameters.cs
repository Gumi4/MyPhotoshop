namespace MyPhotoshop.Filters
{
    public class RotationParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDesсription()
        {
            return new[]
            {
                new ParameterInfo {Name = "Коэффициент", MaxValue = 360, MinValue = 0, Increment = 5, DefaultValue = 0}
            };
        }

        public void SetValues(double[] parameters)
        {
            Angle = parameters[0];
        }
    }
}