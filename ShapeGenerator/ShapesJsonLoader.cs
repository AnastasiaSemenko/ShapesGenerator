using Newtonsoft.Json;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public class ShapesJsonLoader
    {
        public static void SaveShapes(List<Shape> shapes, string fileName)
        {
            var json = JsonConvert.SerializeObject(shapes, new ShapesJsonConverter());
            File.WriteAllText(fileName, json);
        }

        public static List<Shape> LoadShapes(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var shapes = JsonConvert.DeserializeObject<List<Shape>>(json, new ShapesJsonConverter());

            foreach (var shape in shapes)
            {
                if (shape is Hexagon || shape is Square || shape is Triangle || shape is Shapes.Rectangle)
                {
                    if (!shape.CalculatePoints().SequenceEqual(shape.Points))
                        throw new JsonValidationException("Invalid Json file.");
                }
                else
                    throw new JsonValidationException("Invalid Json file.");
            }

            return shapes;
        }
    }
}