using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Rectangle : Shape
    {
        public static int counter = 0;

        public Rectangle() { }

        public Rectangle(int size) : base()
        {
            counter++;
            Id = counter;
            Size = size;
            Points = new Point[4];
            Name = $"{FigureShape.Rectangle}";
        }
    }
}