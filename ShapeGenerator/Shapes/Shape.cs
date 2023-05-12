namespace ShapeGenerator.Shapes
{
    public abstract class Shape : IDrawable
    {
        public string Name { get; protected set; }
        public Pen Pen { get; } = new Pen(Color.Black, 2);
        public System.Drawing.Rectangle Bounds { get; set; }

        public abstract void Draw(Graphics graphics);
    }
}
