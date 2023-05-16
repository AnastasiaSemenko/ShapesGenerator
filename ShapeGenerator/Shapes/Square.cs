using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Square : Shape
    {
        public Square() : base() { }

        public Square(int size) : base()
        {
            Size = size;
            Points = new Point[4];
            Name = $"{FigureShape.Square} {MainWindow.shapes.Where(x => x.GetType() == typeof(Square)).Count() + 1}";
        }
        
        public override string ToString()
        {
            return $"{Name} :\n{Points[0].X} {Points[0].Y} {Points[1].X} {Points[1].Y} " +
                $"{Points[2].X} {Points[2].Y} {Points[3].X} {Points[3].Y}";
        }
    }
}