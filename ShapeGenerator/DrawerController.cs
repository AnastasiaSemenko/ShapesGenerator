using Enums.ShapeGenerator;
using Newtonsoft.Json;
using ShapeGenerator.Drawers;
using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator
{
    public class DrawerController
    {
        private PictureBox _pictureBox;
        private Random _random = new();
        private JsonSerializerSettings _settings;

        public FigureShape FigureShape { get; set; }
        public DrawingOption DrawingOption { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<Shape> Shapes { get; set; }

        public DrawerController(PictureBox pictureBox)
        {
            Shapes = new List<Shape>();
            _pictureBox = pictureBox;
            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            };
        }

        public void DrawShapes()
        {
            var count = _random.Next(From, To);
            var drawer = GetDrawerForShape();

            try
            {
                for (var i = 0; i < count; i++)
                {
                    var shape = drawer.Draw(Shapes);
                    Shapes.Add(shape);
                }
            }
            finally
            {
                Shapes.Sort(new FigureComparer());
            }
        }

        public void ClearShapes()
        {
            Shapes.Clear();
            ResetShapesCounter();
        }

        public void SaveShapes(SaveFileDialog saveFileDialog)
        {
            try
            {
                var json = JsonConvert.SerializeObject(Shapes, _settings);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (JsonException ex)
            {
                throw ex;
            }
        }

        public void LoadShapes(OpenFileDialog openFileDialog)
        {
            try
            {
                var selectedFileName = openFileDialog.FileName;
                var jsonFromFile = File.ReadAllText(selectedFileName);
                var deserializedShapes = JsonConvert.DeserializeObject<List<Shape>>(jsonFromFile, _settings);
                Shapes = deserializedShapes;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (JsonException ex)
            {
                throw ex;
            }
            
            Shapes.Sort(new FigureComparer());
        }

        public void DrawNameForShape(Shape shape, Graphics g)
        {
            
            Font font = new Font("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString($"{shape.Name} {shape.Id}", font);
            g.DrawString($"{shape.Name} {shape.Id}", font, Brushes.Black, shape.Center.X - (textSize.Width / 2), shape.Center.Y - (textSize.Height / 2));
        }

        public Shape GetSelectedShape(string str)
        {
            var array = str.Split(' ');
            var name = array[0];
            var id = int.Parse(array[1]);
            return Shapes.Find(s => s.Name == name && s.Id == id);
        }

        public int GetMaxNestingLevel()
        {
            return NestingLevelCalculator.GetMaxNestingLevel(Shapes);
        }

        private ShapeDrawer GetDrawerForShape()
        {
            switch (FigureShape)
            {
                case FigureShape.Square:
                    return new SquareDrawer(_pictureBox, DrawingOption);
                case FigureShape.Rectangle:
                    return new RectangleDrawer(_pictureBox, DrawingOption);
                case FigureShape.Hexagon:
                    return new HexagonDrawer(_pictureBox, DrawingOption);
                case FigureShape.Triangle:
                    return new TriangleDrawer(_pictureBox, DrawingOption);
                default:
                    Debug.WriteLine("Attempt to draw shapes of unknown type");
                    return null;
            }
        }

        private void ResetShapesCounter()
        {
            Hexagon.counter = 0;
            Triangle.counter = 0;
            ShapeGenerator.Shapes.Rectangle.counter = 0;
            Square.counter = 0;
        }
    }
}