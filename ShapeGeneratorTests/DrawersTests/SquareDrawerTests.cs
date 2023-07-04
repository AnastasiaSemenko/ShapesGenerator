using ShapeGenerator.Drawers;
using ShapeGenerator.Shapes;
using System.Drawing;

namespace ShapeGeneratorTests.DrawersTests
{
    [TestClass]
    public class SquareDrawerTests
    {
        private SquareDrawer _squareDrawer = new();

        [TestMethod]
        public void GetCenterPoint_Square_ReturnsCorrectCenterPoint()
        {
            var square = new Square(10, new Point(0, 0));

            var centerPoint = ShapeDrawer.GetCenterPoint(square);

            Assert.AreEqual(5, centerPoint.X);
            Assert.AreEqual(5, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_SquareWithNegativeCoordinates_ReturnsCorrectCenterPoint()
        {
            var square = new Square(8, new Point(-4, -4));

            var centerPoint = ShapeDrawer.GetCenterPoint(square);

            Assert.AreEqual(0, centerPoint.X);
            Assert.AreEqual(0, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_SquareWithDifferentCoordinates_ReturnsCorrectCenterPoint()
        {
            var square = new Square(12, new Point(5, 10));

            var centerPoint = ShapeDrawer.GetCenterPoint(square);

            Assert.AreEqual(11, centerPoint.X);
            Assert.AreEqual(16, centerPoint.Y);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsShapesWithinRadius()
        {
            var newShape = new Square(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 31;
            var square1 = new Square(8, new Point(8, 8));
            var square2 = new Square(12, new Point(20, 20));
            var square3 = new Square(7, new Point(25, 25));
            var square4 = new Square(18, new Point(0, 0));
            var shapes = new List<Shape>
            {
                square1,
                square2,
                square3,
                square4
            };
            var expectedShapes = new List<Shape>
            {
                square1,
                square2,
                square4
            };

            var result = _squareDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(expectedShapes, result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsNullWhenDistanceBetweenFiguresLessRadiusMin()
        {
            var newShape = new Square(10, new Point(0, 0));
            var radiusMin = 9;
            var radiusMax = 30;
            var shapes = new List<Shape>
            {
                new Square(8, new Point(8, 8)),
                new Square(12, new Point(20, 20)),
                new Square(7, new Point(25, 25)),
                new Square(18, new Point(0, 0))
            };

            var result = _squareDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsEmptyListWhenNoShapesWithinRadiusMax()
        {
            var newShape = new Square(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 20;
            var shapes = new List<Shape>
            {
                new Square(12, new Point(20, 20)),
                new Square(7, new Point(25, 25))
            };

            var result = _squareDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(new List<Shape>(), result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenNoIntersection()
        {
            var shape = new Square(10, new Point(100, 100));
            var shapes = new List<Shape>
            {
                new Square(12, new Point(20, 20)),
                new Square(7, new Point(25, 25))
            };

            var result = _squareDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnTrue_WhenIntersectionExists()
        {
            var shape = new Square(10, new Point(0, 0));
            var shapes = new List<Shape>
            {
                new Square(8, new Point(8, 8)),
                new Square(12, new Point(20, 20)),
                new Square(7, new Point(25, 25)),
                new Square(18, new Point(0, 0))
            };

            var result = _squareDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenEmptyShapesList()
        {
            var shape = new Square(10, new Point(0, 0));
            var shapes = new List<Shape>();

            var result = _squareDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPointsOnShapeBoundary_Square_ReturnsCorrectPoints()
        {
            var square = new Square(10, new Point(0, 0));

            var pointsOnBoundary = ShapeDrawer.GetPointsOnShapeBoundary(square.Points);

            Assert.AreEqual(40, pointsOnBoundary.Length);
        }
    }
}