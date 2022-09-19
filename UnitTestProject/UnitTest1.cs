using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLib;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToolsDistance_between_x0y0_and_x2y2_ReturnedSqrt8()
        {
            Vertex a = new Vertex(0, 0);
            Vertex b = new Vertex(2, 2);
            int expected = (int)Math.Ceiling(Math.Sqrt(8) * 10000);

            int result = (int)Math.Ceiling(Tools.Distance(a, b) * 10000);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CircleArea_x0y0_x1y0_returnedPI()
        {
            Circle circle = new Circle(new Vertex[] { new Vertex(0, 0), new Vertex(1, 0) });
            int expected = (int)Math.Ceiling(Math.PI * 10000);

            int result = (int)Math.Ceiling(circle.GetArea() * 10000);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TriangleArea_x0y0_x0y2__x2y0_returned2()
        {
            Triangle triangle = new Triangle(new Vertex[] { new Vertex(0, 0), new Vertex(0, 2), new Vertex(2, 0) });
            int expected = 2 * 10000;

            int result = (int)Math.Ceiling(triangle.GetArea() * 10000);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TriangleArea_x0y0_x0y2__x2y0_returnedRightTriangle()
        {
            Triangle triangle = new Triangle(new Vertex[] { new Vertex(0, 0), new Vertex(0, 2), new Vertex(2, 0) });
            string expected = "Right triangle";
            Console.WriteLine(expected);

            string result = triangle.Type;

            Assert.AreEqual(expected, result);
        }
    }
}
