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
    class TangramFigure : Figure
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


        public TangramFigure(FigureTypes type,Color c,PointF location)
        {
            FigureType = type;
            FigureColor = c;
            Reset(location);
            created = true;
        }

        public TangramFigure(FigureTypes type, Color c, PointF location, PointF pivot, float angle)
        {
            FigureType = type;
            FigureColor = c;
            Reset(location,pivot,angle);
            created = true;
        }

        protected override void Init(GraphicsPath p)
        {
            p.Reset();
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
                    p.AddLine(gap, 0, side+gap, 0);
                    p.AddLine(side + gap, 0, side, gap);
                    //p.AddLine(side + gap, 0, side, gap);
                    p.AddLine(side, gap, 0, gap);
                    p.AddLine(0, gap, gap, 0);
                    p.CloseFigure();
                    break;
            }
        }

       

    }
}
