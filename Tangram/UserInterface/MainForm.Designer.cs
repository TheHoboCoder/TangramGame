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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FiguresBtn = new System.Windows.Forms.Button();
            this.StatisticsBtn = new System.Windows.Forms.Button();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.userName = new System.Windows.Forms.Label();
            this.userProfile = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RootLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.RootLayout.Controls.Add(this.FiguresBtn, 4, 4);
            this.RootLayout.Controls.Add(this.StatisticsBtn, 0, 4);
            this.RootLayout.Controls.Add(this.StartGameBtn, 2, 2);
            this.RootLayout.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.RootLayout.Controls.Add(this.pictureBox1, 4, 2);
            this.RootLayout.Controls.Add(this.pictureBox2, 0, 2);
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
            this.RootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RootLayout.Size = new System.Drawing.Size(954, 506);
            this.RootLayout.TabIndex = 2;
            this.RootLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.RootLayout_Paint);
            // 
            // FiguresBtn
            // 
            this.FiguresBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.FiguresBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiguresBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FiguresBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FiguresBtn.Image = global::Tangram.Properties.Resources.shapes;
            this.FiguresBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiguresBtn.Location = new System.Drawing.Point(685, 432);
            this.FiguresBtn.Margin = new System.Windows.Forms.Padding(5);
            this.FiguresBtn.Name = "FiguresBtn";
            this.FiguresBtn.Size = new System.Drawing.Size(264, 69);
            this.FiguresBtn.TabIndex = 0;
            this.FiguresBtn.Text = "Фигуры";
            this.FiguresBtn.UseVisualStyleBackColor = false;
            this.FiguresBtn.Click += new System.EventHandler(this.FiguresBtn_Click);
            // 
            // StatisticsBtn
            // 
            this.StatisticsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StatisticsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticsBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StatisticsBtn.Image = global::Tangram.Properties.Resources.graph;
            this.StatisticsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatisticsBtn.Location = new System.Drawing.Point(5, 432);
            this.StatisticsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StatisticsBtn.Name = "StatisticsBtn";
            this.StatisticsBtn.Size = new System.Drawing.Size(291, 69);
            this.StatisticsBtn.TabIndex = 4;
            this.StatisticsBtn.Text = "Статистика";
            this.StatisticsBtn.UseVisualStyleBackColor = false;
            this.StatisticsBtn.Click += new System.EventHandler(this.StatisticsBtn_Click);
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.StartGameBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartGameBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGameBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartGameBtn.Image = global::Tangram.Properties.Resources.play_button;
            this.StartGameBtn.Location = new System.Drawing.Point(338, 97);
            this.StartGameBtn.Margin = new System.Windows.Forms.Padding(5);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(301, 288);
            this.StartGameBtn.TabIndex = 3;
            this.StartGameBtn.Text = "Начать занятие";
            this.StartGameBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StartGameBtn.UseVisualStyleBackColor = false;
            this.StartGameBtn.Click += new System.EventHandler(this.StartGameBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.RootLayout.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.userName);
            this.flowLayoutPanel1.Controls.Add(this.userProfile);
            this.flowLayoutPanel1.Controls.Add(this.Logout);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(281, 41);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userName.Location = new System.Drawing.Point(5, 0);
            this.userName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(89, 20);
            this.userName.TabIndex = 3;
            this.userName.Text = "Курлык П.С.";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userProfile
            // 
            this.userProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.userProfile.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfile.Image = global::Tangram.Properties.Resources.user_silhouette_small;
            this.userProfile.Location = new System.Drawing.Point(104, 5);
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
            this.Logout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.Image = global::Tangram.Properties.Resources.logout;
            this.Logout.Location = new System.Drawing.Point(158, 5);
            this.Logout.Margin = new System.Windows.Forms.Padding(5);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(44, 31);
            this.Logout.TabIndex = 3;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Tangram.Properties.Resources.Ресурс_1;
            this.pictureBox1.Location = new System.Drawing.Point(683, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.RootLayout.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(268, 243);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::Tangram.Properties.Resources.Ресурс_4;
            this.pictureBox2.Location = new System.Drawing.Point(3, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.RootLayout.SetRowSpan(this.pictureBox2, 2);
            this.pictureBox2.Size = new System.Drawing.Size(295, 243);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(954, 506);
            this.Controls.Add(this.RootLayout);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(655, 384);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RootLayout.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FiguresBtn;
        private System.Windows.Forms.TableLayoutPanel RootLayout;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button StatisticsBtn;
        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.Button userProfile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}