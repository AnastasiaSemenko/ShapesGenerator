namespace ShapeGenerator.Exceptions
{
    public class JsonValidationException : Exception
    {
        public JsonValidationException() 
        { 
        }

        public JsonValidationException(string? message) : base(message)
        {
        }
    }
}
