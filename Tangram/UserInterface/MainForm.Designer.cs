namespace Tangram.UserInterface
{
    partial class MainForm
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
            this.RootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.userName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.userProfile = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.FiguresBtn = new System.Windows.Forms.Button();
            this.StatisticsBtn = new System.Windows.Forms.Button();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.RootLayout.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootLayout
            // 
            this.RootLayout.ColumnCount = 5;
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.52709F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.448276F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.63547F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.817734F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44828F));
            this.RootLayout.Controls.Add(this.UserPanel, 0, 0);
            this.RootLayout.Controls.Add(this.FiguresBtn, 4, 4);
            this.RootLayout.Controls.Add(this.StatisticsBtn, 0, 4);
            this.RootLayout.Controls.Add(this.StartGameBtn, 2, 2);
            this.RootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootLayout.Location = new System.Drawing.Point(0, 0);
            this.RootLayout.Margin = new System.Windows.Forms.Padding(5);
            this.RootLayout.Name = "RootLayout";
            this.RootLayout.RowCount = 5;
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.94379F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.323185F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.7822F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.331378F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.24927F));
            this.RootLayout.Size = new System.Drawing.Size(774, 400);
            this.RootLayout.TabIndex = 2;
            // 
            // UserPanel
            // 
            this.RootLayout.SetColumnSpan(this.UserPanel, 2);
            this.UserPanel.Controls.Add(this.userName);
            this.UserPanel.Controls.Add(this.tableLayoutPanel1);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanel.Location = new System.Drawing.Point(3, 3);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(264, 41);
            this.UserPanel.TabIndex = 4;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Dock = System.Windows.Forms.DockStyle.Left;
            this.userName.Location = new System.Drawing.Point(0, 0);
            this.userName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(107, 23);
            this.userName.TabIndex = 3;
            this.userName.Text = "Курлык П.С.";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.userProfile, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Logout, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(156, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(108, 41);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // userProfile
            // 
            this.userProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.userProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userProfile.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfile.Image = global::Tangram.Properties.Resources.user_silhouette_small;
            this.userProfile.Location = new System.Drawing.Point(5, 5);
            this.userProfile.Margin = new System.Windows.Forms.Padding(5);
            this.userProfile.Name = "userProfile";
            this.userProfile.Size = new System.Drawing.Size(44, 31);
            this.userProfile.TabIndex = 4;
            this.userProfile.UseVisualStyleBackColor = false;
            this.userProfile.Click += new System.EventHandler(this.userProfile_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Logout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.Image = global::Tangram.Properties.Resources.logout;
            this.Logout.Location = new System.Drawing.Point(59, 5);
            this.Logout.Margin = new System.Windows.Forms.Padding(5);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(44, 31);
            this.Logout.TabIndex = 3;
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // FiguresBtn
            // 
            this.FiguresBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FiguresBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiguresBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FiguresBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FiguresBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FiguresBtn.Image = global::Tangram.Properties.Resources.shapes;
            this.FiguresBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiguresBtn.Location = new System.Drawing.Point(556, 342);
            this.FiguresBtn.Margin = new System.Windows.Forms.Padding(5);
            this.FiguresBtn.Name = "FiguresBtn";
            this.FiguresBtn.Size = new System.Drawing.Size(213, 53);
            this.FiguresBtn.TabIndex = 0;
            this.FiguresBtn.Text = "Фигуры";
            this.FiguresBtn.UseVisualStyleBackColor = false;
            // 
            // StatisticsBtn
            // 
            this.StatisticsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatisticsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StatisticsBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatisticsBtn.Image = global::Tangram.Properties.Resources.graph;
            this.StatisticsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatisticsBtn.Location = new System.Drawing.Point(5, 342);
            this.StatisticsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StatisticsBtn.Name = "StatisticsBtn";
            this.StatisticsBtn.Size = new System.Drawing.Size(234, 53);
            this.StatisticsBtn.TabIndex = 4;
            this.StatisticsBtn.Text = "Статистика";
            this.StatisticsBtn.UseVisualStyleBackColor = false;
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StartGameBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartGameBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGameBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartGameBtn.Image = global::Tangram.Properties.Resources.play_button;
            this.StartGameBtn.Location = new System.Drawing.Point(275, 77);
            this.StartGameBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(242, 226);
            this.StartGameBtn.TabIndex = 3;
            this.StartGameBtn.Text = "Начать занятие";
            this.StartGameBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StartGameBtn.UseVisualStyleBackColor = false;
            this.StartGameBtn.Click += new System.EventHandler(this.StartGameBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(774, 400);
            this.Controls.Add(this.RootLayout);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(655, 384);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RootLayout.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FiguresBtn;
        private System.Windows.Forms.TableLayoutPanel RootLayout;
        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button StatisticsBtn;
        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button userProfile;
    }
}