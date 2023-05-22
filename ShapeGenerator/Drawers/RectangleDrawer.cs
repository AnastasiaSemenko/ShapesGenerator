using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using System.Diagnostics;
using Rectangle = ShapeGenerator.Shapes.Rectangle;

namespace ShapeGenerator.Drawers
{
    public class RectangleDrawer : ShapeDrawer
    {
        public RectangleDrawer(PictureBox pictureBox, DrawingOption drawingOption) :
            base(pictureBox, drawingOption)
        {
        }

        public override Shape Draw(List<Shape> shapes)
        {
            SetSize();
            var maxX = _pictureBox.Width - _size * 2;
            var maxY = _pictureBox.Height - _size;
            var rectangle = new Shapes.Rectangle(_size);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                var point = new Point(_random.Next(maxX), _random.Next(maxY));
                rectangle.Points = new Point[] {
                    new Point(point.X, point.Y),
                    new Point(point.X + _size * 2, point.Y),
                    new Point(point.X + _size * 2, point.Y + _size),
                    new Point(point.X, point.Y + _size) };

                if (_drawingOption == DrawingOption.Intersecting)
                    break;

                if (stopwatch.ElapsedMilliseconds > 2500)
                {
                    stopwatch.Stop();
                    Rectangle.counter--;
                    throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                }
            }
            while (CheckShapeIntersection(rectangle, shapes));

            stopwatch.Stop();
            rectangle.Center = GetCenterPoint(rectangle);
            return rectangle;
        }
    }
}