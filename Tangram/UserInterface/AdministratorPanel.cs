﻿using System;
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
    public partial class AdministratorPanel : Form
    {
        bool userClose = false;

        private UserTableControl control;
        private GroupChildControl childGroup;


        public AdministratorPanel()
        {
            InitializeComponent();
            
        }

        private void UpdateName()
        {
            userName.Text = Database.userRepository.currentUser.Name + " " + Database.userRepository.currentUser.Otch;
        }

        private void AdministratorPanel_Load(object sender, EventArgs e)
        {
            UpdateName();
            control = new UserTableControl();
            childGroup = new GroupChildControl();
            
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            UserEdit users = new UserEdit();
            users.ShowDialog();
            UpdateName();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm(true);
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                userClose = true;
                this.Close();
            }
        }

        private void AdministratorPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!userClose)
            {
                Application.Exit();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            control.ReUpdate();
            control.Dock = DockStyle.Fill;
            TablePlace.Controls.Clear();
            TablePlace.Controls.Add(control);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            childGroup.ReUpdate();
            TablePlace.Controls.Clear();
            TablePlace.Controls.Add(childGroup);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserTypesEdit groupTypes = new UserTypesEdit();
            groupTypes.ShowDialog();
        }
    }
}