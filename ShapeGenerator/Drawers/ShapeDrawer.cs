using Enums.ShapeGenerator;
using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator.Drawers
{
    public abstract class ShapeDrawer
    {
        protected static PictureBox _pictureBox;
        protected static int _count;
        protected static int _size;
        protected static Random _random = new Random();
        protected static DrawingOption _drawingOption;

        public abstract void Draw();

        public static ShapeDrawer GetDrawerForShape(int from, int to, FigureShape figureShape,
            DrawingOption drawingOption, PictureBox pictureBox)
        {
            _drawingOption = drawingOption;
            _count = _random.Next(from, to);
            _pictureBox = pictureBox;

            switch (figureShape)
            {
                case FigureShape.Square:
                    return new SquareDrawer();
                case FigureShape.Rectangle:
                    return new RectangleDrawer();
                case FigureShape.Hexagon:
                    return new HexagonDrawer();
                case FigureShape.Triangle:
                    return new TriangleDrawer();
                default:
                    Debug.WriteLine("Attempt to draw shapes of unknown type");
                    return null;
            }
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

        protected bool CheckShapeIntersection(Shape shape)
        {
            foreach (var otherShape in MainWindow.shapes)
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