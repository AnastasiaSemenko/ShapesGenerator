using Enums.ShapeGenerator;
using ShapeGenerator.Drawers;
using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator
{
    public class DrawerController
    {
        public event EventHandler<int> StartDraw;
        public event EventHandler EndDraw;
        public delegate void DrawProgressEventHandler(object sender, int progress, out bool cancelled, out bool stopped);
        public event DrawProgressEventHandler DrawProgress;

        private PictureBox _pictureBox;
        private Random _random = new();

        public FigureShape FigureShape { get; set; }
        public DrawingOption DrawingOption { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public List<Shape> Shapes { get; set; }

        public DrawerController(PictureBox pictureBox)
        {
            Shapes = new List<Shape>();
            _pictureBox = pictureBox;
        }

        public async Task GenerateShapes()
        {
            var count = _random.Next(From, To + 1);
            StartDraw?.Invoke(this, count);
            var drawer = GetDrawerForShape();
            var newShapes = new List<Shape>(Shapes);

            try
            {
                for (var i = 0; i < count; i++)
                {
                    var shape = await Task.Run(() => drawer.Draw(newShapes));
                    newShapes.Add(shape);
                    bool cancelled = false;
                    bool stopped = false;
                    DrawProgress?.Invoke(this, i + 1, out cancelled, out stopped);

                    if (stopped)
                    {
                        Shapes.Clear();
                        break;
                    }
                    else if (cancelled)
                    {
                        newShapes.Clear();
                        break;
                    }

                    if (i + 1 == count)
                        Shapes.Clear();
                }

                Shapes.AddRange(newShapes);
                EndDraw?.Invoke(this, EventArgs.Empty);
            }
            catch (CanvasOverflowException ex)
            {
                Shapes.Clear();
                Shapes.AddRange(newShapes);
                EndDraw?.Invoke(this, EventArgs.Empty);
                MainWindow.ShowWarningMessageBox(ex.Message);
            }
            finally
            {
                Shapes.Sort(new FigureComparer());
            }
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

        public void UpdateDrawParamAfterChangingDrawingOptionOrLoadData()
        {
            if (Shapes.Count > 0)
            {
                ShapeDrawer.InitializeOccupiedGrid(_pictureBox.Width, _pictureBox.Height, Shapes, DrawingOption);
                ShapeDrawer.ResetSize();
                ShapeDrawer.ResetNonLiquidPoints();
            }
        }

        public void UpdateDrawParamAfterChangingSelectedShape()
        {
            ShapeDrawer.ResetSize();
            ShapeDrawer.ResetNonLiquidPoints();
        }
    }
}