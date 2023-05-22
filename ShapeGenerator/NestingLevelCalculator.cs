using ShapeGenerator.Shapes;

namespace ShapeGenerator
{
    public class NestingLevelCalculator
    {
        public static int GetMaxNestingLevel(List<Shape> shapes)
        {
            var maxNestingLevel = 0;

            foreach (var shape in shapes)
            {
                var nestingLevel = GetNestingLevel(shape, shapes);

                if (nestingLevel > maxNestingLevel)
                    maxNestingLevel = nestingLevel;
            }

            return maxNestingLevel;
        }

        private static int GetNestingLevel(Shape shape, List<Shape> shapes)
        {
            var nestingLevel = 0;

            foreach (var otherShape in shapes)
            {
                if (otherShape != shape && IsShapeNested(shape, otherShape))
                {
                    var currentNestingLevel = GetNestingLevel(otherShape, shapes) + 1;

                    if (currentNestingLevel > nestingLevel)
                        nestingLevel = currentNestingLevel;
                }
            }

            return nestingLevel;
        }

        private static bool IsShapeNested(Shape outerShape, Shape innerShape)
        {
            foreach (var vertex in innerShape.Points)
                if (!IsPointInsideShape(vertex, outerShape))
                    return false;

            return true;
        }

        private static bool IsPointInsideShape(Point point, Shape shape)
        {
            var intersections = 0;
            var numVertices = shape.Points.Length;

            for (int i = 0, j = numVertices - 1; i < numVertices; j = i++)
                if ((shape.Points[i].Y > point.Y) != (shape.Points[j].Y > point.Y) &&
                        point.X < (shape.Points[j].X - shape.Points[i].X) * (point.Y - shape.Points[i].Y) /
                        (shape.Points[j].Y - shape.Points[i].Y) + shape.Points[i].X)
                    intersections++;

            return (intersections % 2) == 1;
        }
    }
}