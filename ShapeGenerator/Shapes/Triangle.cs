using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Triangle : Shape
    {
        public static int counter = 0;

        public Triangle() : base() { }

        public Triangle(int size, Point startPoint) : base()
        {
            StartPoint = startPoint;
            Size = size;
            Name = $"{FigureShape.Triangle}";
            Points = CalculatePoints();
        }

        public override Point[] CalculatePoints()
        {
            var points = new Point[] {
                new Point(StartPoint.X + Size / 2, StartPoint.Y),
                new Point(StartPoint.X, StartPoint.Y + Size),
                new Point(StartPoint.X + Size, StartPoint.Y + Size) };
            
            return points;
        }
    }
}