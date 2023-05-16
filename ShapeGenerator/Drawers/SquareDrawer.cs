using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;

namespace ShapeGenerator.Drawers
{
    public class SquareDrawer : ShapeDrawer
    {
        public override void Draw()
        {
            for (var i = 0; i < _count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - _size;
                var maxY = _pictureBox.Height - _size;
                var square = new Square(_size);

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
                }
                while (CheckShapeIntersection(square));

                MainWindow.shapes.Add(square);
                _pictureBox.Invalidate();
            }
        }
    }
}
