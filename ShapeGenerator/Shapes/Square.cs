namespace ShapeGenerator.Shapes
{
    public class Square : Shape
    {
        public Point PointA { get; private set; }
        public Point PointB { get; private set; }
        public Point PointC { get; private set; }
        public Point PointD { get; private set; }
        public int Size { get; }

        public Square(int size)
        {
            Size = size;
            Name = $"Квадрат {MainWindow.shapes.Where(x => x.GetType() == typeof(Square)).Count() + 1}";
        }

        public override void Draw(Point point, Graphics graphics)
        {
            graphics.DrawRectangle(Pen, new System.Drawing.Rectangle(point.X, point.Y, Size, Size));
            PointA = point;
            PointB = new Point(point.X + Size, point.Y);
            PointC = new Point(point.X, point.Y + Size);
            PointD = new Point(point.X + Size, point.Y + Size);
        }

        public override string ToString()
        {
            return $"{Name}:\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y} {PointD.X} {PointD.Y}";
        }
    }
}
