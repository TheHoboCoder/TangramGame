namespace Tangram.UserInterface
{
    partial class FigureGroupsEdit
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
            this.CommentTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LevelTB = new System.Windows.Forms.TextBox();
            this.famLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommentTB
            // 
            this.CommentTB.Location = new System.Drawing.Point(152, 48);
            this.CommentTB.Margin = new System.Windows.Forms.Padding(2);
            this.CommentTB.Multiline = true;
            this.CommentTB.Name = "CommentTB";
            this.CommentTB.Size = new System.Drawing.Size(190, 38);
            this.CommentTB.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Комментарий \r\n(необязательно)\r\n";
            // 
            // LevelTB
            // 
            this.LevelTB.Location = new System.Drawing.Point(152, 21);
            this.LevelTB.Margin = new System.Windows.Forms.Padding(2);
            this.LevelTB.Name = "LevelTB";
            this.LevelTB.Size = new System.Drawing.Size(190, 20);
            this.LevelTB.TabIndex = 11;
            // 
            // famLabel
            // 
            this.famLabel.AutoSize = true;
            this.famLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.famLabel.Location = new System.Drawing.Point(23, 22);
            this.famLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.famLabel.Name = "famLabel";
            this.famLabel.Size = new System.Drawing.Size(125, 16);
            this.famLabel.TabIndex = 10;
            this.famLabel.Text = "Название уровня";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 99);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 38);
            this.button1.TabIndex = 16;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(12, 99);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(144, 38);
            this.LoginBtn.TabIndex = 15;
            this.LoginBtn.Text = "Сохранить";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // FigureGroupsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 147);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.CommentTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelTB);
            this.Controls.Add(this.famLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FigureGroupsEdit";
            this.Text = "Редактирование групп фигур";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommentTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LevelTB;
        private System.Windows.Forms.Label famLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoginBtn;
    }
}