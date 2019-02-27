using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangram
{

    public partial class Form1 : Form
    {
        private GraphicsPath figure,figure2;
        private Matrix m;
        private Matrix r;
        Point lastPosition;
        Point curPos;
        bool moving = false;

        public Form1()
        {
            InitializeComponent();
            figure = new GraphicsPath();
            figure.AddRectangle(new Rectangle(0, 0, 100, 100));
            m = new Matrix();
            r = new Matrix();
            curPos = new Point(0,0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(new SolidBrush(Color.Yellow), figure);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2),(int) Math.Round(figure.GetBounds().X),
                                                                             (int)Math.Round(figure.GetBounds().Y), 
                                                                             (int)Math.Round(figure.GetBounds().Width), 
             
                                                                             (int)Math.Round(figure.GetBounds().Height));
            if(figure2!=null)
            {
                e.Graphics.FillPath(new SolidBrush(Color.Blue), figure2);
                //    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), (int)Math.Round(figure.GetBounds().X),
                //                                                                (int)Math.Round(figure.GetBounds().Y),
                //                                                                (int)Math.Round(figure.GetBounds().Width),
                //                                                                (int)Math.Round(figure.GetBounds().Height));
            }

            Rectangle rect = new Rectangle();
            rect.X = Convert.ToInt32(figure.PathPoints[0].X);
            rect.Y = Convert.ToInt32(figure.PathPoints[0].Y);
            rect.Width =rect.Height= 30;

            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Aquamarine), 2), rect);
            e.Graphics.DrawString(curPos.X.ToString() + ";"+curPos.Y.ToString(), this.Font, new SolidBrush(Color.Black), 0, 0);
            e.Graphics.DrawString(lastPosition.X.ToString() + ";" + lastPosition.Y.ToString(), this.Font, new SolidBrush(Color.Black), 0, 20);
            e.Graphics.Dispose();
            
            
        }

        private void RotateBtn_Click(object sender, EventArgs e)
        {
            m.Reset();
            PointF centerPoint = new PointF(figure.GetBounds().Width / 2 + figure.GetBounds().X,
                                          figure.GetBounds().Height / 2 + figure.GetBounds().Y);
            m.RotateAt((float)numericUpDown1.Value,centerPoint);
            //figure.Reset();
            //figure.AddRectangle(new Rectangle(0, 0, 100, 100));
            figure.Transform(m);
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (figure.IsVisible(e.Location)&&!moving)
            {
                lastPosition = e.Location;
                moving = true;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left&&moving)
            {
                curPos.X = (e.Location.X - lastPosition.X);
                curPos.Y = (e.Location.Y - lastPosition.Y);
                m.Reset();
                m.Translate(curPos.X,curPos.Y);
                figure.Transform(m);
                Invalidate();
                lastPosition.X = e.Location.X;
                lastPosition.Y = e.Location.Y;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            figure2 = new GraphicsPath();
            figure2.AddRectangle(new Rectangle(0, 0, 100, 100));
            r.Reset();
            r.Translate(figure.GetBounds().X, figure.GetBounds().Y);
            PointF centerPoint = new PointF(figure2.GetBounds().Width / 2 + figure2.GetBounds().X,
                                          figure2.GetBounds().Height / 2 + figure2.GetBounds().Y);

            r.RotateAt((float)numericUpDown1.Value, centerPoint);
            figure2.Transform(r);
            //figure2.Transform(m);
            //figure2 = (GraphicsPath)figure.Clone();
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (figure2 != null)
            {
                figure2.Dispose();
                figure2 = null;
                Invalidate();
            }
        }
    }
}
