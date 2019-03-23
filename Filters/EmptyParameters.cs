namespace MyPhotoshop.Filters
{
    public class EmptyParameters : IParameters
    {
        public ParameterInfo[] GetDesсription()
        {
            return new ParameterInfo[0];
        }

        public void SetValues(double[] parameters)
        {
        }
    }
}