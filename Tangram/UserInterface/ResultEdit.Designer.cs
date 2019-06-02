namespace Tangram.UserInterface
{
    partial class ResultEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.childCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChildScoreUpDown = new System.Windows.Forms.NumericUpDown();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.difficultyCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChildScoreUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ребенок: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // childCombo
            // 
            this.childCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.childCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.childCombo.FormattingEnabled = true;
            this.childCombo.Items.AddRange(new object[] {
            "<не выбрано>",
            "Воспитатель",
            "Методист"});
            this.childCombo.Location = new System.Drawing.Point(192, 18);
            this.childCombo.Margin = new System.Windows.Forms.Padding(4);
            this.childCombo.Name = "childCombo";
            this.childCombo.Size = new System.Drawing.Size(186, 26);
            this.childCombo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество баллов";
            // 
            // ChildScoreUpDown
            // 
            this.ChildScoreUpDown.Location = new System.Drawing.Point(192, 57);
            this.ChildScoreUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ChildScoreUpDown.Name = "ChildScoreUpDown";
            this.ChildScoreUpDown.Size = new System.Drawing.Size(120, 26);
            this.ChildScoreUpDown.TabIndex = 5;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(222, 145);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(163, 44);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(12, 145);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(176, 44);
            this.SaveBtn.TabIndex = 6;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // difficultyCombo
            // 
            this.difficultyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyCombo.FormattingEnabled = true;
            this.difficultyCombo.Items.AddRange(new object[] {
            "С контуром ",
            "Без контура"});
            this.difficultyCombo.Location = new System.Drawing.Point(192, 99);
            this.difficultyCombo.Margin = new System.Windows.Forms.Padding(4);
            this.difficultyCombo.Name = "difficultyCombo";
            this.difficultyCombo.Size = new System.Drawing.Size(179, 26);
            this.difficultyCombo.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Уровень сложности";
            // 
            // ResultEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 199);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.difficultyCombo);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ChildScoreUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.childCombo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "Редактирование результата";
            ((System.ComponentModel.ISupportInitialize)(this.ChildScoreUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox childCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ChildScoreUpDown;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ComboBox difficultyCombo;
        private System.Windows.Forms.Label label3;
    }
}