using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator.Drawers
{
    public class TriangleDrawer : ShapeDrawer
    {
        public TriangleDrawer(PictureBox pictureBox, DrawingOption drawingOption) :
            base(pictureBox, drawingOption)
        {
        }

        public override Shape Draw(List<Shape> shapes)
        {
            SetSize();
            var maxX = _pictureBox.Width - _size;
            var maxY = (int)Math.Ceiling(_pictureBox.Height - _size * Math.Sqrt(3) / 2);
            var triangle = new Triangle(_size);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                var point = new Point(_random.Next(maxX), _random.Next(maxY));
                triangle.Points = new Point[] {
                        new Point(point.X + _size / 2, point.Y),
                        new Point(point.X, point.Y + _size),
                        new Point(point.X + _size, point.Y + _size) };

                if (_drawingOption == DrawingOption.Intersecting)
                    break;

                if (stopwatch.ElapsedMilliseconds > 2500)
                {
                    stopwatch.Stop();
                    Triangle.counter--;
                    throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                }
            }
            while (CheckShapeIntersection(triangle, shapes));

            stopwatch.Stop();
            triangle.Center = GetCenterPoint(triangle);
            return triangle;
        }
    }
}