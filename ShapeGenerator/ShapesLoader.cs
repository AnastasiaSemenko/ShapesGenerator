using Newtonsoft.Json;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;
using System.Windows.Forms;

namespace ShapeGenerator
{
    public class ShapesLoader
    {
        private static JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };

        public static void SaveShapes(List<Shape> shapes, string fileName) 
        {
            var json = JsonConvert.SerializeObject(shapes, _settings);
            File.WriteAllText(fileName, json);
        }

        public static List<Shape> LoadShapes(string fileName) 
        {
            var jsonFromFile = File.ReadAllText(fileName);
            var deserializedShapes = JsonConvert.DeserializeObject<List<Shape>>(jsonFromFile, _settings) ?? 
                throw new JsonValidationException("File is Empty");
            
            foreach (var shape in deserializedShapes)
                if (!shape.CalculatePoints().SequenceEqual(shape.Points))
                    throw new JsonValidationException("Invalid Json file.");

            return deserializedShapes;
        }
    }
}
