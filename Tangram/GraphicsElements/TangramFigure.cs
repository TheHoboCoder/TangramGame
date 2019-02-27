using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangram.GraphicsElements
{
    class TangramFigure : Figure
    {
        //сторона прямоугольника, из которого состоят фигуры танграма
        protected const float RECT_WIDTH = 300.0F;

        public enum FigureTypes
        {
            BIG_TRIANGLE,
            MID_TRIANGLE,
            SMALL_TRIANGLE,
            RECT,
            PARALLELOGRAM
        }

        public FigureTypes FigureType { get; set; }


        public TangramFigure(FigureTypes type,Color c,PointF location)
        {
            FigureType = type;
            FigureColor = c;
            Reset(location);
        }

        public TangramFigure(FigureTypes type, Color c, PointF location, PointF pivot, float angle)
        {
            FigureType = type;
            FigureColor = c;
            Reset(location,pivot,angle);
        }

        protected override void Init(PointF[] boundary, GraphicsPath p)
        {
            float side = 0;
            switch (FigureType)
            {
                
                case FigureTypes.BIG_TRIANGLE:

                   side = (float)((1 / Math.Sqrt(2)) * RECT_WIDTH);

                    boundary[0] = new PointF(0, 0);
                    boundary[1] = new PointF(side, 0);
                    boundary[2] = new PointF(side, side);
                    boundary[3] = new PointF(0, side);

                    p.StartFigure();
                    p.AddLine(boundary[0], boundary[2]);
                    p.AddLine(boundary[2], boundary[3]);
                    p.AddLine(boundary[3], boundary[0]);
                    p.CloseFigure();

                    break;
                case FigureTypes.MID_TRIANGLE:

                    side = (float)(1 / 2) * RECT_WIDTH;

                    boundary[0] = new PointF(0, 0);
                    boundary[1] = new PointF(side, 0);
                    boundary[2] = new PointF(side, side);
                    boundary[3] = new PointF(0, side);

                    p.StartFigure();
                    p.AddLine(boundary[0], boundary[2]);
                    p.AddLine(boundary[2], boundary[3]);
                    p.AddLine(boundary[3], boundary[0]);
                    p.CloseFigure();
                    break;
                case FigureTypes.SMALL_TRIANGLE:
                    side = (float)((Math.Sqrt(2) / 4) * RECT_WIDTH);

                    boundary[0] = new PointF(0, 0);
                    boundary[1] = new PointF(side, 0);
                    boundary[2] = new PointF(side, side);
                    boundary[3] = new PointF(0, side);

                    p.StartFigure();
                    p.AddLine(boundary[0], boundary[2]);
                    p.AddLine(boundary[2], boundary[3]);
                    p.AddLine(boundary[3], boundary[0]);
                    p.CloseFigure();
                    break;
                case FigureTypes.RECT:

                    side = (float)((Math.Sqrt(2) / 4) * RECT_WIDTH);

                    boundary[0] = new PointF(0, 0);
                    boundary[1] = new PointF(side, 0);
                    boundary[2] = new PointF(side, side);
                    boundary[3] = new PointF(0, side);

                    p.StartFigure();
                    p.AddRectangle(new RectangleF(0, 0, side, side));
                    p.CloseFigure();

                    break;
                    //TODO
                case FigureTypes.PARALLELOGRAM:
                    break;
            }
        }
    }
}
