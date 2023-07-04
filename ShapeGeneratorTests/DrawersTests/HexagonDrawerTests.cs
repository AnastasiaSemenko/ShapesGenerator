using ShapeGenerator.Drawers;
using ShapeGenerator.Shapes;
using System.Drawing;

namespace ShapeGeneratorTests.DrawersTests
{
    [TestClass]
    public class HexagonDrawerTests
    {
        private HexagonDrawer _hexagonDrawer = new();

        [TestMethod]
        public void GetCenterPoint_Hexagon_ReturnsCorrectCenterPoint()
        {
            var hexagon = new Hexagon(10, new Point(0, 0));

            var centerPoint = ShapeDrawer.GetCenterPoint(hexagon);

            Assert.AreEqual(10, centerPoint.X);
            Assert.AreEqual(10, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_HexagonWithNegativeCoordinates_ReturnsCorrectCenterPoint()
        {
            var hexagon = new Hexagon(8, new Point(-4, -4));

            var centerPoint = ShapeDrawer.GetCenterPoint(hexagon);

            Assert.AreEqual(4, centerPoint.X);
            Assert.AreEqual(4, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_HexagonWithDifferentCoordinates_ReturnsCorrectCenterPoint()
        {
            var hexagon = new Hexagon(12, new Point(5, 10));

            var centerPoint = ShapeDrawer.GetCenterPoint(hexagon);

            Assert.AreEqual(17, centerPoint.X);
            Assert.AreEqual(22, centerPoint.Y);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsShapesWithinRadius()
        {
            var newShape = new Hexagon(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 15;
            var hexagon1 = new Hexagon(8, new Point(8, 8));
            var hexagon2 = new Hexagon(12, new Point(20, 20));
            var hexagon3 = new Hexagon(7, new Point(25, 25));
            var hexagon4 = new Hexagon(18, new Point(0, 0));
            var shapes = new List<Shape>
            {
                hexagon1,
                hexagon2,
                hexagon3,
                hexagon4
            };
            var expectedShapes = new List<Shape>
            {
                hexagon1,
                hexagon4
            };

            var result = _hexagonDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(expectedShapes, result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsNullWhenDistanceBetweenFiguresLessRadiusMin()
        {
            var newShape = new Hexagon(10, new Point(0, 0));
            var radiusMin = 15;
            var radiusMax = 20;
            var shapes = new List<Shape>
            {
                new Hexagon(8, new Point(5, 5)),
                new Hexagon(12, new Point(20, 20)),
                new Hexagon(6, new Point(3, 3)),
                new Hexagon(18, new Point(10, 10)),
                new Hexagon(7, new Point(25, 25))
            };

            var result = _hexagonDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsEmptyListWhenNoShapesWithinRadiusMax()
        {
            var newShape = new Hexagon(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 8;
            var shapes = new List<Shape>
            {
                new Hexagon(12, new Point(20, 20)),
                new Hexagon(18, new Point(10, 10)),
                new Hexagon(7, new Point(25, 25))
            };

            var result = _hexagonDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(new List<Shape>(), result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenNoIntersection()
        {
            var shape = new Hexagon(10, new Point(100, 100));
            var shapes = new List<Shape>
            {
                new Hexagon(10, new Point(0, 0)),
                new Hexagon(10, new Point(20, 20)),
                new Hexagon(10, new Point(40, 40))
            };

            var result = _hexagonDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnTrue_WhenIntersectionExists()
        {
            var shape = new Hexagon(10, new Point(0, 0));
            var shapes = new List<Shape>
            {
                new Hexagon(10, new Point(0, 0)),
                new Hexagon(10, new Point(20, 20)),
                new Hexagon(10, new Point(10, 10))
            };

            var result = _hexagonDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenEmptyShapesList()
        {
            var shape = new Hexagon(10, new Point(0, 0));
            var shapes = new List<Shape>();

            var result = _hexagonDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPointsOnShapeBoundary_Hexagon_ReturnsCorrectPoints()
        {
            var hexagon = new Hexagon(10, new Point(0, 0));

            var pointsOnBoundary = ShapeDrawer.GetPointsOnShapeBoundary(hexagon.Points);

            Assert.AreEqual(52, pointsOnBoundary.Length);
        }
    }
}