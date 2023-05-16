using ShapeGenerator.Enums;

namespace ShapeGenerator.Drawers
{
    public class RectangleDrawer : ShapeDrawer
    {
        public override void Draw()
        {
            for (var i = 0; i < _count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - _size * 2;
                var maxY = _pictureBox.Height - _size;
                var rectangle = new Shapes.Rectangle(_size);

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
                }
                while (CheckShapeIntersection(rectangle));

                MainWindow.shapes.Add(rectangle);
                _pictureBox.Invalidate();
            }
        }
    }
}
