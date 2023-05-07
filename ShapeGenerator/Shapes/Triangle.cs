namespace ShapeGenerator.Shapes
{
    public class Triangle : Shape
    {
        public Point PointA { get; private set; }
        public Point PointB { get; private set; }
        public Point PointC { get; private set; }
        public int Size { get; }

        public Triangle(int size)
        {
            Size = size;
            Name = $"Треугольник {MainWindow.shapes.Where(x => x.GetType() == typeof(Triangle)).Count() + 1}";
        }

        public override void Draw(Point point, Graphics graphics)
        {
            graphics.DrawPolygon(Pen, new[] { 
                new Point(point.X + Size / 2, point.Y), 
                new Point(point.X, point.Y + Size), 
                new Point(point.X + Size, point.Y + Size) 
            });
            PointA = new Point(point.X + Size / 2, point.Y);
            PointB = new Point(point.X, point.Y + Size);
            PointC = new Point(point.X + Size, point.Y + Size);
        }

        public override string ToString()
        {
            return $"{Name} :\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y}";
        }
    }
}