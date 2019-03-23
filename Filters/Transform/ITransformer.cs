using System.Drawing;

namespace MyPhotoshop.Filters.Transform
{
    public interface ITransformer<in TParameter>
        where TParameter : IParameters, new()
    {
        Size ResultSize { get; }
        void Prepare(Size size, TParameter parameters);
        Point? MapPoint(Point point);
    }
}