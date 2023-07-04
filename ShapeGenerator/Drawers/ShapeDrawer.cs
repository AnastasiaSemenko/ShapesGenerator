using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;

namespace ShapeGenerator.Drawers
{
    public abstract class ShapeDrawer
    {
        protected PictureBox _pictureBox;
        protected DrawingOption _drawingOption;
        protected Random _random = new();

        protected static HashSet<Point> _nonLiquidPoints = new ();
        protected static int _currentSize;
        protected static int _minSize = 10;
        protected static int _maxSize = 60;
        protected static int _defaultSize = 50;
        protected static bool _isCanvasOverflow;
        protected static bool[,]? _occupiedGrid = null;

        public ShapeDrawer(PictureBox pictureBox, DrawingOption drawingOption)
        {
            _pictureBox = pictureBox;
            _drawingOption = drawingOption;
            _occupiedGrid ??= new bool[_pictureBox.Width, _pictureBox.Height];
        }

        public ShapeDrawer() { }

        public abstract Shape Draw(List<Shape> shapes);

        public static Point GetCenterPoint(Shape shape)
        {
            var sumX = 0;
            var sumY = 0;

            foreach (Point vertex in shape.Points)
            {
                sumX += vertex.X;
                sumY += vertex.Y;
            }

            var centerX = sumX / shape.Points.Length;
            var centerY = sumY / shape.Points.Length;

            return new Point(centerX, centerY);
        }

        public List<Shape>? GetShapesInRadius(Shape newShape, int radiusMin, int radiusMax, List<Shape> shapes)
        {
            var shapesInRadius = new List<Shape>();

            foreach (var shape in shapes)
            {
                var distance = CalculateDistance(GetCenterPoint(shape), GetCenterPoint(newShape));

                if (distance < radiusMin)
                    return null;
                else if (distance <= radiusMax)
                    shapesInRadius.Add(shape);
            }

            return shapesInRadius;
        }

        private double CalculateDistance(Point point1, Point point2)
        {
            var dx = point2.X - point1.X;
            var dy = point2.Y - point1.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private bool Intersection(Point pointA1, Point pointA2, Point pointB1, Point pointB2)
        {
            var d1 = Direction(pointB1, pointB2, pointA1);
            var d2 = Direction(pointB1, pointB2, pointA2);
            var d3 = Direction(pointA1, pointA2, pointB1);
            var d4 = Direction(pointA1, pointA2, pointB2);
            var segmentsIntersect = ((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
                                     ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0));
            var endpointsOverlap = IsPointOnSegment(pointA1, pointB1, pointB2) ||
                                    IsPointOnSegment(pointA2, pointB1, pointB2) ||
                                    IsPointOnSegment(pointB1, pointA1, pointA2) ||
                                    IsPointOnSegment(pointB2, pointA1, pointA2);

            return segmentsIntersect || endpointsOverlap;
        }

        private int Direction(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y);
        }

        private bool IsPointOnSegment(Point point, Point segmentStart, Point segmentEnd)
        {
            var v1 = new Point(segmentEnd.X - segmentStart.X, segmentEnd.Y - segmentStart.Y);
            var v2 = new Point(point.X - segmentStart.X, point.Y - segmentStart.Y);
            var crossProduct = v1.X * v2.Y - v1.Y * v2.X;

            if (crossProduct == 0)
                return point.X >= Math.Min(segmentStart.X, segmentEnd.X) &&
                       point.X <= Math.Max(segmentStart.X, segmentEnd.X) &&
                       point.Y >= Math.Min(segmentStart.Y, segmentEnd.Y) &&
                       point.Y <= Math.Max(segmentStart.Y, segmentEnd.Y);

            return false;
        }

        public bool CheckShapeIntersection(Shape shape, List<Shape> shapes)
        {
            foreach (var otherShape in shapes)
            {
                for (var i = 0; i < shape.Points.Length; i++)
                {
                    var pointA1 = shape.Points[i];
                    var pointA2 = shape.Points[(i + 1) % shape.Points.Length];

                    for (var j = 0; j < otherShape.Points.Length; j++)
                    {
                        var pointB1 = otherShape.Points[j];
                        var pointB2 = otherShape.Points[(j + 1) % otherShape.Points.Length];

                        if (Intersection(pointA1, pointA2, pointB1, pointB2))
                            return true;
                    }
                }
            }

            return false;
        }

