using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public class FigureComparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            var compareFigure = string.Compare(x.Name, y.Name);

            if (compareFigure != 0)
                return compareFigure;

            return x.Id.CompareTo(y.Id);
        }
    }
}