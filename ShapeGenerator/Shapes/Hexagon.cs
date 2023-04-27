namespace ShapeGenerator.Shapes
{
    public class Hexagon : Shape
    {
        public Point PointA { get; private set; }
        public Point PointB { get; private set; }
        public Point PointC { get; private set; }
        public Point PointD { get; private set; }
        public Point PointF { get; private set; }
        public Point PointE { get; private set; }
        public int Size { get; }

        public Hexagon(int size)
        {
            Size = size;
            Name = $"Шестиугольник {MainWindow.shapes.Where(x => x.GetType() == typeof(Hexagon)).Count() + 1}";
        }

        public override void Draw(Point point, Graphics graphics)
        {
            float centerX = point.X + Size;
            float centerY = point.Y + Size;
            float radius = Size;
            PointF[] points = new PointF[6];

            for (int i = 0; i < 6; i++)
            {
                double angle_deg = 60 * i - 30;
                double angle_rad = Math.PI / 180 * angle_deg;
                float x = (float)(centerX + radius * Math.Cos(angle_rad));
                float y = (float)(centerY + radius * Math.Sin(angle_rad));
                points[i] = new PointF(x, y);

                switch (i)
                {
                    case 0:
                        PointA = new Point((int)x, (int)y);
                        break;
                    case 1:
                        PointB = new Point((int)x, (int)y);
                        break;
                    case 2:
                        PointC = new Point((int)x, (int)y);
                        break;
                    case 3:
                        PointD = new Point((int)x, (int)y);
                        break;
                    case 4:
                        PointE = new Point((int)x, (int)y);
                        break;
                    case 5:
                        PointF = new Point((int)x, (int)y);
                        break;
                }
            }

            graphics.DrawPolygon(Pen, points);
        }

        public override string ToString()
        {
            return $"{Name}:\n{PointA.X} {PointA.Y} {PointB.X} {PointB.Y} {PointC.X} {PointC.Y} " +
                $"{PointD.X} {PointD.Y} {PointE.X} {PointE.Y} {PointF.X} {PointF.Y}";
        }
    }
}