using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Hexagon : Shape
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public Point PointD { get; set; }
        public Point PointE { get; set; }
        public Point PointF { get; set; }
        public int Size { get; }

        public Hexagon(int size)
        {
            Size = size;
            Name = $"{FigureShape.Hexagon} {MainWindow.Shapes.Where(x => x.GetType() == typeof(Hexagon)).Count() + 1}";
        }
        
        public override void Draw(Graphics graphics)
        {
            graphics.DrawPolygon(Pen, new[] { PointA, PointB, PointC, PointD, PointE, PointF} );
        }

        public override string ToString()
        {
            return $"{Name} :\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y} " +
                $"{PointD.X} {PointD.Y} {PointE.X} {PointE.Y} {PointF.X} {PointF.Y}";
        }
    }
}