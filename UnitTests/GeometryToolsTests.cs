using System;
using System.Drawing;
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

        [TestMethod]
        public void PolygonProjectionTest(){

            GeometryTools.LineEquation eq = GeometryTools.GetLineEquation(new PointF(0, 0), new PointF(1, 0));
            PointF[] firstPolygon = new PointF[4] { new PointF(0, 0), new PointF(0, 10), new PointF(7, 8), new PointF(7, 0) };
            GeometryTools.PolygonProjection projection = GeometryTools.GetProjection(firstPolygon, eq,2);

            Assert.IsTrue(projection.startPoint.Equals(new PointF(0, 0)) &&
                          projection.endPoint.Equals(new PointF(7, 0)));


            PointF[] secondPolygon = new PointF[4] { new PointF(5, 5), new PointF(10, 10), new PointF(15, 5), new PointF(10, 0) };
            GeometryTools.PolygonProjection secondProjection = GeometryTools.GetProjection(secondPolygon, eq);

            Assert.IsTrue(secondProjection.startPoint.Equals(new PointF(5, 5)) &&
                          secondProjection.endPoint.Equals(new PointF(15, 5)));
        }

        [TestMethod]
        public void IntersectionTest()
        {
            PointF[] firstPolygon = new PointF[4] { new PointF(0, 0), new PointF(-2, 2), new PointF(0, 4), new PointF(2, 2) };
            PointF[] secondPolygon = new PointF[3] { new PointF(4, 4), new PointF(1, 4), new PointF(4, 7) };
            //GeometryTools.IntersectionResult result = GeometryTools.PolygonIntersection(fisrt_projection.endPoint, second_projection.startPoint, false, fisrt_projection.endPoints, second_projection.startPoints, 1);
            GeometryTools.IntersectionResult res= GeometryTools.SAT_intersects(firstPolygon,secondPolygon,1);

            Assert.IsTrue(!res.intersects && res.snapped && res.snapPoint.Equals(new PointF(0.5F, 3.5F)));

            firstPolygon = new PointF[4] { new PointF(0, 0), new PointF(0, 4), new PointF(3, 4), new PointF(3, 0) };
            secondPolygon = new PointF[4] { new PointF(4, 4), new PointF(4, 7), new PointF(7, 7),  new PointF(7,4) };

            res = GeometryTools.SAT_intersects(firstPolygon, secondPolygon, 1);

            firstPolygon = new PointF[3] { new PointF(0, 0), new PointF(0, 4), new PointF(5, 0) };
            secondPolygon = new PointF[4] { new PointF(2, 2), new PointF(2, 4), new PointF(4, 4), new PointF(4, 2) };

            res = GeometryTools.SAT_intersects(firstPolygon, secondPolygon, 1);

            firstPolygon = new PointF[3] { new PointF(0, 0), new PointF(0, 4), new PointF(5, 0) };
            secondPolygon = new PointF[4] { new PointF(3, 2), new PointF(1, 2), new PointF(1, 4), new PointF(3, 4) };

            res = GeometryTools.SAT_intersects(firstPolygon, secondPolygon, 1);

            firstPolygon = new PointF[3] { new PointF(0, 0), new PointF(0, 4), new PointF(6, 0) };
            secondPolygon = new PointF[4] { new PointF(1, 1), new PointF(3, 1), new PointF(3, -2), new PointF(1, -2) };

            res = GeometryTools.SAT_intersects(firstPolygon, secondPolygon, 1);
        }

    }
}
