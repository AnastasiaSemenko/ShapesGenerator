using Enums.ShapeGenerator;
using ShapeGenerator.Enums;
using ShapeGenerator.Shapes;
using System.Diagnostics;

namespace ShapeGenerator
{
    public class Drawer
    {
        private static PictureBox _pictureBox;
        private static int count;
        private static int size;
        private static Random random = new Random();
        private static Pen pen = new Pen(Color.Black, 2);

        private static DrawingOption _drawingOption;
        private static FigureShape _figureShape;

        public static void DrawShapes(int from, int to, FigureShape figureShape, 
            DrawingOption drawingOption, PictureBox pictureBox) 
        { 
            _drawingOption = drawingOption;
            _figureShape = figureShape;
            count = random.Next(from, to);
            _pictureBox = pictureBox;

            switch (figureShape)
            {
                case FigureShape.Square:
                    DrawSquare();
                    break;
                case FigureShape.Rectangle:
                    DrawRectangle();
                    break;
                case FigureShape.Hexagon:
                    DrawHexagon();
                    break;
                case FigureShape.Triangle:
                    DrawTriangle();
                    break;
                default:
                    Debug.WriteLine("Attempt to draw shapes of unknown type");
                    break;
            }
        }

        private static void DrawHexagon()
        {
            for (var i = 0; i < count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - size * 2;
                var maxY = _pictureBox.Height - size * 2;
                var hexagon = new Hexagon(size);
                var point = _drawingOption == DrawingOption.Intersecting ?
                    new Point(random.Next(maxX), random.Next(maxY)) :
                    SearchNonIntersect(hexagon, maxX, maxY);
                var centerX = point.X + size;
                var centerY = point.Y + size;
                var radius = size;
                var points = new PointF[6];

                for (var j = 0; j < 6; j++)
                {
                    var angle_deg = 60 * j - 30;
                    var angle_rad = Math.PI / 180 * angle_deg;
                    var x = (float)(centerX + radius * Math.Cos(angle_rad));
                    var y = (float)(centerY + radius * Math.Sin(angle_rad));
                    points[j] = new PointF(x, y);

                    switch (j)
                    {
                        case 0:
                            hexagon.PointA = new Point((int)x, (int)y);
                            break;
                        case 1:
                            hexagon.PointB = new Point((int)x, (int)y);
                            break;
                        case 2:
                            hexagon.PointC = new Point((int)x, (int)y);
                            break;
                        case 3:
                            hexagon.PointD = new Point((int)x, (int)y);
                            break;
                        case 4:
                            hexagon.PointE = new Point((int)x, (int)y);
                            break;
                        case 5:
                            hexagon.PointF = new Point((int)x, (int)y);
                            break;
                    }
                }

                var graphics = _pictureBox.CreateGraphics();
                graphics.DrawPolygon(pen, points);
                MainWindow.Shapes.Add(hexagon);
            }
        }

        private static void DrawRectangle()
        {
            for (var i = 0; i < count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - size * 2;
                var maxY = _pictureBox.Height - size;
                var rectangle = new Shapes.Rectangle(size);
                var point = _drawingOption == DrawingOption.Intersecting ?
                    new Point(random.Next(maxX), random.Next(maxY)) :
                    SearchNonIntersect(rectangle, maxX, maxY);
                var graphics = _pictureBox.CreateGraphics();
                graphics.DrawRectangle(pen, new System.Drawing.Rectangle(point.X, point.Y, size * 2, size));
                rectangle.PointA = point;
                rectangle.PointB = new Point(point.X + size * 2, point.Y);
                rectangle.PointC = new Point(point.X, point.Y + size);
                rectangle.PointD = new Point(point.X + size * 2, point.Y + size);
                MainWindow.Shapes.Add(rectangle);
            }
        }

        private static void DrawSquare()
        {
            for (var i = 0; i < count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - size;
                var maxY = _pictureBox.Height - size;
                var square = new Square(size);
                var point = _drawingOption == DrawingOption.Intersecting ?
                    new Point(random.Next(maxX), random.Next(maxY)) :
                    SearchNonIntersect(square, maxX, maxY);
                var graphics = _pictureBox.CreateGraphics();
                graphics.DrawRectangle(pen, new System.Drawing.Rectangle(point.X, point.Y, size, size));
                square.PointA = point;
                square.PointB = new Point(point.X + size, point.Y);
                square.PointC = new Point(point.X, point.Y + size);
                square.PointD = new Point(point.X + size, point.Y + size);
                MainWindow.Shapes.Add(square);
            }
        }

        private static void DrawTriangle() 
        {
            for (var i = 0; i < count; i++)
            {
                SetSize();
                var maxX = _pictureBox.Width - size;
                var maxY = (int)Math.Ceiling(_pictureBox.Height - size * Math.Sqrt(3) / 2);
                var triangle = new Triangle(size);
                var point = _drawingOption == DrawingOption.Intersecting ?
                    new Point(random.Next(maxX), random.Next(maxY)) :
                    SearchNonIntersect(triangle, maxX, maxY);
                var graphics = _pictureBox.CreateGraphics();
                triangle.PointA = new Point(point.X + size / 2, point.Y);
                triangle.PointB = new Point(point.X, point.Y + size);
                triangle.PointC = new Point(point.X + size, point.Y + size);
                graphics.DrawPolygon(pen, new[] { triangle.PointA, triangle.PointB, triangle.PointC });
                MainWindow.Shapes.Add(triangle);
            }
        }

        private static Point SearchNonIntersect(Shape shape, int maxX, int maxY) 
        {
            var point = new Point();
            bool isIntersect;

            do
            {
                isIntersect = false;
                point = new Point(random.Next(maxX), random.Next(maxY));
                
                switch (_figureShape)
                {
                    case FigureShape.Square:
                    case FigureShape.Triangle:
                        shape.Bounds = new System.Drawing.Rectangle(point.X, point.Y, size, size);
                        break;
                    case FigureShape.Rectangle:
                        shape.Bounds = new System.Drawing.Rectangle(point.X, point.Y, size * 2, size);
                        break;
                    case FigureShape.Hexagon:
                        shape.Bounds = new System.Drawing.Rectangle(point.X, point.Y, size * 2, size * 2);
                        break;
                    default:
                        Debug.WriteLine("Attempt to draw shapes of unknown type");
                        break;
                }

                foreach (var shapeItem in MainWindow.Shapes)
                {
                    if (shapeItem.Bounds.IntersectsWith(shape.Bounds))
                    {
                        isIntersect = true;
                        break;
                    }
                }
            }
            while (isIntersect);

            return point;
        }

        private static void SetSize() 
        {
            size = _drawingOption == DrawingOption.Enclosure ?
                    random.Next(10, 50) : 50;
        }
    }
}