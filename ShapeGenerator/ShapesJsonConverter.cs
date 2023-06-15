using Enums.ShapeGenerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public class ShapesJsonConverter : JsonConverter<Shape>
    {
        public override Shape ReadJson(JsonReader reader, Type objectType, Shape existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                var jObject = JObject.Load(reader);
                Shape target = null;
                var figureShape = jObject.GetValue("Name").ToObject<FigureShape>();

                switch (figureShape)
                {
                    case FigureShape.Hexagon:
                        target = new Hexagon();
                        break;
                    case FigureShape.Rectangle:
                        target = new Shapes.Rectangle();
                        break;
                    case FigureShape.Square:
                        target = new Square();
                        break;
                    case FigureShape.Triangle:
                        target = new Triangle();
                        break;
                }

                if (target != null)
                {
                    var startPointStr = jObject.GetValue("StartPoint").ToObject<string>();
                    var startPointCoords = startPointStr.Split(',');

                    if (startPointCoords.Length == 2 && int.TryParse(startPointCoords[0], out int x)
                        && int.TryParse(startPointCoords[1], out int y))
                        target.StartPoint = new Point(x, y);

                    target.Id = jObject.GetValue("Id").ToObject<int>();
                    target.Name = jObject.GetValue("Name").ToObject<string>();
                    var pointsArray = jObject.GetValue("Points") as JArray;

                    if (pointsArray != null)
                    {
                        var points = new List<Point>();

                        foreach (var pointToken in pointsArray)
                        {
                            var pointX = pointToken["X"].ToObject<int>();
                            var pointY = pointToken["Y"].ToObject<int>();
                            points.Add(new Point(pointX, pointY));
                        }

                        target.Points = points.ToArray();
                    }

                    target.Size = jObject.GetValue("Size").ToObject<int>();
                }

                return target;
            }
            catch (JsonReaderException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, Shape value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("StartPoint");
            writer.WriteValue(value.StartPoint.X + "," + value.StartPoint.Y);
            writer.WritePropertyName("Id");
            writer.WriteValue(value.Id);
            writer.WritePropertyName("Name");
            writer.WriteValue(value.Name);
            writer.WritePropertyName("Points");
            writer.WriteStartArray();

            foreach (var point in value.Points)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("X");
                writer.WriteValue(point.X);
                writer.WritePropertyName("Y");
                writer.WriteValue(point.Y);
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.WritePropertyName("Size");
            writer.WriteValue(value.Size);
            writer.WriteEndObject();
        }
    }
}