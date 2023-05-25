using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator.Drawers
{
    public class HexagonDrawer : ShapeDrawer
    {
        public HexagonDrawer(PictureBox pictureBox, DrawingOption drawingOption) :
            base(pictureBox, drawingOption)
        {
        }

        public override Shape Draw(List<Shape> shapes)
        {
            SetSize();
            var maxX = _pictureBox.Width - _size * 2;
            var maxY = _pictureBox.Height - _size * 2;
            var point = new Point(_random.Next(maxX), _random.Next(maxY));
            var hexagon = new Hexagon(_size, point);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(hexagon, shapes))
                {
                    if (stopwatch.ElapsedMilliseconds > 2500)
                    {
                        stopwatch.Stop();
                        Hexagon.counter--;
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                    }

                    hexagon.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    hexagon.Points = hexagon.CalculatePoints();
                }
            }

            stopwatch.Stop();
            return hexagon;
        }
    }
}