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

namespace Tangram.UserInterface
{
    public partial class ChildPicker : Form
    {
        public ChildPicker()
        {
            InitializeComponent();
        }

        private void ChildPicker_Load(object sender, EventArgs e)
        {
            //for(int i = 1; i <= Database.subGroupCount; i++)
            //{
            //    subGroup.Items.Add(i + " подруппа");
            //}
            //subGroup.SelectedIndex = 0;

            //foreach (DataRow row in Database.children.Rows)
            //{
            //    childList.Items.Add(row["childName"], false);
            //}
        }

        private void subGroup_DropDownClosed(object sender, EventArgs e)
        {
            if (subGroup.SelectedIndex != 0)
            {
                int i = 0;
                //foreach (DataRow row in Database.children.Rows)
                //{
                //    childList.SetItemChecked(i, Convert.ToInt32(row["subGroup"]) == subGroup.SelectedIndex);
                //     ++i;
                //}
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (childList.CheckedItems.Count > 0)
            {
                ////string err =  Database.BeginClass();
                if (true/*err == ""*/)
                {
                    //Database.childrenInClass = Database.children.Clone();
                    //foreach (int index in childList.CheckedIndices)
                    //{
                    //    Database.childrenInClass.ImportRow(Database.children.Rows[index]);
                    //}
                    //this.DialogResult = DialogResult.OK;
                    //ClassControl control = new ClassControl();
                    //control.Show();
                    //this.Close();
                }
                else
                {
                    //MessageBox.Show(err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
