using ShapeGenerator.Enums;
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
            var square = new Square(_size);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                var point = new Point(_random.Next(maxX), _random.Next(maxY));
                square.Points = new Point[] {
                        new Point(point.X, point.Y),
                        new Point(point.X + _size, point.Y),
                        new Point(point.X + _size, point.Y + _size),
                        new Point(point.X, point.Y + _size) };

                if (_drawingOption == DrawingOption.Intersecting)
                    break;

                if (stopwatch.ElapsedMilliseconds > 2500)
                {
                    stopwatch.Stop();
                    Square.counter--;
                    throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                }
            }
            while (CheckShapeIntersection(square, shapes));

            stopwatch.Stop();
            square.Center = GetCenterPoint(square);
            return square;
        }
    }
}