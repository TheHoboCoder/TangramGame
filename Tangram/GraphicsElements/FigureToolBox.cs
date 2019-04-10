﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tangram.GraphicsElements
{
    public partial class FigureToolBox : FlowLayoutPanel
    {
        private List<Figure> figures = new List<Figure>();

        private List<Bitmap> normalBitmap = new List<Bitmap>();
        private List<Bitmap> hoverBitmap = new List<Bitmap>();

        private Figure selectedFigure;
        public Figure SelectedFigure
        {
            get
            {
                return selectedFigure;
            }
        }

        private const int BRIGHTNES_SHIFT = 2;



        public void Add(Figure figure)
        {
            figures.Add(figure);

            normalBitmap.Add(figure.GetImage(figure.FigureColor));

            float hue = figure.FigureColor.GetHue();
            float saturation = figure.FigureColor.GetSaturation() ;
            float brightness = figure.FigureColor.GetBrightness() + BRIGHTNES_SHIFT;
            Color color = ColorTools.HSBtoRGG(255, hue, saturation, figure.FigureColor.GetBrightness());

            hoverBitmap.Add(figure.GetImage(ColorTools.HSBtoRGG(255, hue, saturation, brightness)));


            PictureBox figurePicture = new PictureBox();
            figurePicture.SizeMode = PictureBoxSizeMode.AutoSize;
            figurePicture.Image = normalBitmap[normalBitmap.Count()-1];

            figurePicture.MouseEnter += Figure_enter;
            figurePicture.MouseLeave += Figure_leave;
            figurePicture.MouseDown += Figure_mouse_down;

            this.Controls.Add(figurePicture);

        }


        public void Figure_enter(object c, EventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;
            int pos = Controls.IndexOf(pictureBox);
            pictureBox.Image = hoverBitmap[pos];
            pictureBox.Refresh();
        }

        public void Figure_leave(object c, EventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;
            int pos = Controls.IndexOf(pictureBox);
            pictureBox.Image =normalBitmap[pos];
            pictureBox.Refresh();
        }

        public void Figure_mouse_down(object c, MouseEventArgs e)
        {
            PictureBox pictureBox = c as PictureBox;
            int pos = Controls.IndexOf(pictureBox);
            selectedFigure = figures[pos];
            pictureBox.DoDragDrop(Controls[pos], DragDropEffects.Copy );

        }



       
        public FigureToolBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            Refresh();
        }

        private void FigureToolBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(new SolidBrush(Color.Gray), RoundedRect(this.Bounds, 20));
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}