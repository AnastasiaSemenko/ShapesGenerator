using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator.Drawers
{
    public class SquareDrawer : ShapeDrawer
    {
        public SquareDrawer(PictureBox pictureBox, DrawingOption drawingOption) :
            base(pictureBox, drawingOption)
        {
        }

        public override Shape Draw(List<Shape> shapes)
        {
            SetSize();
            var maxX = _pictureBox.Width - _size;
            var maxY = _pictureBox.Height - _size;
            var point = new Point(_random.Next(maxX), _random.Next(maxY));
            var square = new Square(_size, point);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(square, shapes))
                {
                    if (stopwatch.ElapsedMilliseconds > 2500)
                    {
                        stopwatch.Stop();
                        Square.counter--;
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                    }

                    square.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    square.Points = square.CalculatePoints();
                }
            }

            stopwatch.Stop();
            return square;
        }
    }
}