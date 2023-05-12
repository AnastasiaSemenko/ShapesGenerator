using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Rectangle : Shape
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public Point PointD { get; set; }
        public int Size { get; }

        public Rectangle(int size)
        {
            Size = size;
            Name = $"{FigureShape.Rectangle} {MainWindow.Shapes.Where(x => x.GetType() == typeof(Rectangle)).Count() + 1}";
        }
        
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(Pen, new System.Drawing.Rectangle(PointA.X, PointA.Y, Size * 2, Size));
        }

        public override string ToString()
        {
            return $"{Name} :\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y} {PointD.X} {PointD.Y}";
        }
    }
}