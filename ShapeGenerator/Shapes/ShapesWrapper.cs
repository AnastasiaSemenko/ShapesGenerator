namespace ShapeGenerator.Shapes
{
    public class ShapesWrapper
    {
        public ShapesWrapper() { }

        public ShapesWrapper(List<Shape> shapes) 
        { 
            Shapes = shapes;
        }

        public List<Shape> Shapes { get; set; }
    }
}
