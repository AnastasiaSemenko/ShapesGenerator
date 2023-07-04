using ShapeGenerator.Drawers;
using ShapeGenerator.Shapes;
using System.Drawing;
using Rectangle = ShapeGenerator.Shapes.Rectangle;

namespace ShapeGeneratorTests.DrawersTests
{
    [TestClass]
    public class RectangleDrawerTests
    {
        private RectangleDrawer _rectangleDrawer = new();

        [TestMethod]
        public void GetCenterPoint_Rectangle_ReturnsCorrectCenterPoint()
        {
            var rectangle = new Rectangle(10, new Point(0, 0));

            var centerPoint = ShapeDrawer.GetCenterPoint(rectangle);

            Assert.AreEqual(10, centerPoint.X);
            Assert.AreEqual(5, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_RectangleWithNegativeCoordinates_ReturnsCorrectCenterPoint()
        {
            var rectangle = new Rectangle(8, new Point(-4, -4));

            var centerPoint = ShapeDrawer.GetCenterPoint(rectangle);

            Assert.AreEqual(4, centerPoint.X);
            Assert.AreEqual(0, centerPoint.Y);
        }

        [TestMethod]
        public void GetCenterPoint_RectangleWithDifferentCoordinates_ReturnsCorrectCenterPoint()
        {
            var rectangle = new Rectangle(12, new Point(5, 10));

            var centerPoint = ShapeDrawer.GetCenterPoint(rectangle);

            Assert.AreEqual(17, centerPoint.X);
            Assert.AreEqual(16, centerPoint.Y);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsShapesWithinRadius()
        {
            var newShape = new Rectangle(10, new Point(0, 0));
            var radiusMin = 8;
            var radiusMax = 15;
            var rectangle1 = new Rectangle(8, new Point(8, 8));
            var rectangle2 = new Rectangle(12, new Point(20, 20));
            var rectangle3 = new Rectangle(7, new Point(25, 25));
            var rectangle4 = new Rectangle(18, new Point(0, 0));
            var shapes = new List<Shape>
            {
                rectangle1,
                rectangle2,
                rectangle3,
                rectangle4
            };
            var expectedShapes = new List<Shape>
            {
                rectangle1,
                rectangle4
            };

            var result = _rectangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(expectedShapes, result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsNullWhenDistanceBetweenFiguresLessRadiusMin()
        {
            var newShape = new Rectangle(10, new Point(0, 0));
            var radiusMin = 12;
            var radiusMax = 40;
            var shapes = new List<Shape>
            {
                new Rectangle(8, new Point(8, 8)),
                new Rectangle(12, new Point(20, 20)),
                new Rectangle(7, new Point(25, 25)),
                new Rectangle(18, new Point(0, 0))
            };

            var result = _rectangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetShapesInRadius_ReturnsEmptyListWhenNoShapesWithinRadiusMax()
        {
            var newShape = new Rectangle(10, new Point(0, 0));
            var radiusMin = 5;
            var radiusMax = 25;
            var shapes = new List<Shape>
            {
                new Rectangle(12, new Point(20, 20)),
                new Rectangle(7, new Point(25, 25))
            };

            var result = _rectangleDrawer.GetShapesInRadius(newShape, radiusMin, radiusMax, shapes);

            CollectionAssert.AreEqual(new List<Shape>(), result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenNoIntersection()
        {
            var shape = new Rectangle(10, new Point(100, 100));
            var shapes = new List<Shape>
            {
                new Rectangle(12, new Point(20, 20)),
                new Rectangle(7, new Point(25, 25)),
            };

            var result = _rectangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnTrue_WhenIntersectionExists()
        {
            var shape = new Rectangle(10, new Point(0, 0));
            var shapes = new List<Shape>
            {
                new Rectangle(8, new Point(8, 8)),
                new Rectangle(12, new Point(20, 20)),
                new Rectangle(7, new Point(25, 25)),
                new Rectangle(18, new Point(0, 0))
            };

            var result = _rectangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckShapeIntersection_ShouldReturnFalse_WhenEmptyShapesList()
        {
            var shape = new Triangle(10, new Point(0, 0));
            var shapes = new List<Shape>();

            var result = _rectangleDrawer.CheckShapeIntersection(shape, shapes);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPointsOnShapeBoundary_Rectangle_ReturnsCorrectPoints()
        {
            var rectangle = new Rectangle(10, new Point(0, 0));

            var pointsOnBoundary = ShapeDrawer.GetPointsOnShapeBoundary(rectangle.Points);

            Assert.AreEqual(60, pointsOnBoundary.Length);
        }
    }
}