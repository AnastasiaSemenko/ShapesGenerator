using ShapeGenerator.Enums;
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
            var hexagon = new Hexagon(_size);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                var point = new Point(_random.Next(maxX), _random.Next(maxY));

                for (var j = 0; j < 6; j++)
                {
                    var centerX = point.X + _size;
                    var centerY = point.Y + _size;
                    var angle_deg = 60 * j - 30;
                    var angle_rad = Math.PI / 180 * angle_deg;
                    var x = (int)(centerX + _size * Math.Cos(angle_rad));
                    var y = (int)(centerY + _size * Math.Sin(angle_rad));
                    hexagon.Points[j] = new Point(x, y);
                }

                if (_drawingOption == DrawingOption.Intersecting)
                    break;

                if (stopwatch.ElapsedMilliseconds > 2500)
                {
                    stopwatch.Stop();
                    Hexagon.counter--;
                    throw new CanvasOverflowException("There was no place for a new figure on the canvas.");
                }
            }
            while (CheckShapeIntersection(hexagon, shapes));

            stopwatch.Stop();
            hexagon.Center = GetCenterPoint(hexagon);
            return hexagon;
        }
    }
}