using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tangram.GraphicsElements;

namespace UnitTests
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void FigureInitTest()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                int figureType = rnd.Next(0, 4);
                TangramFigure.FigureTypes type = (TangramFigure.FigureTypes)figureType;

                TangramFigure figure = new TangramFigure(type, System.Drawing.Color.Yellow, new System.Drawing.PointF(0, 0));

                int locationX = rnd.Next(-100, 100);
                int locationY = rnd.Next(-100, 100);
                int pivotX = rnd.Next(-100, 100);
                int pivotY = rnd.Next(-100, 100);
                int angle = rnd.Next(-359, 360);

                figure.pivot = new System.Drawing.PointF(pivotX, pivotY);

                figure.RotationAngle = angle;
                figure.Location = new System.Drawing.PointF(locationX, locationY);
             

                TangramFigure figure2 = new TangramFigure(type, System.Drawing.Color.Yellow, new System.Drawing.PointF(locationX, locationY), new System.Drawing.PointF(pivotX, pivotY), angle);
                for(int pIndex =0, count = figure.Path.PointCount; pIndex<count; pIndex++)
                {
                    if(figure.Path.PathPoints[pIndex].X!= figure2.Path.PathPoints[pIndex].X ||
                       figure.Path.PathPoints[pIndex].Y != figure2.Path.PathPoints[pIndex].Y)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
