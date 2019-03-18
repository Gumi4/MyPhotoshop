using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParameters parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }
        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDesсription();
        }

        public Photo Process(Photo original, double[] parameters)
        {
            this.parameters.SetValues(parameters);
            return Process(original, this.parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
