using Enums.ShapeGenerator;
using Newtonsoft.Json;
using ShapeGenerator.Drawers;
using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
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
            var count = _random.Next(From, To + 1);
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
            var json = JsonConvert.SerializeObject(Shapes, _settings);
            File.WriteAllText(saveFileDialog.FileName, json);
        }

        public void LoadShapes(OpenFileDialog openFileDialog)
        {
            var selectedFileName = openFileDialog.FileName;
            var jsonFromFile = File.ReadAllText(selectedFileName);
            var deserializedShapes = JsonConvert.DeserializeObject<List<Shape>>(jsonFromFile, _settings);

            if (deserializedShapes == null)
                throw new JsonValidationException("File is Empty");

            foreach (var shape in deserializedShapes)
                if (!shape.CalculatePoints().SequenceEqual(shape.Points))
                    throw new JsonValidationException("Invalid Json file.");

            Shapes = deserializedShapes;
            Shapes.Sort(new FigureComparer());
        }

        public void DrawNameForShape(Shape shape, Graphics g)
        {
            var font = new Font("Arial", 12, FontStyle.Bold);
            var textSize = g.MeasureString($"{shape.Name} {shape.Id}", font);
            var center = ShapeDrawer.GetCenterPoint(shape);
            g.DrawString($"{shape.Name} {shape.Id}", font, Brushes.Black, center.X - (textSize.Width / 2), center.Y - (textSize.Height / 2));
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