using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Hexagon : Shape
    {
        public static int counter = 0;

        public Hexagon() : base() { }

        public Hexagon(int size, Point startPoint) : base()
        {
            StartPoint = startPoint;
            counter++;
            Id = counter;
            Size = size;
            Name = $"{FigureShape.Hexagon}";
            Points = CalculatePoints();
        }

        public override Point[] CalculatePoints() 
        {
            Point[] points = new Point[6];

            for (var j = 0; j < 6; j++)
            {
                var centerX = StartPoint.X + Size;
                var centerY = StartPoint.Y + Size;
                var angle_deg = 60 * j - 30;
                var angle_rad = Math.PI / 180 * angle_deg;
                var x = (int)(centerX + Size * Math.Cos(angle_rad));
                var y = (int)(centerY + Size * Math.Sin(angle_rad));
                points[j] = new Point(x, y);
            }

            return points;
        }
    }
}