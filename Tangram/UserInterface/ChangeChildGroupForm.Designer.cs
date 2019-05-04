namespace Tangram.UserInterface
{
    partial class ChangeChildGroupForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.startGroupCombo = new System.Windows.Forms.ComboBox();
            this.endGroupCombo = new System.Windows.Forms.ComboBox();
            this.endChildList = new System.Windows.Forms.ListBox();
            this.RemoveFromBtn = new System.Windows.Forms.Button();
            this.AddToGroupBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startYear = new System.Windows.Forms.NumericUpDown();
            this.endYear = new System.Windows.Forms.NumericUpDown();
            this.SelectAllStart = new System.Windows.Forms.Button();
            this.ChildList = new System.Windows.Forms.ListBox();
            this.SelectAllEnd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Перевести из группы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(397, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "В группу";
            // 
            // startGroupCombo
            // 
            this.startGroupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startGroupCombo.FormattingEnabled = true;
            this.startGroupCombo.Items.AddRange(new object[] {
            "<Не выбрано>",
            "Мои фигуры",
            "Не мои фигуры"});
            this.startGroupCombo.Location = new System.Drawing.Point(198, 13);
            this.startGroupCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startGroupCombo.Name = "startGroupCombo";
            this.startGroupCombo.Size = new System.Drawing.Size(172, 26);
            this.startGroupCombo.TabIndex = 21;
            this.startGroupCombo.DropDownClosed += new System.EventHandler(this.startGroupCombo_DropDownClosed);
            // 
            // endGroupCombo
            // 
            this.endGroupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endGroupCombo.FormattingEnabled = true;
            this.endGroupCombo.Items.AddRange(new object[] {
            "<Не выбрано>",
            "Мои фигуры",
            "Не мои фигуры"});
            this.endGroupCombo.Location = new System.Drawing.Point(484, 13);
            this.endGroupCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endGroupCombo.Name = "endGroupCombo";
            this.endGroupCombo.Size = new System.Drawing.Size(172, 26);
            this.endGroupCombo.TabIndex = 22;
            this.endGroupCombo.DropDownClosed += new System.EventHandler(this.endGroupCombo_DropDownClosed);
            // 
            // endChildList
            // 
            this.endChildList.FormattingEnabled = true;
            this.endChildList.ItemHeight = 18;
            this.endChildList.Location = new System.Drawing.Point(392, 126);
            this.endChildList.Name = "endChildList";
            this.endChildList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.endChildList.Size = new System.Drawing.Size(322, 256);
            this.endChildList.TabIndex = 23;
            this.endChildList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // RemoveFromBtn
            // 
            this.RemoveFromBtn.Location = new System.Drawing.Point(314, 218);
            this.RemoveFromBtn.Name = "RemoveFromBtn";
            this.RemoveFromBtn.Size = new System.Drawing.Size(72, 41);
            this.RemoveFromBtn.TabIndex = 24;
            this.RemoveFromBtn.Text = "<<";
            this.RemoveFromBtn.UseVisualStyleBackColor = true;
            this.RemoveFromBtn.Click += new System.EventHandler(this.RemoveFromBtn_Click);
            // 
            // AddToGroupBtn
            // 
            this.AddToGroupBtn.Location = new System.Drawing.Point(314, 171);
            this.AddToGroupBtn.Name = "AddToGroupBtn";
            this.AddToGroupBtn.Size = new System.Drawing.Size(72, 41);
            this.AddToGroupBtn.TabIndex = 25;
            this.AddToGroupBtn.Text = ">>";
            this.AddToGroupBtn.UseVisualStyleBackColor = true;
            this.AddToGroupBtn.Click += new System.EventHandler(this.AddToGroupBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Учебный год";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(398, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 29;
            this.label4.Text = "Учебный год";
            // 
            // startYear
            // 
            this.startYear.Location = new System.Drawing.Point(121, 52);
            this.startYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.startYear.Minimum = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            this.startYear.Name = "startYear";
            this.startYear.Size = new System.Drawing.Size(120, 26);
            this.startYear.TabIndex = 30;
            this.startYear.Value = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            // 
            // endYear
            // 
            this.endYear.Location = new System.Drawing.Point(505, 54);
            this.endYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.endYear.Minimum = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            this.endYear.Name = "endYear";
            this.endYear.Size = new System.Drawing.Size(120, 26);
            this.endYear.TabIndex = 31;
            this.endYear.Value = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            // 
            // SelectAllStart
            // 
            this.SelectAllStart.Location = new System.Drawing.Point(14, 84);
            this.SelectAllStart.Name = "SelectAllStart";
            this.SelectAllStart.Size = new System.Drawing.Size(160, 33);
            this.SelectAllStart.TabIndex = 32;
            this.SelectAllStart.Text = "Выбрать всех";
            this.SelectAllStart.UseVisualStyleBackColor = true;
            this.SelectAllStart.Click += new System.EventHandler(this.SelectAllStart_Click);
            // 
            // ChildList
            // 
            this.ChildList.FormattingEnabled = true;
            this.ChildList.ItemHeight = 18;
            this.ChildList.Location = new System.Drawing.Point(14, 126);
            this.ChildList.Name = "ChildList";
            this.ChildList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ChildList.Size = new System.Drawing.Size(294, 256);
            this.ChildList.TabIndex = 33;
            // 
            // SelectAllEnd
            // 
            this.SelectAllEnd.Location = new System.Drawing.Point(392, 84);
            this.SelectAllEnd.Name = "SelectAllEnd";
            this.SelectAllEnd.Size = new System.Drawing.Size(160, 33);
            this.SelectAllEnd.TabIndex = 34;
            this.SelectAllEnd.Text = "Выбрать всех";
            this.SelectAllEnd.UseVisualStyleBackColor = true;
            this.SelectAllEnd.Click += new System.EventHandler(this.SelectAllEnd_Click);
            // 
            // ChangeChildGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 408);
            this.Controls.Add(this.SelectAllEnd);
            this.Controls.Add(this.ChildList);
            this.Controls.Add(this.SelectAllStart);
            this.Controls.Add(this.endYear);
            this.Controls.Add(this.startYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddToGroupBtn);
            this.Controls.Add(this.RemoveFromBtn);
            this.Controls.Add(this.endChildList);
            this.Controls.Add(this.endGroupCombo);
            this.Controls.Add(this.startGroupCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeChildGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Перевести детей";
            this.Load += new System.EventHandler(this.ChangeChildGroupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.startYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox startGroupCombo;
        private System.Windows.Forms.ComboBox endGroupCombo;
        private System.Windows.Forms.ListBox endChildList;
        private System.Windows.Forms.Button RemoveFromBtn;
        private System.Windows.Forms.Button AddToGroupBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown startYear;
        private System.Windows.Forms.NumericUpDown endYear;
        private System.Windows.Forms.Button SelectAllStart;
        private System.Windows.Forms.ListBox ChildList;
        private System.Windows.Forms.Button SelectAllEnd;
    }
}