using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MyPhotoshop.Filters;

namespace MyPhotoshop
{
    public static class ParametersExtensions
    {
        public static System.Reflection.ParameterInfo[] GetDescription(this IParameters parameters)
        {
            return parameters.GetType()
                .GetProperties()
                .Select(x => x.GetCustomAttributes(typeof(System.Reflection.ParameterInfo), false))
                .Where(x => x.Length > 0)
                .Select(x => x[0])
                .Cast<System.Reflection.ParameterInfo>()
                .ToArray();
        }

        public static void SetValues(this IParameters parameters, double[] values)
        {
            var properties = parameters.GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(System.Reflection.ParameterInfo), false).Length>0)
                .ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                properties[i].SetValue(parameters,values[i], new object[0]);
            }
        }
    }
}
