using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public class FigureComparer : IComparer<Shape>
    {
        public int Compare(Shape x, Shape y)
        {
            var textX = x.ToString();
            var textY = y.ToString();
            var partsX = textX.Split(' ');
            var partsY = textY.Split(' ');
            var figureX = partsX[0];
            var figureY = partsY[0];
            var numberX = int.Parse(partsX[1]);
            var numberY = int.Parse(partsY[1]);
            var compareFigure = string.Compare(figureX, figureY, StringComparison.Ordinal);

            if (compareFigure != 0)
                return compareFigure;

            return numberX.CompareTo(numberY);
        }
    }
}
