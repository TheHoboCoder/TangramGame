using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.GraphicsElements;

namespace Tangram
{
    public partial class TestForm3 : Form
    {
        public TestForm3()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = colorPreview.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            colorPreview.BackColor = colorDialog1.Color;
        }

        private void TestForm3_Load(object sender, EventArgs e)
        {
            figureTypeCombo.Items.Add("Большой треугольник");
            figureTypeCombo.Items.Add("Средний треугольник");
            figureTypeCombo.Items.Add("Маленький треугольник");
            figureTypeCombo.Items.Add("Квадрат");
            figureTypeCombo.Items.Add("Параллелограмм");
            figureTypeCombo.SelectedIndex = 0;

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            TangramFigure.FigureTypes type = TangramFigure.FigureTypes.BIG_TRIANGLE;
            switch (figureTypeCombo.SelectedIndex) {
                case 0:
                    type = TangramFigure.FigureTypes.BIG_TRIANGLE;
                    break;
                case 1:
                    type = TangramFigure.FigureTypes.MID_TRIANGLE;
                    break;
                case 2:
                    type = TangramFigure.FigureTypes.SMALL_TRIANGLE;
                    break;
                case 3:
                    type = TangramFigure.FigureTypes.RECT;
                    break;
                case 4:
                    type = TangramFigure.FigureTypes.PARALLELOGRAM;
                    break;
            }

            designerCanvas1.AddFigure(new TangramFigure(type, colorPreview.BackColor, designerCanvas1.Location));

        }

        private void TestForm3_FormClosed(object sender, FormClosedEventArgs e)
        {
            //designerCanvas1.Dispose();
        }
    }
}
