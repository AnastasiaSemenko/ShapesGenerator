using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Rectangle : Shape
    {
        public static int counter = 0;

        public Rectangle() { }

        public Rectangle(int size, Point startPoint) : base()
        {
            counter++;
            Id = counter;
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