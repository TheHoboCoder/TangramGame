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
    public partial class BDSettings : Form
    {
        public BDSettings()
        {
            InitializeComponent();
        }

        private void BDSettings_Load(object sender, EventArgs e)
        {
            userName.Text = Properties.Settings.Default["userName"].ToString();
            hostName.Text = Properties.Settings.Default["host"].ToString();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (userName.Text=="" || hostName.Text == "")
            {
                MessageBox.Show( "Заполните поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Properties.Settings.Default["userName"] = userName.Text.Trim();
            Properties.Settings.Default["host"] = hostName.Text.Trim();

            if(PasswordTB.Text!="")
            {
                if(RepassTB.Text!= PasswordTB.Text)
                {
                    MessageBox.Show( "Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Properties.Settings.Default["password"] = PasswordTB.Text.Trim();
                }
            }


            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
