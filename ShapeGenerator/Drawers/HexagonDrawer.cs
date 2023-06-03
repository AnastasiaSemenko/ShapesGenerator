using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Windows.Forms;

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
            var attempts = 0;

            if (_drawingOption != DrawingOption.Intersecting)
            {
                while (CheckShapeIntersection(hexagon, shapes))
                {
                    attempts++;

                    if (attempts > maxAttempts)
                        throw new CanvasOverflowException("There was no place for a new figure on the canvas.");

                    hexagon.StartPoint = new Point(_random.Next(maxX), _random.Next(maxY));
                    hexagon.Points = hexagon.CalculatePoints();
                }
            }

            hexagon.Id = shapes.Count(x => x.GetType() == typeof(Hexagon)) + 1;
            return hexagon;
        }
    }
}