using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyPhotoshop.Filters.Parameters
{
    public class ExpressionParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParameters, new()
    {
        private static readonly Func<double[], TParameters> parser;

        private static readonly ParameterInfo[] decription;

        static ExpressionParametersHandler()
        {
            var properties = typeof(TParameters)
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            decription = typeof(TParameters)
                .GetProperties()
                .Select(x => x.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(x => x.Length > 0)
                .Select(x => x[0])
                .Cast<ParameterInfo>()
                .ToArray();
            var bindings = new List<MemberBinding>();
            var arg = Expression.Parameter(typeof(double[]), "values");
            for (var i = 0; i < properties.Length; i++)
            {
                var binding = Expression.Bind(
                    properties[i],
                    Expression.ArrayIndex(
                        arg,
                        Expression.Constant(i)));
                bindings.Add(binding);
            }

            var body = Expression.MemberInit(
                Expression.New(typeof(TParameters).GetConstructor(new Type[0])), bindings);
            var lambda = Expression.Lambda<Func<double[], TParameters>>(body, arg);
            parser = lambda.Compile();
        }

        public ParameterInfo[] GetDescription() => decription;

        public TParameters CreateParameters(double[] values) => parser(values);
    }
}