using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Hexagon : Shape
    {
        public Hexagon() : base() { }

        public Hexagon(int size) : base()
        {
            Size = size;
            Points = new Point[6];
            Name = $"{FigureShape.Hexagon} {MainWindow.shapes.Where(x => x.GetType() == typeof(Hexagon)).Count() + 1}";
        }
 
        public override string ToString()
        {
            return $"{Name} :\n{Points[0].X} {Points[0].Y} {Points[1].X} {Points[1].Y} {Points[2].X} {Points[2].Y} " +
                $"{Points[3].X} {Points[3].Y} {Points[4].X} {Points[4].Y} {Points[5].X} {Points[5].Y}";
        }
    }
}