using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    [Serializable]
    public class Hexagon : Shape
    {
        public Hexagon() : base() { }

        public Hexagon(int size, Point startPoint) : base()
        {
            StartPoint = startPoint;
            Size = size;
            Name = $"{FigureShape.Hexagon}";
            Points = CalculatePoints();
        }

        public override Point[] CalculatePoints()
        {
            Point[] vertices = new Point[6];
            var centerPoint = new Point(StartPoint.X + Size, StartPoint.Y + Size);
            var yOffset = (int) Size / 2;
            var xOffset = (int)Math.Sqrt(Size * Size - yOffset * yOffset);
            vertices[0] = new Point(centerPoint.X, StartPoint.Y);
            vertices[1] = new Point(centerPoint.X + xOffset, centerPoint.Y - yOffset);
            vertices[2] = new Point(centerPoint.X + xOffset, centerPoint.Y + yOffset);
            vertices[3] = new Point(centerPoint.X, StartPoint.Y + Size * 2);
            vertices[4] = new Point(centerPoint.X - xOffset, centerPoint.Y + yOffset);
            vertices[5] = new Point(centerPoint.X - xOffset, centerPoint.Y - yOffset);

            return vertices;
        }
    }
}