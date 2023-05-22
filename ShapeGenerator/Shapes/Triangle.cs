using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Triangle : Shape
    {
        public static int counter = 0;

        public Triangle() : base() { }

        public Triangle(int size) : base()
        {
            counter++;
            Id = counter;
            Size = size;
            Points = new Point[3];
            Name = $"{FigureShape.Triangle}";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}