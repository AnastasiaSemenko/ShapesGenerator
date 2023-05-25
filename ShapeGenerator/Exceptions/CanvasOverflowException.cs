namespace ShapeGenerator.Exceptions
{
    public class CanvasOverflowException : Exception
    {
        public CanvasOverflowException()
        {
        }

        public CanvasOverflowException(string? message) : base(message)
        {
        }
    }
}
