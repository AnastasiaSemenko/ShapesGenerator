using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
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
            var point = new Point(_random.Next(maxX), _random.Next(maxY));
            var triangle = new Triangle(_size, point);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(triangle, shapes))
                {
                    if (stopwatch.ElapsedMilliseconds > 2500)
                    {
                        stopwatch.Stop();
                        Triangle.counter--;
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                    }

                    triangle.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    triangle.Points = triangle.CalculatePoints();
                }
            }
            
            stopwatch.Stop();
            return triangle;
        }
    }
}