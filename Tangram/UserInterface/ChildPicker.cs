using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tangram.Data;
using Tangram.Data.DataModels;

namespace Tangram.UserInterface
{
    public partial class ChildPicker : Form
    {
        public ChildPicker()
        {
            InitializeComponent();
        }

        List<Child> childs;

        private void ChildPicker_Load(object sender, EventArgs e)
        {
            if (Database.Teacher_Workspace.TeacherGroup == -1)
            {
                MessageBox.Show("Воспитатель не зарегистрирован ни в одной из групп", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            for (int i = 1; i <= Database.Teacher_Workspace.SubGroupCount; i++)
            {
                subGroup.Items.Add(i + " подруппа");
            }
            subGroup.SelectedIndex = 0;

            childs = Database.Teacher_Workspace.children.OrderBy(c => c.Fam).ToList();

            foreach (Child child in childs)
            {
                childList.Items.Add(child.FullName, false);
            }
        }

        private void subGroup_DropDownClosed(object sender, EventArgs e)
        {
            if (subGroup.SelectedIndex != 0)
            {
                int i = 0;
                foreach(Child child in Database.Teacher_Workspace.children)
                {
                    childList.SetItemChecked(i, child.SubGroup == subGroup.SelectedIndex);
                    i++;
                }
                
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (childList.CheckedItems.Count > 0)
            {
                if (Database.Teacher_Workspace.BeginClass())
                {
                    Database.Teacher_Workspace.childrenInGroup = new List<Child>();

                    foreach (int index in childList.CheckedIndices)
                    {
                        Database.Teacher_Workspace.childrenInGroup.Add(childs[index]);
                    }
                    this.DialogResult = DialogResult.OK;
                    ClassControl control = new ClassControl();
                    control.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Не было выбрано ни одного ребенка. Старт занятия отменен","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Отменить начало занятия?","Отмена ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(res == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
      
    }
}