        protected void SetSize()
        {
            _currentSize = _drawingOption == DrawingOption.Enclosure ? _random.Next(_minSize, _maxSize) : _defaultSize;
        }

        public static void InitializeOccupiedGrid(int maxX, int maxY, List<Shape> shapes, DrawingOption? drawingOption = null)
        {
            if (shapes == null)
            {
                _occupiedGrid = new bool[maxX, maxY];
                return;
            }
                
            _occupiedGrid ??= new bool[maxX, maxY];

            foreach (var shape in shapes)
            {
                Point[]? occupiedPoints = null;

                if (drawingOption == null || drawingOption == DrawingOption.Intersecting)
                    return;
                else if (drawingOption == DrawingOption.Enclosure)
                    occupiedPoints = GetPointsOnShapeBoundary(shape.Points);
                else if (drawingOption == DrawingOption.NonIntersecting)
                    occupiedPoints = GetPointsInsideShape(shape.Points);

                foreach (var point in occupiedPoints)
                    _occupiedGrid[point.X, point.Y] = true;
            }
        }

        public static Point[] GetPointsOnShapeBoundary(Point[] vertices)
        {
            var pointsOnBoundary = new List<Point>();

            for (var i = 0; i < vertices.Length; i++)
            {
                var currentVertex = vertices[i];
                var nextVertex = vertices[(i + 1) % vertices.Length];
                var diffX = Math.Abs(nextVertex.X - currentVertex.X);
                var diffY = Math.Abs(nextVertex.Y - currentVertex.Y);
                var maxDiff = Math.Max(diffX, diffY);

                for (var j = 0; j <= maxDiff; j++)
                {
                    var x = currentVertex.X + j * (nextVertex.X - currentVertex.X) / maxDiff;
                    var y = currentVertex.Y + j * (nextVertex.Y - currentVertex.Y) / maxDiff;
                    var boundaryPoint = new Point { X = x, Y = y };

                    if (pointsOnBoundary.Any(p => p.X == x && p.Y == y))
                        continue;

                    pointsOnBoundary.Add(boundaryPoint);
                }
            }

            return pointsOnBoundary.ToArray();
        }

        private static Point[] GetPointsInsideShape(Point[] vertices)
        {
            var pointsInsideShape = new List<Point>();
            var minX = vertices.Min(p => p.X);
            var maxX = vertices.Max(p => p.X);
            var minY = vertices.Min(p => p.Y);
            var maxY = vertices.Max(p => p.Y);

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var currentPoint = new Point { X = x, Y = y };

                    if (IsPointInsideShape(vertices, currentPoint))
                        pointsInsideShape.Add(currentPoint);
                }
            }

            return pointsInsideShape.ToArray();
        }

        private static bool IsPointInsideShape(Point[] vertices, Point point)
        {
            var n = vertices.Length;
            var isInside = false;

            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                if ((vertices[i].Y > point.Y) != (vertices[j].Y > point.Y) &&
                    point.X <= Math.Max(vertices[i].X, vertices[j].X) &&
                    point.Y <= Math.Max(vertices[i].Y, vertices[j].Y) &&
                    vertices[i].X + (point.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) * (vertices[j].X - vertices[i].X) <= point.X)
                {
                    isInside = !isInside;
                }
            }

            return isInside;
        }

        public static void ResetSize()
        {
            _minSize = 10;
            _maxSize = 60;
            _defaultSize = 50;
        }

        public static void ResetNonLiquidPoints()
        {
            _nonLiquidPoints.Clear();
        }

        protected void MarkOccupiedArea(Shape shape)
        {
            Point[] occupiedPoints;

            if (_drawingOption == DrawingOption.Enclosure)
                occupiedPoints = GetPointsOnShapeBoundary(shape.Points);
            else
                occupiedPoints = GetPointsInsideShape(shape.Points);

            foreach (var point in occupiedPoints)
                _occupiedGrid[point.X, point.Y] = true;
        }
    }
}