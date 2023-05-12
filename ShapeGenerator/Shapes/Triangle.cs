using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Triangle : Shape
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public int Size { get; }

        public Triangle(int size)
        {
            Size = size;
            Name = $"{FigureShape.Triangle} {MainWindow.Shapes.Where(x => x.GetType() == typeof(Triangle)).Count() + 1}";
        }
        
        public override void Draw(Graphics graphics)
        {
            graphics.DrawPolygon(Pen, new[] { PointA, PointB, PointC });
        }

        public override string ToString()
        {
            return $"{Name} :\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y}";
        }
    }
}