using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;

namespace ShapeGenerator.Drawers
{
    public abstract class ShapeDrawer
    {
        protected PictureBox _pictureBox;
        protected int _size;
        protected DrawingOption _drawingOption;
        protected Random _random = new();

        public ShapeDrawer(PictureBox pictureBox, DrawingOption drawingOption)
        {
            _pictureBox = pictureBox;
            _drawingOption = drawingOption;
        }

        public abstract Shape Draw(List<Shape> shapes);

        protected Point GetCenterPoint(Shape shape) 
        {
            int sumX = 0;
            int sumY = 0;

            foreach (Point vertex in shape.Points)
            {
                sumX += vertex.X;
                sumY += vertex.Y;
            }

            int centerX = sumX / shape.Points.Length;
            int centerY = sumY / shape.Points.Length;

            return new Point(centerX, centerY);
        }

        protected bool Intersection(Point pointA1, Point pointA2, Point pointB1, Point pointB2)
        {
            var d1 = Direction(pointB1, pointB2, pointA1);
            var d2 = Direction(pointB1, pointB2, pointA2);
            var d3 = Direction(pointA1, pointA2, pointB1);
            var d4 = Direction(pointA1, pointA2, pointB2);
            bool segmentsIntersect = ((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) &&
                                     ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0));
            bool endpointsOverlap = IsPointOnSegment(pointA1, pointB1, pointB2) ||
                                    IsPointOnSegment(pointA2, pointB1, pointB2) ||
                                    IsPointOnSegment(pointB1, pointA1, pointA2) ||
                                    IsPointOnSegment(pointB2, pointA1, pointA2);

            return segmentsIntersect || endpointsOverlap;
        }

        protected int Direction(Point p1, Point p2, Point p3)
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y);
        }

        protected bool IsPointOnSegment(Point point, Point segmentStart, Point segmentEnd)
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

        protected bool CheckShapeIntersection(Shape shape, List<Shape> shapes)
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
            _size = _drawingOption == DrawingOption.Enclosure ? _random.Next(10, 60) : 50;
        }
    }
}