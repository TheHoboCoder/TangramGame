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
            this.LoginBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.TablePlace = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.Button();
            this.userProfile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(12, 60);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(138, 38);
            this.LoginBtn.TabIndex = 5;
            this.LoginBtn.Text = "Управление пользователями";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Управление группами";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(937, 11);
            this.userName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(69, 13);
            this.userName.TabIndex = 7;
            this.userName.Text = "Курлык П.С.";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TablePlace
            // 
            this.TablePlace.Location = new System.Drawing.Point(156, 60);
            this.TablePlace.Name = "TablePlace";
            this.TablePlace.Size = new System.Drawing.Size(1143, 535);
            this.TablePlace.TabIndex = 10;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Logout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Logout.Image = global::Tangram.Properties.Resources.logout;
            this.Logout.Location = new System.Drawing.Point(1255, 0);
            this.Logout.Margin = new System.Windows.Forms.Padding(5);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(44, 31);
            this.Logout.TabIndex = 9;
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // userProfile
            // 
            this.userProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.userProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userProfile.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfile.Image = global::Tangram.Properties.Resources.user_silhouette_small;
            this.userProfile.Location = new System.Drawing.Point(1201, 0);
            this.userProfile.Margin = new System.Windows.Forms.Padding(5);
            this.userProfile.Name = "userProfile";
            this.userProfile.Size = new System.Drawing.Size(44, 31);
            this.userProfile.TabIndex = 8;
            this.userProfile.UseVisualStyleBackColor = false;
            this.userProfile.Click += new System.EventHandler(this.userProfile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 144);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 38);
            this.button2.TabIndex = 11;
            this.button2.Text = "Типы подрупп";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdministratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 622);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TablePlace);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.userProfile);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoginBtn);
            this.Name = "AdministratorPanel";
            this.Text = "Администрирование";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdministratorPanel_FormClosed);
            this.Load += new System.EventHandler(this.AdministratorPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button userProfile;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Panel TablePlace;
        private System.Windows.Forms.Button button2;
    }
}