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
            this.FiguresBtn = new System.Windows.Forms.Button();
            this.RootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.userName = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.StatisticsBtn = new System.Windows.Forms.Button();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.RootLayout.SuspendLayout();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FiguresBtn
            // 
            this.FiguresBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FiguresBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiguresBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FiguresBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FiguresBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FiguresBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiguresBtn.ImageIndex = 0;
            this.FiguresBtn.Location = new System.Drawing.Point(568, 354);
            this.FiguresBtn.Margin = new System.Windows.Forms.Padding(5);
            this.FiguresBtn.Name = "FiguresBtn";
            this.FiguresBtn.Size = new System.Drawing.Size(180, 54);
            this.FiguresBtn.TabIndex = 0;
            this.FiguresBtn.Text = "Фигуры";
            this.FiguresBtn.UseVisualStyleBackColor = false;
            // 
            // RootLayout
            // 
            this.RootLayout.ColumnCount = 5;
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.17466F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.940276F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.75855F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.077506F));
            this.RootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.04902F));
            this.RootLayout.Controls.Add(this.UserPanel, 0, 0);
            this.RootLayout.Controls.Add(this.FiguresBtn, 4, 4);
            this.RootLayout.Controls.Add(this.StatisticsBtn, 0, 4);
            this.RootLayout.Controls.Add(this.StartGameBtn, 2, 2);
            this.RootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootLayout.Location = new System.Drawing.Point(0, 0);
            this.RootLayout.Margin = new System.Windows.Forms.Padding(5);
            this.RootLayout.Name = "RootLayout";
            this.RootLayout.RowCount = 5;
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.21945F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.72818F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.3591F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.331378F));
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.24927F));
            this.RootLayout.Size = new System.Drawing.Size(753, 413);
            this.RootLayout.TabIndex = 2;
            // 
            // UserPanel
            // 
            this.RootLayout.SetColumnSpan(this.UserPanel, 2);
            this.UserPanel.Controls.Add(this.userName);
            this.UserPanel.Controls.Add(this.Logout);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserPanel.Location = new System.Drawing.Point(3, 3);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(265, 32);
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
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Logout.Dock = System.Windows.Forms.DockStyle.Right;
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Logout.ImageIndex = 0;
            this.Logout.Location = new System.Drawing.Point(152, 0);
            this.Logout.Margin = new System.Windows.Forms.Padding(5);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(113, 32);
            this.Logout.TabIndex = 3;
            this.Logout.Text = "Выход";
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // StatisticsBtn
            // 
            this.StatisticsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatisticsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StatisticsBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatisticsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatisticsBtn.ImageIndex = 0;
            this.StatisticsBtn.Location = new System.Drawing.Point(5, 354);
            this.StatisticsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StatisticsBtn.Name = "StatisticsBtn";
            this.StatisticsBtn.Size = new System.Drawing.Size(224, 54);
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
            this.StartGameBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGameBtn.ImageIndex = 0;
            this.StartGameBtn.Location = new System.Drawing.Point(276, 91);
            this.StartGameBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(244, 223);
            this.StartGameBtn.TabIndex = 3;
            this.StartGameBtn.Text = "Начать занятие";
            this.StartGameBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StartGameBtn.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 413);
            this.Controls.Add(this.RootLayout);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RootLayout.ResumeLayout(false);
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
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
    }
}