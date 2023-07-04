using ShapeGenerator.Enums;
using ShapeGenerator.Exceptions;
using ShapeGenerator.Shapes;

namespace ShapeGenerator.Drawers
{
    public class HexagonDrawer : ShapeDrawer
    {
        public HexagonDrawer(PictureBox pictureBox, DrawingOption drawingOption) :
            base(pictureBox, drawingOption) { }

        public HexagonDrawer() : base() { }

        public override Shape Draw(List<Shape> shapes)
        {
            SetSize();
            Point? point = null;

            if (_drawingOption == DrawingOption.Intersecting)
            {
                var maxX = _pictureBox.Width - _currentSize * 2;
                var maxY = _pictureBox.Height - _currentSize * 2;
                point = new Point(_random.Next(maxX), _random.Next(maxY));
            }
            else
            {
                if (_isCanvasOverflow)
                    throw new CanvasOverflowException("No free space available for the shape.");

                if (_drawingOption == DrawingOption.NonIntersecting)
                    point = FindFreePoint(_pictureBox.Width, _pictureBox.Height, shapes);
                else
                    point = FindFreePointInEnclosureOption(_pictureBox.Width, _pictureBox.Height, shapes);

                if (point == null)
                {
                    _isCanvasOverflow = true;
                    throw new CanvasOverflowException("No free space available for the shape.");
                }
            }

            var hexagon = new Hexagon(_currentSize, (Point)point);
            hexagon.Points = hexagon.CalculatePoints();
            hexagon.Id = shapes.Count(x => x.GetType() == typeof(Hexagon)) + 1;
            MarkOccupiedArea(hexagon);

            return hexagon;
        }

        private Point? FindFreePointInEnclosureOption(int maxX, int maxY, List<Shape> shapes)
        {
            while (_maxSize >= _minSize)
            {
                var point = FindFreePoint(maxX, maxY, shapes);

                if (point == null)
                {
                    _maxSize -= 5;
                    SetSize();
                }
                else
                    return point;
            }

            return null;
        }

        private Point? FindFreePoint(int maxX, int maxY, List<Shape> shapes)
        {
            var xPoints = Enumerable.Range(0, maxX).ToList();
            var yPoints = Enumerable.Range(0, maxY).ToList();
            xPoints.Shuffle(_random);
            yPoints.Shuffle(_random);

            foreach (var x in xPoints)
            {
                foreach (var y in yPoints)
                {
                    var point = new Point(x, y);
                    var hexagon = new Hexagon(_currentSize, point);
                    var isLiquid = true;

                    foreach (var vertex in hexagon.Points)
                    {
                        if (!xPoints.Contains(hexagon.Points.Max(p => p.X)) || !yPoints.Contains(hexagon.Points.Max(p => p.Y))
                                || _occupiedGrid[vertex.X, vertex.Y] || _nonLiquidPoints.Contains(vertex))
                        {
                            isLiquid = false;
                            break;
                        }
                    }

                    if (isLiquid)
                    {
                        List<Shape>? nearShapes;

                        if (_drawingOption == DrawingOption.Enclosure)
                            nearShapes = GetShapesInRadius(hexagon, 0, 60 + _currentSize, shapes);
                        else
                            nearShapes = GetShapesInRadius(hexagon, _currentSize, _currentSize * 2, shapes);

                        if (nearShapes == null)
                            continue;

                        if (nearShapes.Count == 0 || !CheckShapeIntersection(hexagon, nearShapes))
                            return new Point(x, y);
                        else if (_drawingOption == DrawingOption.NonIntersecting)
                            _nonLiquidPoints.Add(point);
                    }
                }
            }

            return null;
        }
    }
}