namespace Tangram.UserInterface
{
    partial class TabelSettings
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
            this.MetPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MonthCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yearPicker = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MetPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // MetPanel
            // 
            this.MetPanel.Controls.Add(this.textBox1);
            this.MetPanel.Controls.Add(this.label12);
            this.MetPanel.Controls.Add(this.MonthCombo);
            this.MetPanel.Controls.Add(this.label1);
            this.MetPanel.Controls.Add(this.label5);
            this.MetPanel.Controls.Add(this.groupCombo);
            this.MetPanel.Controls.Add(this.label6);
            this.MetPanel.Controls.Add(this.yearPicker);
            this.MetPanel.Location = new System.Drawing.Point(48, 13);
            this.MetPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MetPanel.Name = "MetPanel";
            this.MetPanel.Size = new System.Drawing.Size(319, 123);
            this.MetPanel.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(60, 26);
            this.textBox1.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(226, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 18);
            this.label12.TabIndex = 21;
            this.label12.Text = "—";
            // 
            // MonthCombo
            // 
            this.MonthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthCombo.FormattingEnabled = true;
            this.MonthCombo.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.MonthCombo.Location = new System.Drawing.Point(141, 77);
            this.MonthCombo.Name = "MonthCombo";
            this.MonthCombo.Size = new System.Drawing.Size(175, 26);
            this.MonthCombo.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Месяц";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Группа";
            // 
            // groupCombo
            // 
            this.groupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupCombo.FormattingEnabled = true;
            this.groupCombo.Items.AddRange(new object[] {
            "Месяц",
            "Учебный год",
            "Произвольный период"});
            this.groupCombo.Location = new System.Drawing.Point(141, 4);
            this.groupCombo.Margin = new System.Windows.Forms.Padding(4);
            this.groupCombo.Name = "groupCombo";
            this.groupCombo.Size = new System.Drawing.Size(178, 26);
            this.groupCombo.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Учебный год";
            // 
            // yearPicker
            // 
            this.yearPicker.Location = new System.Drawing.Point(141, 43);
            this.yearPicker.Margin = new System.Windows.Forms.Padding(4);
            this.yearPicker.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.yearPicker.Minimum = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.Size = new System.Drawing.Size(83, 26);
            this.yearPicker.TabIndex = 17;
            this.yearPicker.Value = new decimal(new int[] {
            1910,
            0,
            0,
            0});
            this.yearPicker.ValueChanged += new System.EventHandler(this.yearPicker_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 43);
            this.button2.TabIndex = 22;
            this.button2.Text = "Создать отчет";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 43);
            this.button3.TabIndex = 23;
            this.button3.Text = "Отмена";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TabelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 192);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.MetPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TabelSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка";
            this.Load += new System.EventHandler(this.TabelSettings_Load);
            this.MetPanel.ResumeLayout(false);
            this.MetPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MetPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox groupCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown yearPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MonthCombo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
    }
}