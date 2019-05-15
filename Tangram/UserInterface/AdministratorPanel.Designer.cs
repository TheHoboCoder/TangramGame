namespace Tangram.UserInterface
{
    partial class AdministratorPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorPanel));
            this.LoginBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.resultBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatisticsBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Logout = new System.Windows.Forms.Button();
            this.userProfile = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.TablePlace = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.SystemColors.Control;
            this.LoginBtn.Location = new System.Drawing.Point(13, 16);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(207, 53);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "Управление пользователями";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(13, 75);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(207, 53);
            this.button1.TabIndex = 6;
            this.button1.Text = "Управление группами";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(8, 0);
            this.userName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(94, 18);
            this.userName.TabIndex = 7;
            this.userName.Text = "Курлык П.С.";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resultBtn
            // 
            this.resultBtn.BackColor = System.Drawing.SystemColors.Control;
            this.resultBtn.Location = new System.Drawing.Point(13, 193);
            this.resultBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resultBtn.Name = "resultBtn";
            this.resultBtn.Size = new System.Drawing.Size(207, 53);
            this.resultBtn.TabIndex = 11;
            this.resultBtn.Text = "Просмотр результатов";
            this.resultBtn.UseVisualStyleBackColor = false;
            this.resultBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TablePlace, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.502262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.49773F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 643);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.StatisticsBtn);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1263, 55);
            this.panel1.TabIndex = 15;
            // 
            // StatisticsBtn
            // 
            this.StatisticsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatisticsBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatisticsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StatisticsBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatisticsBtn.Image = global::Tangram.Properties.Resources.graph;
            this.StatisticsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatisticsBtn.Location = new System.Drawing.Point(1029, 0);
            this.StatisticsBtn.Margin = new System.Windows.Forms.Padding(10);
            this.StatisticsBtn.Name = "StatisticsBtn";
            this.StatisticsBtn.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsBtn.Size = new System.Drawing.Size(234, 55);
            this.StatisticsBtn.TabIndex = 16;
            this.StatisticsBtn.Text = "Статистика";
            this.StatisticsBtn.UseVisualStyleBackColor = false;
            this.StatisticsBtn.Click += new System.EventHandler(this.StatisticsBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.userName);
            this.flowLayoutPanel1.Controls.Add(this.Logout);
            this.flowLayoutPanel1.Controls.Add(this.userProfile);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 55);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Logout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.Image = global::Tangram.Properties.Resources.logout;
            this.Logout.Location = new System.Drawing.Point(110, 0);
            this.Logout.Margin = new System.Windows.Forms.Padding(0);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(61, 38);
            this.Logout.TabIndex = 9;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // userProfile
            // 
            this.userProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.userProfile.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfile.Image = global::Tangram.Properties.Resources.user_silhouette_small;
            this.userProfile.Location = new System.Drawing.Point(171, 0);
            this.userProfile.Margin = new System.Windows.Forms.Padding(0);
            this.userProfile.Name = "userProfile";
            this.userProfile.Size = new System.Drawing.Size(63, 38);
            this.userProfile.TabIndex = 8;
            this.userProfile.UseVisualStyleBackColor = false;
            this.userProfile.Click += new System.EventHandler(this.userProfile_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.ButtonPanel.Controls.Add(this.button3);
            this.ButtonPanel.Controls.Add(this.LoginBtn);
            this.ButtonPanel.Controls.Add(this.button1);
            this.ButtonPanel.Controls.Add(this.resultBtn);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonPanel.Location = new System.Drawing.Point(3, 64);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(234, 576);
            this.ButtonPanel.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(13, 134);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 53);
            this.button3.TabIndex = 12;
            this.button3.Text = "Типы подрупп";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TablePlace
            // 
            this.TablePlace.AutoScroll = true;
            this.TablePlace.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.TablePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablePlace.Location = new System.Drawing.Point(244, 65);
            this.TablePlace.Margin = new System.Windows.Forms.Padding(4);
            this.TablePlace.Name = "TablePlace";
            this.TablePlace.Size = new System.Drawing.Size(1021, 574);
            this.TablePlace.TabIndex = 10;
            // 
            // AdministratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 643);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1285, 682);
            this.Name = "AdministratorPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdministratorPanel_FormClosed);
            this.Load += new System.EventHandler(this.AdministratorPanel_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button userProfile;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button resultBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel TablePlace;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StatisticsBtn;
        private System.Windows.Forms.Button button3;
    }
}