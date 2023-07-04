using ShapeGenerator.Drawers;
using ShapeGenerator.Shapes;
using System.Drawing;

namespace ShapeGeneratorTests.DrawersTests
{
    [TestClass]
    public class TriangleDrawerTests
    {
        private TriangleDrawer _triangleDrawer = new();

        [TestMethod]
        public void GetCenterPoint_Triangle_ReturnsCorrectCenterPoint()
        {
            var triangle = new Triangle(10, new Point(0, 0));

            var centerPoint = ShapeDrawer.GetCenterPoint(triangle);

            Assert.AreEqual(5, centerPoint.X);
            Assert.AreEqual(6, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_TriangleWithNegativeCoordinates_ReturnsCorrectCenterPoint()
        {
            var triangle = new Triangle(8, new Point(-4, -4));

            var centerPoint = ShapeDrawer.GetCenterPoint(triangle);

            Assert.AreEqual(0, centerPoint.X);
            Assert.AreEqual(1, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_TriangleWithDifferentCoordinates_ReturnsCorrectCenterPoint()
        {
            var triangle = new Triangle(12, new Point(5, 10));

            var centerPoint = ShapeDrawer.GetCenterPoint(triangle);

            Assert.AreEqual(11, centerPoint.X);
            Assert.AreEqual(18, centerPoint.Y);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsShapesWithinRadius()
        {
            var newShape = new Triangle(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 20;
            var triangle1 = new Triangle(8, new Point(8, 8));
            var triangle2 = new Triangle(12, new Point(20, 20));
            var triangle3 = new Triangle(7, new Point(25, 25));
            var triangle4 = new Triangle(18, new Point(0, 0));
            var shapes = new List<Shape>
            {
                triangle1,
                triangle2,
                triangle3,
                triangle4
            };
            var expectedShapes = new List<Shape>
            {
                triangle1,
                triangle4
            };

            var result = _triangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(expectedShapes, result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsNullWhenDistanceBetweenFiguresLessRadiusMin()
        {
            var newShape = new Triangle(10, new Point(0, 0));
            var radiusMin = 8;
            var radiusMax = 20;
            var shapes = new List<Shape>
            {
                new Triangle(8, new Point(8, 8)),
                new Triangle(12, new Point(20, 20)),
                new Triangle(7, new Point(25, 25)),
                new Triangle(18, new Point(0, 0))
            };

            var result = _triangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsEmptyListWhenNoShapesWithinRadiusMax()
        {
            var newShape = new Triangle(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 8;
            var shapes = new List<Shape>
            {
                new Triangle(8, new Point(8, 8)),
                new Triangle(12, new Point(20, 20)),
                new Triangle(7, new Point(25, 25))
            };

            var result = _triangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(new List<Shape>(), result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenNoIntersection()
        {
            var shape = new Triangle(10, new Point(100, 100));
            var shapes = new List<Shape>
            {
                new Triangle(8, new Point(8, 8)),
                new Triangle(12, new Point(20, 20)),
                new Triangle(7, new Point(25, 25))
            };

            var result = _triangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnTrue_WhenIntersectionExists()
        {
            var shape = new Triangle(10, new Point(0, 0));
            var shapes = new List<Shape>
            {
                new Triangle(8, new Point(8, 8)),
                new Triangle(12, new Point(20, 20)),
                new Triangle(7, new Point(25, 25)),
                new Triangle(18, new Point(0, 0))
            };

            var result = _triangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenEmptyShapesList()
        {
            var shape = new Triangle(10, new Point(0, 0));
            var shapes = new List<Shape>();

            var result = _triangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPointsOnShapeBoundary_Triangle_ReturnsCorrectPoints()
        {
            var triangle = new Triangle(10, new Point(0, 0));

            var pointsOnBoundary = ShapeDrawer.GetPointsOnShapeBoundary(triangle.Points);

            Assert.AreEqual(30, pointsOnBoundary.Length);
        }
    }
}