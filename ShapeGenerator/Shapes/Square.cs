using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Square : Shape
    {
        public static int counter = 0;

        public Square() : base() { }

        public Square(int size, Point startPoint) : base()
        {
            counter++;
            Id = counter;
            StartPoint = startPoint;
            Size = size;
            Name = $"{FigureShape.Square}";
            Points = CalculatePoints();
        }

        public override Point[] CalculatePoints()
        {
            var points = new Point[] {
                new Point(StartPoint.X, StartPoint.Y),
                new Point(StartPoint.X + Size, StartPoint.Y),
                new Point(StartPoint.X + Size, StartPoint.Y + Size),
                new Point(StartPoint.X, StartPoint.Y + Size) };

            return points;
        }
    }
}