using Enums.ShapeGenerator;

namespace ShapeGenerator.Shapes
{
    public class Square : Shape
    {
        public static int counter = 0;

        public Square() : base() { }

        public Square(int size) : base()
        {
            counter++;
            Id = counter;
            Size = size;
            Points = new Point[4];
            Name = $"{FigureShape.Square}";
        }
    }
}