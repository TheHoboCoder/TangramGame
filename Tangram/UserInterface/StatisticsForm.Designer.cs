namespace Tangram.UserInterface
{
    partial class StatisticsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.child_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diff_1_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diff_2_r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countClasss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_child = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diff1_mid_flowchart = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.diff1_bad = new System.Windows.Forms.Label();
            this.diff_1good = new System.Windows.Forms.Label();
            this.diff1_mid_text = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.diff1_good_flowchart = new System.Windows.Forms.Panel();
            this.diff1_bad_flowchart = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.diff2_bad = new System.Windows.Forms.Label();
            this.diff_2_good = new System.Windows.Forms.Label();
            this.diff2_mid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.diff2_good_flowchart = new System.Windows.Forms.Panel();
            this.diff2_bad_flowchart = new System.Windows.Forms.Panel();
            this.diff2_mid_flowchart = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.CreateRepBtn = new System.Windows.Forms.Button();
            this.groupCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yearPicker = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.MetPanel = new System.Windows.Forms.Panel();
            this.reportViewers = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker)).BeginInit();
            this.MetPanel.SuspendLayout();
            this.reportViewers.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.child_name,
            this.diff_1_r,
            this.diff_2_r,
            this.countClasss,
            this.id_child,
            this.count});
            this.dataGridView1.Location = new System.Drawing.Point(13, 73);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(624, 392);
            this.dataGridView1.TabIndex = 0;
            // 
            // child_name
            // 
            this.child_name.DataPropertyName = "childName";
            this.child_name.HeaderText = "Имя ребенка";
            this.child_name.Name = "child_name";
            this.child_name.ReadOnly = true;
            // 
            // diff_1_r
            // 
            this.diff_1_r.DataPropertyName = "diff_1_result";
            this.diff_1_r.HeaderText = "Результат сложность 1";
            this.diff_1_r.Name = "diff_1_r";
            this.diff_1_r.ReadOnly = true;
            // 
            // diff_2_r
            // 
            this.diff_2_r.DataPropertyName = "diff_2_result";
            this.diff_2_r.HeaderText = "Результат сложность 2";
            this.diff_2_r.Name = "diff_2_r";
            this.diff_2_r.ReadOnly = true;
            // 
            // countClasss
            // 
            this.countClasss.DataPropertyName = "classCount_text";
            this.countClasss.HeaderText = "Посещенно занятий";
            this.countClasss.Name = "countClasss";
            this.countClasss.ReadOnly = true;
            // 
            // id_child
            // 
            this.id_child.DataPropertyName = "id_child";
            this.id_child.HeaderText = "Column1";
            this.id_child.Name = "id_child";
            this.id_child.ReadOnly = true;
            this.id_child.Visible = false;
            // 
            // count
            // 
            this.count.DataPropertyName = "classCount";
            this.count.HeaderText = "Column1";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Visible = false;
            // 
            // diff1_mid_flowchart
            // 
            this.diff1_mid_flowchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff1_mid_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff1_mid_flowchart.Location = new System.Drawing.Point(213, 43);
            this.diff1_mid_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff1_mid_flowchart.Name = "diff1_mid_flowchart";
            this.diff1_mid_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff1_mid_flowchart.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(650, 73);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(580, 396);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.diff1_bad);
            this.tabPage1.Controls.Add(this.diff_1good);
            this.tabPage1.Controls.Add(this.diff1_mid_text);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.diff1_good_flowchart);
            this.tabPage1.Controls.Add(this.diff1_bad_flowchart);
            this.tabPage1.Controls.Add(this.diff1_mid_flowchart);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(572, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "С контуром";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // diff1_bad
            // 
            this.diff1_bad.AutoSize = true;
            this.diff1_bad.Location = new System.Drawing.Point(78, 21);
            this.diff1_bad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff1_bad.Name = "diff1_bad";
            this.diff1_bad.Size = new System.Drawing.Size(73, 18);
            this.diff1_bad.TabIndex = 10;
            this.diff1_bad.Text = "Среднее";
            // 
            // diff_1good
            // 
            this.diff_1good.AutoSize = true;
            this.diff_1good.Location = new System.Drawing.Point(411, 21);
            this.diff_1good.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff_1good.Name = "diff_1good";
            this.diff_1good.Size = new System.Drawing.Size(73, 18);
            this.diff_1good.TabIndex = 9;
            this.diff_1good.Text = "Среднее";
            // 
            // diff1_mid_text
            // 
            this.diff1_mid_text.AutoSize = true;
            this.diff1_mid_text.Location = new System.Drawing.Point(245, 21);
            this.diff1_mid_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff1_mid_text.Name = "diff1_mid_text";
            this.diff1_mid_text.Size = new System.Drawing.Size(73, 18);
            this.diff1_mid_text.TabIndex = 8;
            this.diff1_mid_text.Text = "Среднее";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 326);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Плохое";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 326);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Среднее";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 326);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Хорошое";
            // 
            // diff1_good_flowchart
            // 
            this.diff1_good_flowchart.BackColor = System.Drawing.Color.Red;
            this.diff1_good_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff1_good_flowchart.Location = new System.Drawing.Point(381, 43);
            this.diff1_good_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff1_good_flowchart.Name = "diff1_good_flowchart";
            this.diff1_good_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff1_good_flowchart.TabIndex = 4;
            // 
            // diff1_bad_flowchart
            // 
            this.diff1_bad_flowchart.BackColor = System.Drawing.Color.Blue;
            this.diff1_bad_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff1_bad_flowchart.Location = new System.Drawing.Point(46, 43);
            this.diff1_bad_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff1_bad_flowchart.Name = "diff1_bad_flowchart";
            this.diff1_bad_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff1_bad_flowchart.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.diff2_bad);
            this.tabPage2.Controls.Add(this.diff_2_good);
            this.tabPage2.Controls.Add(this.diff2_mid);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.diff2_good_flowchart);
            this.tabPage2.Controls.Add(this.diff2_bad_flowchart);
            this.tabPage2.Controls.Add(this.diff2_mid_flowchart);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(572, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Без контура";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // diff2_bad
            // 
            this.diff2_bad.AutoSize = true;
            this.diff2_bad.Location = new System.Drawing.Point(78, 21);
            this.diff2_bad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff2_bad.Name = "diff2_bad";
            this.diff2_bad.Size = new System.Drawing.Size(73, 18);
            this.diff2_bad.TabIndex = 19;
            this.diff2_bad.Text = "Среднее";
            // 
            // diff_2_good
            // 
            this.diff_2_good.AutoSize = true;
            this.diff_2_good.Location = new System.Drawing.Point(411, 21);
            this.diff_2_good.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff_2_good.Name = "diff_2_good";
            this.diff_2_good.Size = new System.Drawing.Size(73, 18);
            this.diff_2_good.TabIndex = 18;
            this.diff_2_good.Text = "Среднее";
            // 
            // diff2_mid
            // 
            this.diff2_mid.AutoSize = true;
            this.diff2_mid.Location = new System.Drawing.Point(245, 21);
            this.diff2_mid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.diff2_mid.Name = "diff2_mid";
            this.diff2_mid.Size = new System.Drawing.Size(73, 18);
            this.diff2_mid.TabIndex = 17;
            this.diff2_mid.Text = "Среднее";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 326);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Плохое";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 326);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Среднее";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 326);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "Хорошое";
            // 
            // diff2_good_flowchart
            // 
            this.diff2_good_flowchart.BackColor = System.Drawing.Color.Red;
            this.diff2_good_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff2_good_flowchart.Location = new System.Drawing.Point(381, 43);
            this.diff2_good_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff2_good_flowchart.Name = "diff2_good_flowchart";
            this.diff2_good_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff2_good_flowchart.TabIndex = 13;
            // 
            // diff2_bad_flowchart
            // 
            this.diff2_bad_flowchart.BackColor = System.Drawing.Color.Blue;
            this.diff2_bad_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff2_bad_flowchart.Location = new System.Drawing.Point(46, 43);
            this.diff2_bad_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff2_bad_flowchart.Name = "diff2_bad_flowchart";
            this.diff2_bad_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff2_bad_flowchart.TabIndex = 12;
            // 
            // diff2_mid_flowchart
            // 
            this.diff2_mid_flowchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diff2_mid_flowchart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.diff2_mid_flowchart.Location = new System.Drawing.Point(213, 43);
            this.diff2_mid_flowchart.Margin = new System.Windows.Forms.Padding(4);
            this.diff2_mid_flowchart.Name = "diff2_mid_flowchart";
            this.diff2_mid_flowchart.Size = new System.Drawing.Size(138, 279);
            this.diff2_mid_flowchart.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Период времени";
            // 
            // periodCombo
            // 
            this.periodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodCombo.FormattingEnabled = true;
            this.periodCombo.Items.AddRange(new object[] {
            "За текущий месяц",
            "За последний месяц",
            "Учебный год",
            "Произвольный период"});
            this.periodCombo.Location = new System.Drawing.Point(174, 24);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(211, 26);
            this.periodCombo.TabIndex = 12;
            this.periodCombo.SelectedIndexChanged += new System.EventHandler(this.periodCombo_SelectedIndexChanged);
            // 
            // CreateRepBtn
            // 
            this.CreateRepBtn.Location = new System.Drawing.Point(410, 17);
            this.CreateRepBtn.Name = "CreateRepBtn";
            this.CreateRepBtn.Size = new System.Drawing.Size(217, 34);
            this.CreateRepBtn.TabIndex = 13;
            this.CreateRepBtn.Text = "Сформировать";
            this.CreateRepBtn.UseVisualStyleBackColor = true;
            this.CreateRepBtn.Click += new System.EventHandler(this.CreateRepBtn_Click);
            // 
            // groupCombo
            // 
            this.groupCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupCombo.FormattingEnabled = true;
            this.groupCombo.Items.AddRange(new object[] {
            "Месяц",
            "Учебный год",
            "Произвольный период"});
            this.groupCombo.Location = new System.Drawing.Point(68, 3);
            this.groupCombo.Name = "groupCombo";
            this.groupCombo.Size = new System.Drawing.Size(198, 26);
            this.groupCombo.TabIndex = 14;
            this.groupCombo.SelectedIndexChanged += new System.EventHandler(this.groupCombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Группа";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "Год";
            // 
            // yearPicker
            // 
            this.yearPicker.Location = new System.Drawing.Point(326, 3);
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
            this.yearPicker.Size = new System.Drawing.Size(144, 26);
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
            this.button2.Location = new System.Drawing.Point(0, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(350, 52);
            this.button2.TabIndex = 18;
            this.button2.Text = "Отчет об успеваемости";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(353, 52);
            this.button3.TabIndex = 19;
            this.button3.Text = "Табель посещаемости";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MetPanel
            // 
            this.MetPanel.Controls.Add(this.label5);
            this.MetPanel.Controls.Add(this.groupCombo);
            this.MetPanel.Controls.Add(this.label6);
            this.MetPanel.Controls.Add(this.yearPicker);
            this.MetPanel.Location = new System.Drawing.Point(650, 17);
            this.MetPanel.Name = "MetPanel";
            this.MetPanel.Size = new System.Drawing.Size(482, 49);
            this.MetPanel.TabIndex = 20;
            // 
            // reportViewers
            // 
            this.reportViewers.Controls.Add(this.button2);
            this.reportViewers.Controls.Add(this.button3);
            this.reportViewers.Location = new System.Drawing.Point(12, 493);
            this.reportViewers.Name = "reportViewers";
            this.reportViewers.Size = new System.Drawing.Size(716, 62);
            this.reportViewers.TabIndex = 21;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 559);
            this.Controls.Add(this.reportViewers);
            this.Controls.Add(this.MetPanel);
            this.Controls.Add(this.CreateRepBtn);
            this.Controls.Add(this.periodCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StatisticsForm";
            this.Text = "Просмотр статистики";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker)).EndInit();
            this.MetPanel.ResumeLayout(false);
            this.MetPanel.PerformLayout();
            this.reportViewers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn diff_1_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn diff_2_r;
        private System.Windows.Forms.DataGridViewTextBoxColumn countClasss;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_child;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.Panel diff1_mid_flowchart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label diff1_bad;
        private System.Windows.Forms.Label diff_1good;
        private System.Windows.Forms.Label diff1_mid_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel diff1_good_flowchart;
        private System.Windows.Forms.Panel diff1_bad_flowchart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label diff2_bad;
        private System.Windows.Forms.Label diff_2_good;
        private System.Windows.Forms.Label diff2_mid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel diff2_good_flowchart;
        private System.Windows.Forms.Panel diff2_bad_flowchart;
        private System.Windows.Forms.Panel diff2_mid_flowchart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.Button CreateRepBtn;
        private System.Windows.Forms.ComboBox groupCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown yearPicker;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel MetPanel;
        private System.Windows.Forms.Panel reportViewers;
    }
}