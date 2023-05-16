using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;

namespace ShapeGenerator.Drawers
{
    internal class TriangleDrawer : ShapeDrawer
    {
        public override void Draw()
        {
            for (var i = 0; i < _count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - _size;
                var maxY = (int)Math.Ceiling(_pictureBox.Height - _size * Math.Sqrt(3) / 2);
                var triangle = new Triangle(_size);

                do
                {
                    var point = new Point(_random.Next(maxX), _random.Next(maxY));
                    triangle.Points = new Point[] {
                        new Point(point.X + _size / 2, point.Y),
                        new Point(point.X, point.Y + _size),
                        new Point(point.X + _size, point.Y + _size) };

                    if (_drawingOption == DrawingOption.Intersecting)
                        break;
                }
                while (CheckShapeIntersection(triangle));

                MainWindow.shapes.Add(triangle);
                _pictureBox.Invalidate();
            }
        }
    }
}
