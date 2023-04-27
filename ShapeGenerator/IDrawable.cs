namespace ShapeGenerator
{
    public interface IDrawable
    {
        public Pen Pen { get; }
        public void Draw(Point point, Graphics graphics);
    }
}
