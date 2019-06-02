using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangram.UserInterface
{
    public partial class TeacherResultViewer : Form
    {
        public TeacherResultViewer()
        {
            InitializeComponent();
        }

        //Обработчик загрузки формы
        private void TeacherResultViewer_Load(object sender, EventArgs e)
        {
           
            ResultsViewer viewer = new ResultsViewer();
            this.Size = viewer.MinimumSize;
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);

        }
    }
}
