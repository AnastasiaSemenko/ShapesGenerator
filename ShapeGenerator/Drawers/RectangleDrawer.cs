using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
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
            var point = new Point(_random.Next(maxX), _random.Next(maxY));
            var rectangle = new Rectangle(_size, point);
            var attempts = 0;

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(rectangle, shapes))
                {
                    attempts++;

                    if (attempts > maxAttempts)
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");


                    rectangle.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    rectangle.Points = rectangle.CalculatePoints();
                }
            }

            rectangle.Id = shapes.Where(x => x.GetType() == typeof(Rectangle)).Count() + 1;
            return rectangle;
        }
    }
}