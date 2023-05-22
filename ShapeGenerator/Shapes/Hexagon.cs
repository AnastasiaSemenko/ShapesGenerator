using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Hexagon : Shape
    {
        public static int counter = 0;

        public Hexagon() : base() { }

        public Hexagon(int size) : base()
        {
            counter++;
            Id = counter;
            Size = size;
            Points = new Point[6];
            Name = $"{FigureShape.Hexagon}";
        }
    }
}