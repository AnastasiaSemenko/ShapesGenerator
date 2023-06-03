using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
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
            var point = new Point(_random.Next(maxX), _random.Next(maxY));
            var square = new Square(_size, point);
            var attempts = 0;

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(square, shapes))
                {
                    attempts++;

                    if (attempts > maxAttempts)
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");


                    square.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    square.Points = square.CalculatePoints();
                }
            }

            square.Id = shapes.Where(x => x.GetType() == typeof(Square)).Count() + 1;
            return square;
        }
    }
}