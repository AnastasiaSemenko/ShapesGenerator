using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Triangle : Shape
    {
        public Triangle() : base() { }

        public Triangle(int size) : base()
        {
            Size = size;
            Points = new Point[3];
            Name = $"{FigureShape.Triangle} {MainWindow.shapes.Where(x => x.GetType() == typeof(Triangle)).Count() + 1}";
        }
        
        public override string ToString()
        {
            return $"{Name} :\n{Points[0].X} {Points[0].Y} {Points[1].X} {Points[1].Y} {Points[2].X} {Points[2].Y}";
        }
    }
}