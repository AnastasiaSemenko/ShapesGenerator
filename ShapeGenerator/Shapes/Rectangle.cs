using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    [Serializable]
    public class Rectangle : Shape
    {
        public Rectangle() { }

        public Rectangle(int size, Point startPoint) : base()
        {
            StartPoint = startPoint;
            Size = size;
            Name = $"{FigureShape.Rectangle}";
            Points = CalculatePoints();
        }

        public override Point[] CalculatePoints()
        {
            var points = new Point[] {
                new Point(StartPoint.X, StartPoint.Y),
                new Point(StartPoint.X + Size * 2, StartPoint.Y),
                new Point(StartPoint.X + Size * 2, StartPoint.Y + Size),
                    new Point(StartPoint.X, StartPoint.Y + Size) };

            return points;
        }
    }
}