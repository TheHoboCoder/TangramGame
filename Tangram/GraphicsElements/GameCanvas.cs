using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data.DataModels;

namespace Tangram.GraphicsElements
{
    public partial class GameCanvas : UserControl
    {

        private const float SNAP_DISTANCE = 10;

        private Result.DifficultyTypes difficulty;

        private List<TangramFigure> groundFigures;
        private List<TangramFigure> placedFigures;

        public GameCanvas(TangramElement el, Result.DifficultyTypes difficulty)
        {
            InitializeComponent();
            this.Size = el.FigureSize;
            groundFigures = new List<TangramFigure>(el.Figures.Count());
            placedFigures = new List<TangramFigure>(el.Figures.Count());
            foreach (TangramFigure f in el.Figures )
            {
                groundFigures.Add((TangramFigure)f.Clone());
            }
            Refresh();
            this.AllowDrop = true;
            this.difficulty = difficulty;
        }

        public bool PlaceFigure(TangramFigure placedFigure)
        {
            TangramFigure found = null;
            foreach (TangramFigure figure in groundFigures)
            {
                if (!figure.FigureType.Equals(placedFigure.FigureType)) continue;

                int i = 0;

                foreach (PointF point in placedFigure.Path.PathPoints)
                {
                  
                    foreach (PointF p in figure.Path.PathPoints)
                    {
                        if (GeometryTools.GetDistance(point, p) <= SNAP_DISTANCE)
                        {
                            i++;
                        }
                    }
                }

                if (i >= placedFigure.Path.PathPoints.Count())
                {
                    found = figure;
                }
            }

            if(found == null)
            {
                return false;
            }
            else
            {
                groundFigures.Remove(found);
                placedFigures.Add(found);
                Refresh();
                return true;
            }
            
        }




        private void GameCanvas_Paint(object sender, PaintEventArgs e)
        {
           SolidBrush brush = new SolidBrush(Color.DimGray);
            foreach (TangramFigure figure in groundFigures)
            {
                e.Graphics.FillPath(brush, figure.Path);
                if (difficulty == Result.DifficultyTypes.CONTOUR)
                {
                    using (SolidBrush br = new SolidBrush(Color.LightGray))
                    {
                        using (Pen p = new Pen(br, 5))
                        {
                            p.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                            e.Graphics.DrawPath(p, figure.Path);
                        }
                    }

                    //using (SolidBrush br = new SolidBrush(Color.LightGray)
                    //{

                    //}

                }

            }

            foreach (TangramFigure figure in placedFigures)
            {
                brush.Color = figure.FigureColor;
                e.Graphics.FillPath(brush, figure.Path);
            }

            brush.Dispose();
        }
    }
}
