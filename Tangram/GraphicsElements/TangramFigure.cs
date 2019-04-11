using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    [DataContract]
    public class TangramFigure : Figure
    {
        //сторона прямоугольника, из которого состоят фигуры танграма
        protected const float RECT_WIDTH = 200.0F;

        public enum FigureTypes
        {
            BIG_TRIANGLE,
            MID_TRIANGLE,
            SMALL_TRIANGLE,
            RECT,
            PARALLELOGRAM
        }

        bool created = false;
        private FigureTypes figureType;
        [DataMember]
        public FigureTypes FigureType {
            get
            {
                return figureType;
            }
            set
            {
                figureType = value;
                if (created)
                {
                    Reset(this.Location, this.pivot, this.RotationAngle);
                }
            }
        }

       
        public TangramFigure(FigureTypes type,Color c,PointF location):base(c)
        {
            FigureType = type;
            Reset(location);
            created = true;
        }

        public TangramFigure(Figure.GraphicPathData pathData, FigureTypes type, Color c, PointF location, PointF pivot, float angle):base(c)
        {
            FigureType = type;
            Reset(pathData, location, pivot, angle);
            created = true;
        }

        public TangramFigure(FigureTypes type, Color c, PointF location, PointF pivot, float angle) : base(c)
        {
            FigureType = type;
            Reset(location, pivot, angle);
            created = true;
        }

        protected override void Init(ref GraphicsPath p)
        {
            //if (p != null)
            //{
                p.Reset();
            //}
            //else
            //{
            //    p = new GraphicsPath();
                
            //}
            float side = 0;
            switch (FigureType)
            {
                
                case FigureTypes.BIG_TRIANGLE:

                   side = (float)((1 / Math.Sqrt(2)) * RECT_WIDTH);

                    p.StartFigure();
                    p.AddLine(new PointF(0, 0), new PointF(side, side));
                    p.AddLine(new PointF(side, side), new PointF(0, side));
                    p.CloseFigure();

                    break;
                case FigureTypes.MID_TRIANGLE:

                    side = 0.5F * RECT_WIDTH;

                    p.StartFigure();
                    p.AddLine(new PointF(0, 0), new PointF(side, side));
                    p.AddLine(new PointF(side, side), new PointF(0, side));
                    p.CloseFigure();

                    break;
                case FigureTypes.SMALL_TRIANGLE:
                    side = (float)((Math.Sqrt(2) / 4) * RECT_WIDTH);

                    p.StartFigure();
                    p.AddLine(new PointF(0, 0), new PointF(side, side));
                    p.AddLine(new PointF(side, side), new PointF(0, side));
                    p.CloseFigure();

                    break;
                case FigureTypes.RECT:

                    side = (float)((Math.Sqrt(2) / 4) * RECT_WIDTH);

                    p.StartFigure();
                    p.AddRectangle(new RectangleF(0, 0, side, side));
                    p.CloseFigure();

                    break;
                case FigureTypes.PARALLELOGRAM:

                    side = 0.5F * RECT_WIDTH;
                    int angle = 45;
                    float smallSide = (float)((Math.Sqrt(2) / 4) * RECT_WIDTH);
                    float gap = (float)(Math.Cos(angle) * smallSide);

                    p.StartFigure();
                    p.AddLine(0, gap, gap, 0);
                    p.AddLine(gap, 0, side+gap, 0);
                    p.AddLine(side + gap, 0, side, gap);
                    //p.AddLine(side + gap, 0, side, gap);
                    p.AddLine(side, gap, 0, gap);
                   
                    p.CloseFigure();
                    break;
            }
        }

        //public override PointF BoundaryCenter
        //{
        //    get
        //    {
        //        switch (FigureType)
        //        {
        //            case FigureTypes.RECT:
        //                return base.BoundaryCenter;
        //            case FigureTypes.BIG_TRIANGLE:
        //            case FigureTypes.MID_TRIANGLE:
        //            case FigureTypes.SMALL_TRIANGLE:
        //                PointF side1Center = new PointF((Path.PathPoints[0].X + Path.PathPoints[1].X) / 2,
        //                                                (Path.PathPoints[0].Y + Path.PathPoints[1].Y) / 2);
        //                GeometryTools.LineEquation median1 = GeometryTools.GetLineEquation(side1Center, Path.PathPoints[1]);
        //                PointF side2Center = new PointF((Path.PathPoints[1].X + Path.PathPoints[2].X) / 2,
        //                                             (Path.PathPoints[1].Y + Path.PathPoints[2].Y) / 2);
        //                GeometryTools.LineEquation median2 = GeometryTools.GetLineEquation(Path.PathPoints[0],side2Center);
        //                //return GeometryTools.Intersection(median1, median2);
        //                return base.BoundaryCenter;
        //            case FigureTypes.PARALLELOGRAM:
        //                return base.BoundaryCenter;
        //            default:
        //                return base.BoundaryCenter;
        //        }
        //    }
        //}
        public override Figure Clone()
        {
            return new TangramFigure(this.graphicPath,this.figureType, this.FigureColor, this.Location, pivot, RotationAngle);
        }
    }
}
