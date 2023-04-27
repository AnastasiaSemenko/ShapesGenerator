namespace ShapeGenerator.Shapes
{
    public abstract class Shape : IDrawable
    {
        public string Name { get; protected set; }
        public Pen Pen { get; } = new Pen(Color.Black, 2);

        public abstract void Draw(Point point, Graphics graphics);
    }
}
