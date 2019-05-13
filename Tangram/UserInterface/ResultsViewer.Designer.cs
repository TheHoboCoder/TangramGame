namespace Tangram.UserInterface
{
    partial class ResultsViewer
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            this.child_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_child = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.class_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.childCheckBox = new System.Windows.Forms.CheckBox();
            this.childFilterCombo = new System.Windows.Forms.ComboBox();
            this.teacherCheckBox = new System.Windows.Forms.CheckBox();
            this.teacherFilterCombo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.periodCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ResultGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 238);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ResultGridView
            // 
            this.ResultGridView.AllowUserToAddRows = false;
            this.ResultGridView.AllowUserToDeleteRows = false;
            this.ResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.child_name,
            this.TeacherName,
            this.id_user,
            this.id_child,
            this.group_name,
            this.class_date,
            this.score,
            this.level_name});
            this.ResultGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultGridView.Location = new System.Drawing.Point(3, 142);
            this.ResultGridView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ResultGridView.MultiSelect = false;
            this.ResultGridView.Name = "ResultGridView";
            this.ResultGridView.ReadOnly = true;
            this.ResultGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultGridView.Size = new System.Drawing.Size(843, 91);
            this.ResultGridView.TabIndex = 24;
            // 
            // child_name
            // 
            this.child_name.DataPropertyName = "childName";
            this.child_name.HeaderText = "Имя ребёнка";
            this.child_name.Name = "child_name";
            this.child_name.ReadOnly = true;
            // 
            // TeacherName
            // 
            this.TeacherName.DataPropertyName = "fam";
            this.TeacherName.HeaderText = "Воспитатель";
            this.TeacherName.Name = "TeacherName";
            this.TeacherName.ReadOnly = true;
            // 
            // id_user
            // 
            this.id_user.DataPropertyName = "id_user";
            this.id_user.HeaderText = "";
            this.id_user.Name = "id_user";
            this.id_user.ReadOnly = true;
            this.id_user.Visible = false;
            // 
            // id_child
            // 
            this.id_child.DataPropertyName = "id_child";
            this.id_child.HeaderText = "Column1";
            this.id_child.Name = "id_child";
            this.id_child.ReadOnly = true;
            this.id_child.Visible = false;
            // 
            // group_name
            // 
            this.group_name.DataPropertyName = "group_name";
            this.group_name.HeaderText = "Группа";
            this.group_name.Name = "group_name";
            this.group_name.ReadOnly = true;
            // 
            // class_date
            // 
            this.class_date.DataPropertyName = "class_date";
            this.class_date.HeaderText = "Дата проведения занятия";
            this.class_date.Name = "class_date";
            this.class_date.ReadOnly = true;
            // 
            // score
            // 
            this.score.DataPropertyName = "score";
            this.score.HeaderText = "Количество баллов";
            this.score.Name = "score";
            this.score.ReadOnly = true;
            // 
            // level_name
            // 
            this.level_name.DataPropertyName = "level_name";
            this.level_name.HeaderText = "Уровень сложности";
            this.level_name.Name = "level_name";
            this.level_name.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ShowAllBtn);
            this.panel1.Controls.Add(this.FilterBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 129);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.childCheckBox);
            this.panel3.Controls.Add(this.childFilterCombo);
            this.panel3.Controls.Add(this.teacherCheckBox);
            this.panel3.Controls.Add(this.teacherFilterCombo);
            this.panel3.Location = new System.Drawing.Point(331, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 81);
            this.panel3.TabIndex = 43;
            // 
            // childCheckBox
            // 
            this.childCheckBox.AutoSize = true;
            this.childCheckBox.Location = new System.Drawing.Point(11, 11);
            this.childCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.childCheckBox.Name = "childCheckBox";
            this.childCheckBox.Size = new System.Drawing.Size(76, 20);
            this.childCheckBox.TabIndex = 36;
            this.childCheckBox.Text = "Ребёнок";
            this.childCheckBox.UseVisualStyleBackColor = true;
            // 
            // childFilterCombo
            // 
            this.childFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.childFilterCombo.FormattingEnabled = true;
            this.childFilterCombo.Location = new System.Drawing.Point(119, 11);
            this.childFilterCombo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.childFilterCombo.Name = "childFilterCombo";
            this.childFilterCombo.Size = new System.Drawing.Size(143, 24);
            this.childFilterCombo.TabIndex = 29;
            // 
            // teacherCheckBox
            // 
            this.teacherCheckBox.AutoSize = true;
            this.teacherCheckBox.Location = new System.Drawing.Point(11, 43);
            this.teacherCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.teacherCheckBox.Name = "teacherCheckBox";
            this.teacherCheckBox.Size = new System.Drawing.Size(102, 20);
            this.teacherCheckBox.TabIndex = 37;
            this.teacherCheckBox.Text = "Воспитатель";
            this.teacherCheckBox.UseVisualStyleBackColor = true;
            // 
            // teacherFilterCombo
            // 
            this.teacherFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherFilterCombo.FormattingEnabled = true;
            this.teacherFilterCombo.Location = new System.Drawing.Point(119, 46);
            this.teacherFilterCombo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.teacherFilterCombo.Name = "teacherFilterCombo";
            this.teacherFilterCombo.Size = new System.Drawing.Size(143, 24);
            this.teacherFilterCombo.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.periodCombo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.startDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.endDate);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 117);
            this.panel2.TabIndex = 42;
            // 
            // periodCombo
            // 
            this.periodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodCombo.FormattingEnabled = true;
            this.periodCombo.Items.AddRange(new object[] {
            "За все время",
            "За текущий месяц",
            "За последний месяц",
            "За учебный год",
            "Произвольный период"});
            this.periodCombo.Location = new System.Drawing.Point(132, 9);
            this.periodCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.periodCombo.Name = "periodCombo";
            this.periodCombo.Size = new System.Drawing.Size(174, 24);
            this.periodCombo.TabIndex = 33;
            this.periodCombo.SelectedIndexChanged += new System.EventHandler(this.periodCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Период времени";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Конечная дата";
            // 
            // startDate
            // 
            this.startDate.Enabled = false;
            this.startDate.Location = new System.Drawing.Point(133, 46);
            this.startDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(173, 22);
            this.startDate.TabIndex = 38;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Начальная дата";
            // 
            // endDate
            // 
            this.endDate.Enabled = false;
            this.endDate.Location = new System.Drawing.Point(133, 80);
            this.endDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(173, 22);
            this.endDate.TabIndex = 39;
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(621, 60);
            this.ShowAllBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(204, 44);
            this.ShowAllBtn.TabIndex = 35;
            this.ShowAllBtn.Text = "Показать все";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // FilterBtn
            // 
            this.FilterBtn.Location = new System.Drawing.Point(621, 7);
            this.FilterBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(204, 44);
            this.FilterBtn.TabIndex = 34;
            this.FilterBtn.Text = "Фильтровать";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // ResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(849, 238);
            this.Name = "ResultsViewer";
            this.Size = new System.Drawing.Size(849, 238);
            this.Load += new System.EventHandler(this.ResultsViewer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ResultGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn child_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_child;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn class_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn level_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox teacherFilterCombo;
        private System.Windows.Forms.ComboBox childFilterCombo;
        private System.Windows.Forms.ComboBox periodCombo;
        private System.Windows.Forms.CheckBox teacherCheckBox;
        private System.Windows.Forms.CheckBox childCheckBox;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}
