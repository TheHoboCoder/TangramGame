﻿namespace Tangram.UserInterface
{
    partial class GroupChildControl
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
            this.GroupGridView = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group_type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteGroupBtn = new System.Windows.Forms.Button();
            this.UpdateGroupBtn = new System.Windows.Forms.Button();
            this.AddGroupBtn = new System.Windows.Forms.Button();
            this.ChildGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteChildBtn = new System.Windows.Forms.Button();
            this.EditChildBtn = new System.Windows.Forms.Button();
            this.AddChildBtn = new System.Windows.Forms.Button();
            this.GroupControlPanel = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.EditGroupTypes = new System.Windows.Forms.ToolStripButton();
            this.CancelGroupBtn = new System.Windows.Forms.Button();
            this.SaveGroupBtn = new System.Windows.Forms.Button();
            this.groupTypeCombo = new System.Windows.Forms.ComboBox();
            this.teacherCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupNameTB = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FamTB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.GroupsCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.CancelChildBtn = new System.Windows.Forms.Button();
            this.SaveChildButton = new System.Windows.Forms.Button();
            this.subGroupFilter = new System.Windows.Forms.ComboBox();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupTypeFilter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.teacherFilterCombo = new System.Windows.Forms.ComboBox();
            this.filterBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ChildName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_child = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenderInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChildName_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GroupGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.GroupControlPanel.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupGridView
            // 
            this.GroupGridView.AllowUserToAddRows = false;
            this.GroupGridView.AllowUserToDeleteRows = false;
            this.GroupGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GroupGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.Id,
            this.Group_type_id,
            this.Id_user,
            this.Group_type,
            this.userName,
            this.Count});
            this.GroupGridView.Location = new System.Drawing.Point(13, 54);
            this.GroupGridView.MultiSelect = false;
            this.GroupGridView.Name = "GroupGridView";
            this.GroupGridView.ReadOnly = true;
            this.GroupGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GroupGridView.Size = new System.Drawing.Size(509, 180);
            this.GroupGridView.TabIndex = 1;
            this.GroupGridView.Click += new System.EventHandler(this.GroupGridView_Click);
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "Group_name";
            this.GroupName.HeaderText = "Название группы";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id_group";
            this.Id.HeaderText = "id_group";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Group_type_id
            // 
            this.Group_type_id.DataPropertyName = "group_type_id";
            this.Group_type_id.HeaderText = "Column1";
            this.Group_type_id.Name = "Group_type_id";
            this.Group_type_id.ReadOnly = true;
            this.Group_type_id.Visible = false;
            // 
            // Id_user
            // 
            this.Id_user.DataPropertyName = "id_user";
            this.Id_user.HeaderText = "Column1";
            this.Id_user.Name = "Id_user";
            this.Id_user.ReadOnly = true;
            this.Id_user.Visible = false;
            // 
            // Group_type
            // 
            this.Group_type.DataPropertyName = "group_type_name";
            this.Group_type.HeaderText = "Тип группы";
            this.Group_type.Name = "Group_type";
            this.Group_type.ReadOnly = true;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "usersInitials";
            this.userName.HeaderText = "Ф.И.О. воспитателя";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "count";
            this.Count.HeaderText = "Количество детей";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.DeleteGroupBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.UpdateGroupBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddGroupBtn, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 240);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(509, 41);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // DeleteGroupBtn
            // 
            this.DeleteGroupBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteGroupBtn.Location = new System.Drawing.Point(341, 2);
            this.DeleteGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteGroupBtn.Name = "DeleteGroupBtn";
            this.DeleteGroupBtn.Size = new System.Drawing.Size(165, 37);
            this.DeleteGroupBtn.TabIndex = 24;
            this.DeleteGroupBtn.Text = "Удалить";
            this.DeleteGroupBtn.UseVisualStyleBackColor = true;
            this.DeleteGroupBtn.Click += new System.EventHandler(this.DeleteGroupBtn_Click);
            // 
            // UpdateGroupBtn
            // 
            this.UpdateGroupBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateGroupBtn.Location = new System.Drawing.Point(172, 2);
            this.UpdateGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateGroupBtn.Name = "UpdateGroupBtn";
            this.UpdateGroupBtn.Size = new System.Drawing.Size(163, 37);
            this.UpdateGroupBtn.TabIndex = 23;
            this.UpdateGroupBtn.Text = "Редактировать";
            this.UpdateGroupBtn.UseVisualStyleBackColor = true;
            this.UpdateGroupBtn.Click += new System.EventHandler(this.UpdateGroupBtn_Click);
            // 
            // AddGroupBtn
            // 
            this.AddGroupBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddGroupBtn.Location = new System.Drawing.Point(3, 2);
            this.AddGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddGroupBtn.Name = "AddGroupBtn";
            this.AddGroupBtn.Size = new System.Drawing.Size(163, 37);
            this.AddGroupBtn.TabIndex = 22;
            this.AddGroupBtn.Text = "Добавить";
            this.AddGroupBtn.UseVisualStyleBackColor = true;
            this.AddGroupBtn.Click += new System.EventHandler(this.AddGroupBtn_Click);
            // 
            // ChildGridView
            // 
            this.ChildGridView.AllowUserToAddRows = false;
            this.ChildGridView.AllowUserToDeleteRows = false;
            this.ChildGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChildName,
            this.id_group,
            this.id_child,
            this.subGroupName,
            this.subGroup,
            this.Gender,
            this.GenderInt,
            this.ChildName_1,
            this.fam});
            this.ChildGridView.Location = new System.Drawing.Point(528, 54);
            this.ChildGridView.MultiSelect = false;
            this.ChildGridView.Name = "ChildGridView";
            this.ChildGridView.ReadOnly = true;
            this.ChildGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChildGridView.Size = new System.Drawing.Size(509, 180);
            this.ChildGridView.TabIndex = 23;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.DeleteChildBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.EditChildBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddChildBtn, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(528, 238);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 41);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // DeleteChildBtn
            // 
            this.DeleteChildBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteChildBtn.Location = new System.Drawing.Point(341, 2);
            this.DeleteChildBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteChildBtn.Name = "DeleteChildBtn";
            this.DeleteChildBtn.Size = new System.Drawing.Size(165, 37);
            this.DeleteChildBtn.TabIndex = 24;
            this.DeleteChildBtn.Text = "Удалить";
            this.DeleteChildBtn.UseVisualStyleBackColor = true;
            this.DeleteChildBtn.Click += new System.EventHandler(this.DeleteChildBtn_Click);
            // 
            // EditChildBtn
            // 
            this.EditChildBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditChildBtn.Location = new System.Drawing.Point(172, 2);
            this.EditChildBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditChildBtn.Name = "EditChildBtn";
            this.EditChildBtn.Size = new System.Drawing.Size(163, 37);
            this.EditChildBtn.TabIndex = 23;
            this.EditChildBtn.Text = "Редактировать";
            this.EditChildBtn.UseVisualStyleBackColor = true;
            this.EditChildBtn.Click += new System.EventHandler(this.EditChildBtn_Click);
            // 
            // AddChildBtn
            // 
            this.AddChildBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddChildBtn.Location = new System.Drawing.Point(3, 2);
            this.AddChildBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddChildBtn.Name = "AddChildBtn";
            this.AddChildBtn.Size = new System.Drawing.Size(163, 37);
            this.AddChildBtn.TabIndex = 22;
            this.AddChildBtn.Text = "Добавить";
            this.AddChildBtn.UseVisualStyleBackColor = true;
            this.AddChildBtn.Click += new System.EventHandler(this.AddChildBtn_Click);
            // 
            // GroupControlPanel
            // 
            this.GroupControlPanel.Controls.Add(this.toolStrip2);
            this.GroupControlPanel.Controls.Add(this.CancelGroupBtn);
            this.GroupControlPanel.Controls.Add(this.SaveGroupBtn);
            this.GroupControlPanel.Controls.Add(this.groupTypeCombo);
            this.GroupControlPanel.Controls.Add(this.teacherCombo);
            this.GroupControlPanel.Controls.Add(this.label2);
            this.GroupControlPanel.Controls.Add(this.label1);
            this.GroupControlPanel.Controls.Add(this.label3);
            this.GroupControlPanel.Controls.Add(this.GroupNameTB);
            this.GroupControlPanel.Location = new System.Drawing.Point(16, 287);
            this.GroupControlPanel.Name = "GroupControlPanel";
            this.GroupControlPanel.Size = new System.Drawing.Size(503, 150);
            this.GroupControlPanel.TabIndex = 25;
            this.GroupControlPanel.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditGroupTypes});
            this.toolStrip2.Location = new System.Drawing.Point(169, 60);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(35, 25);
            this.toolStrip2.TabIndex = 26;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // EditGroupTypes
            // 
            this.EditGroupTypes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditGroupTypes.Image = global::Tangram.Properties.Resources.pencil;
            this.EditGroupTypes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditGroupTypes.Name = "EditGroupTypes";
            this.EditGroupTypes.Size = new System.Drawing.Size(23, 22);
            this.EditGroupTypes.Text = "Редактирование подгрупп";
            this.EditGroupTypes.Click += new System.EventHandler(this.EditGroupTypes_Click);
            // 
            // CancelGroupBtn
            // 
            this.CancelGroupBtn.Location = new System.Drawing.Point(177, 99);
            this.CancelGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelGroupBtn.Name = "CancelGroupBtn";
            this.CancelGroupBtn.Size = new System.Drawing.Size(155, 39);
            this.CancelGroupBtn.TabIndex = 24;
            this.CancelGroupBtn.Text = "Отмена";
            this.CancelGroupBtn.UseVisualStyleBackColor = true;
            this.CancelGroupBtn.Click += new System.EventHandler(this.CancelGroupBtn_Click);
            // 
            // SaveGroupBtn
            // 
            this.SaveGroupBtn.Location = new System.Drawing.Point(14, 99);
            this.SaveGroupBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveGroupBtn.Name = "SaveGroupBtn";
            this.SaveGroupBtn.Size = new System.Drawing.Size(157, 39);
            this.SaveGroupBtn.TabIndex = 23;
            this.SaveGroupBtn.Text = "Сохранить";
            this.SaveGroupBtn.UseVisualStyleBackColor = true;
            this.SaveGroupBtn.Click += new System.EventHandler(this.SaveGroupBtn_Click);
            // 
            // groupTypeCombo
            // 
            this.groupTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupTypeCombo.FormattingEnabled = true;
            this.groupTypeCombo.Location = new System.Drawing.Point(12, 64);
            this.groupTypeCombo.Name = "groupTypeCombo";
            this.groupTypeCombo.Size = new System.Drawing.Size(151, 21);
            this.groupTypeCombo.TabIndex = 22;
            // 
            // teacherCombo
            // 
            this.teacherCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherCombo.FormattingEnabled = true;
            this.teacherCombo.Location = new System.Drawing.Point(194, 25);
            this.teacherCombo.Name = "teacherCombo";
            this.teacherCombo.Size = new System.Drawing.Size(174, 21);
            this.teacherCombo.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Воспитатель";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Тип группы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название группы";
            // 
            // GroupNameTB
            // 
            this.GroupNameTB.Location = new System.Drawing.Point(12, 25);
            this.GroupNameTB.Name = "GroupNameTB";
            this.GroupNameTB.Size = new System.Drawing.Size(149, 20);
            this.GroupNameTB.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FamTB);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.GroupsCombo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.CancelChildBtn);
            this.panel1.Controls.Add(this.SaveChildButton);
            this.panel1.Controls.Add(this.subGroupFilter);
            this.panel1.Controls.Add(this.genderBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.NameTB);
            this.panel1.Location = new System.Drawing.Point(531, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 183);
            this.panel1.TabIndex = 26;
            this.panel1.Visible = false;
            // 
            // FamTB
            // 
            this.FamTB.Location = new System.Drawing.Point(198, 26);
            this.FamTB.Name = "FamTB";
            this.FamTB.Size = new System.Drawing.Size(149, 20);
            this.FamTB.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Фамилия ребенка";
            // 
            // GroupsCombo
            // 
            this.GroupsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupsCombo.FormattingEnabled = true;
            this.GroupsCombo.Location = new System.Drawing.Point(198, 63);
            this.GroupsCombo.Name = "GroupsCombo";
            this.GroupsCombo.Size = new System.Drawing.Size(170, 21);
            this.GroupsCombo.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(195, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Группа";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(169, 99);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Tangram.Properties.Resources.plus_green;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "AddSubGroup";
            // 
            // CancelChildBtn
            // 
            this.CancelChildBtn.Location = new System.Drawing.Point(177, 130);
            this.CancelChildBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelChildBtn.Name = "CancelChildBtn";
            this.CancelChildBtn.Size = new System.Drawing.Size(155, 39);
            this.CancelChildBtn.TabIndex = 24;
            this.CancelChildBtn.Text = "Отмена";
            this.CancelChildBtn.UseVisualStyleBackColor = true;
            this.CancelChildBtn.Click += new System.EventHandler(this.CancelChildBtn_Click);
            // 
            // SaveChildButton
            // 
            this.SaveChildButton.Location = new System.Drawing.Point(12, 130);
            this.SaveChildButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveChildButton.Name = "SaveChildButton";
            this.SaveChildButton.Size = new System.Drawing.Size(157, 39);
            this.SaveChildButton.TabIndex = 23;
            this.SaveChildButton.Text = "Сохранить";
            this.SaveChildButton.UseVisualStyleBackColor = true;
            this.SaveChildButton.Click += new System.EventHandler(this.SaveChildButton_Click);
            // 
            // subGroupFilter
            // 
            this.subGroupFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subGroupFilter.FormattingEnabled = true;
            this.subGroupFilter.Location = new System.Drawing.Point(12, 99);
            this.subGroupFilter.Name = "subGroupFilter";
            this.subGroupFilter.Size = new System.Drawing.Size(151, 21);
            this.subGroupFilter.TabIndex = 22;
            // 
            // genderBox
            // 
            this.genderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.genderBox.Location = new System.Drawing.Point(12, 60);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(151, 21);
            this.genderBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пол";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Подгруппа";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Имя ребенка";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(12, 25);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(149, 20);
            this.NameTB.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 26);
            this.label7.TabIndex = 27;
            this.label7.Text = "Фильтр по\r\n типу группы";
            // 
            // groupTypeFilter
            // 
            this.groupTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupTypeFilter.FormattingEnabled = true;
            this.groupTypeFilter.Location = new System.Drawing.Point(90, 27);
            this.groupTypeFilter.Name = "groupTypeFilter";
            this.groupTypeFilter.Size = new System.Drawing.Size(130, 21);
            this.groupTypeFilter.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 26);
            this.label8.TabIndex = 29;
            this.label8.Text = "Фильтр по \r\nФИО воспитателя";
            this.label8.Visible = false;
            // 
            // teacherFilterCombo
            // 
            this.teacherFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherFilterCombo.FormattingEnabled = true;
            this.teacherFilterCombo.Location = new System.Drawing.Point(643, 22);
            this.teacherFilterCombo.Name = "teacherFilterCombo";
            this.teacherFilterCombo.Size = new System.Drawing.Size(150, 21);
            this.teacherFilterCombo.TabIndex = 30;
            this.teacherFilterCombo.Visible = false;
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(227, 24);
            this.filterBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(121, 24);
            this.filterBtn.TabIndex = 31;
            this.filterBtn.Text = "Фильтровать";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(354, 24);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(121, 24);
            this.CancelBtn.TabIndex = 32;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ChildName
            // 
            this.ChildName.DataPropertyName = "childName";
            this.ChildName.HeaderText = "Имя ребенка";
            this.ChildName.Name = "ChildName";
            this.ChildName.ReadOnly = true;
            // 
            // id_group
            // 
            this.id_group.DataPropertyName = "id_group";
            this.id_group.HeaderText = "Column1";
            this.id_group.Name = "id_group";
            this.id_group.ReadOnly = true;
            this.id_group.Visible = false;
            // 
            // id_child
            // 
            this.id_child.DataPropertyName = "id_child";
            this.id_child.HeaderText = "Column1";
            this.id_child.Name = "id_child";
            this.id_child.ReadOnly = true;
            this.id_child.Visible = false;
            // 
            // subGroupName
            // 
            this.subGroupName.DataPropertyName = "subGroupName";
            this.subGroupName.HeaderText = "Подруппа";
            this.subGroupName.Name = "subGroupName";
            this.subGroupName.ReadOnly = true;
            // 
            // subGroup
            // 
            this.subGroup.DataPropertyName = "subGroup";
            this.subGroup.HeaderText = "Column1";
            this.subGroup.Name = "subGroup";
            this.subGroup.ReadOnly = true;
            this.subGroup.Visible = false;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "genderText";
            this.Gender.HeaderText = "Пол";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // GenderInt
            // 
            this.GenderInt.DataPropertyName = "Gender";
            this.GenderInt.HeaderText = "Column1";
            this.GenderInt.Name = "GenderInt";
            this.GenderInt.ReadOnly = true;
            this.GenderInt.Visible = false;
            // 
            // ChildName_1
            // 
            this.ChildName_1.DataPropertyName = "name";
            this.ChildName_1.HeaderText = "Column1";
            this.ChildName_1.Name = "ChildName_1";
            this.ChildName_1.ReadOnly = true;
            this.ChildName_1.Visible = false;
            // 
            // fam
            // 
            this.fam.DataPropertyName = "fam";
            this.fam.HeaderText = "Column1";
            this.fam.Name = "fam";
            this.fam.ReadOnly = true;
            this.fam.Visible = false;
            // 
            // GroupChildControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.teacherFilterCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupTypeFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GroupControlPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ChildGridView);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.GroupGridView);
            this.Name = "GroupChildControl";
            this.Size = new System.Drawing.Size(1086, 490);
            ((System.ComponentModel.ISupportInitialize)(this.GroupGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChildGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GroupControlPanel.ResumeLayout(false);
            this.GroupControlPanel.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GroupGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button DeleteGroupBtn;
        private System.Windows.Forms.Button UpdateGroupBtn;
        private System.Windows.Forms.Button AddGroupBtn;
        private System.Windows.Forms.DataGridView ChildGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button DeleteChildBtn;
        private System.Windows.Forms.Button EditChildBtn;
        private System.Windows.Forms.Button AddChildBtn;
        private System.Windows.Forms.Panel GroupControlPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GroupNameTB;
        private System.Windows.Forms.ComboBox groupTypeCombo;
        private System.Windows.Forms.ComboBox teacherCombo;
        private System.Windows.Forms.Button CancelGroupBtn;
        private System.Windows.Forms.Button SaveGroupBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton EditGroupTypes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button CancelChildBtn;
        private System.Windows.Forms.Button SaveChildButton;
        private System.Windows.Forms.ComboBox subGroupFilter;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox groupTypeFilter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox teacherFilterCombo;
        private System.Windows.Forms.ComboBox GroupsCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox FamTB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group_type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChildName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_child;
        private System.Windows.Forms.DataGridViewTextBoxColumn subGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn subGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChildName_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
    }
}