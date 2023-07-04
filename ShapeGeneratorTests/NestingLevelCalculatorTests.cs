using ShapeGenerator.Shapes;
using System.Drawing;

namespace ShapeGeneratorTests
{
    [TestClass]
    public class NestingLevelCalculatorTests
    {
        [TestMethod]
        public void TestGetMaxNestingLevel_EmptyList_ShouldReturnZero()
        {
            var shapes = new List<Shape>();

            var maxNestingLevel = NestingLevelCalculator.GetMaxNestingLevel(shapes);

            Assert.AreEqual(0, maxNestingLevel);
        }

        [TestMethod]
        public void TestGetMaxNestingLevel_SingleShape_ShouldReturnZero()
        {
            var shapes = new List<Shape>
            {
                new Triangle(10, new Point(0, 0)),
            };

            var maxNestingLevel = NestingLevelCalculator.GetMaxNestingLevel(shapes);

            Assert.AreEqual(0, maxNestingLevel);
        }

        [TestMethod]
        public void TestGetMaxNestingLevel_SimpleNestedShapes_ShouldReturnOne()
        {
            var shapes = new List<Shape>
            {
                new ShapeGenerator.Shapes.Rectangle(20, new Point(0, 0)),
                new Square(7, new Point(2, 2)),
            };

            var maxNestingLevel = NestingLevelCalculator.GetMaxNestingLevel(shapes);

            Assert.AreEqual(1, maxNestingLevel);
        }

        [TestMethod]
        public void TestGetMaxNestingLevel_ComplexNestedShapes_ShouldReturnTwo()
        {
            var shapes = new List<Shape>
            {
                new Hexagon(25, new Point(0, 0)),
                new Square(8, new Point(15, 15)),
                new Triangle(3, new Point(17, 17)),
            };

            var maxNestingLevel = NestingLevelCalculator.GetMaxNestingLevel(shapes);

            Assert.AreEqual(2, maxNestingLevel);
        }
    }
}