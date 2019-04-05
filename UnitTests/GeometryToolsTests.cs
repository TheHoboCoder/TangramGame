using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tangram.GraphicsElements;

namespace UnitTests
{
    [TestClass]
    public class GeometryToolsTests
    {
        [TestMethod]
        public void GetLineEquationTest()
        {
            GeometryTools.LineEquation eq = GeometryTools.GetLineEquation(new System.Drawing.PointF(5, 6), new System.Drawing.PointF(7, 9));
            Assert.IsTrue(eq.Ax == 3 && eq.By == -2 && eq.C == -3);
        }
        [TestMethod]
        public void GetNormalTest()
        {
            GeometryTools.LineEquation eq = GeometryTools.GetLineEquation(new System.Drawing.PointF(5, 6), new System.Drawing.PointF(7, 9));
            GeometryTools.LineEquation normal = GeometryTools.GetNormal(eq, new System.Drawing.PointF(5, 6));
            Assert.IsTrue(normal.Ax == -2 && normal.By == -3 && normal.C == 28);
        }
        [TestMethod]
        public void GetIntersectionTest()
        {
            GeometryTools.LineEquation eq = GeometryTools.GetLineEquation(new System.Drawing.PointF(5, 6), new System.Drawing.PointF(7, 9));
            GeometryTools.LineEquation normal = GeometryTools.GetNormal(eq, new System.Drawing.PointF(5, 6));
            System.Drawing.PointF point = GeometryTools.Intersection(eq, normal);
            Assert.IsTrue(point.X == 5 && point.Y == 6);
        }

        [TestMethod]
        public void ParallelIntersection()
        {
            GeometryTools.LineEquation first = GeometryTools.GetLineEquation(new System.Drawing.PointF(1, 0), new System.Drawing.PointF(7, 0));
            GeometryTools.LineEquation second= GeometryTools.GetLineEquation(new System.Drawing.PointF(6, 0), new System.Drawing.PointF(12, 0));
            try
            {
                System.Drawing.PointF point = GeometryTools.Intersection(first, second);
                Assert.Fail();
            }
            catch (GeometryTools.LinesIsParallelException)
            {
                
            }

            GeometryTools.LineEquation eq = new GeometryTools.LineEquation();
            eq.Ax = 3;
            eq.By = -2;
            eq.C = -3;
            GeometryTools.LineEquation eq2 = new GeometryTools.LineEquation();
            eq2.Ax = 12;
            eq2.By = -8;
            eq2.C = -3;

            try
            {
                System.Drawing.PointF point = GeometryTools.Intersection(eq, eq2);
                Assert.Fail();
            }
            catch (GeometryTools.LinesIsParallelException)
            {

            }
        }
    }
}
