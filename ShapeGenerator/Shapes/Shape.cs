namespace ShapeGenerator.Shapes
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public Point[] Points { get; set; }
        public int Size { get; set; }
    }
}
