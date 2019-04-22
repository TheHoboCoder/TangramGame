namespace Tangram.UserInterface
{
    partial class UserTableControl
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.rolesFilterCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.famFilter = new System.Windows.Forms.TextBox();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FamTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.Имя = new System.Windows.Forms.Label();
            this.OtchTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PhoneTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rolesCombo = new System.Windows.Forms.ComboBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.role_id,
            this.id_user,
            this.fam,
            this.name,
            this.otch,
            this.userName,
            this.Password,
            this.Phone,
            this.Role});
            this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView.Location = new System.Drawing.Point(4, 51);
            this.GridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GridView.MultiSelect = false;
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(791, 204);
            this.GridView.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.DataPropertyName = "login";
            this.Login.HeaderText = "Логин";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // role_id
            // 
            this.role_id.DataPropertyName = "role_id";
            this.role_id.HeaderText = "role_id";
            this.role_id.Name = "role_id";
            this.role_id.ReadOnly = true;
            this.role_id.Visible = false;
            // 
            // id_user
            // 
            this.id_user.DataPropertyName = "id_user";
            this.id_user.HeaderText = "Column1";
            this.id_user.Name = "id_user";
            this.id_user.ReadOnly = true;
            this.id_user.Visible = false;
            // 
            // fam
            // 
            this.fam.DataPropertyName = "fam";
            this.fam.HeaderText = "fam";
            this.fam.Name = "fam";
            this.fam.ReadOnly = true;
            this.fam.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Visible = false;
            // 
            // otch
            // 
            this.otch.DataPropertyName = "otch";
            this.otch.HeaderText = "otch";
            this.otch.Name = "otch";
            this.otch.ReadOnly = true;
            this.otch.Visible = false;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "usersInitials";
            this.userName.HeaderText = "Ф.И.О.";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "g";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "phone";
            this.Phone.HeaderText = "Контактный телефон";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "role_name";
            this.Role.HeaderText = "Должность";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фильтр по должности";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rolesFilterCombo
            // 
            this.rolesFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolesFilterCombo.FormattingEnabled = true;
            this.rolesFilterCombo.Items.AddRange(new object[] {
            "<не выбрано>",
            "Воспитатель",
            "Методист"});
            this.rolesFilterCombo.Location = new System.Drawing.Point(662, 4);
            this.rolesFilterCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rolesFilterCombo.Name = "rolesFilterCombo";
            this.rolesFilterCombo.Size = new System.Drawing.Size(226, 26);
            this.rolesFilterCombo.TabIndex = 2;
            this.rolesFilterCombo.DropDownClosed += new System.EventHandler(this.rolesFilterCombo_DropDownClosed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фильтр по фамилии:";
            // 
            // famFilter
            // 
            this.famFilter.Location = new System.Drawing.Point(168, 5);
            this.famFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.famFilter.Name = "famFilter";
            this.famFilter.Size = new System.Drawing.Size(268, 26);
            this.famFilter.TabIndex = 4;
            this.famFilter.TextChanged += new System.EventHandler(this.famFilter_TextChanged);
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(4, 22);
            this.LoginTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(203, 26);
            this.LoginTB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Логин:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Фамилия:";
            // 
            // FamTB
            // 
            this.FamTB.Location = new System.Drawing.Point(232, 22);
            this.FamTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FamTB.Name = "FamTB";
            this.FamTB.Size = new System.Drawing.Size(202, 26);
            this.FamTB.TabIndex = 8;
            this.FamTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FamTB_KeyPress);
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(232, 126);
            this.NameTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(202, 26);
            this.NameTB.TabIndex = 10;
            this.NameTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FamTB_KeyPress);
            // 
            // Имя
            // 
            this.Имя.AutoSize = true;
            this.Имя.Location = new System.Drawing.Point(229, 52);
            this.Имя.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Имя.Name = "Имя";
            this.Имя.Size = new System.Drawing.Size(44, 18);
            this.Имя.TabIndex = 9;
            this.Имя.Text = "Имя:";
            // 
            // OtchTB
            // 
            this.OtchTB.Location = new System.Drawing.Point(232, 74);
            this.OtchTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OtchTB.Name = "OtchTB";
            this.OtchTB.Size = new System.Drawing.Size(202, 26);
            this.OtchTB.TabIndex = 12;
            this.OtchTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FamTB_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Отчество:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Телефон:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // PhoneTB
            // 
            this.PhoneTB.Location = new System.Drawing.Point(452, 22);
            this.PhoneTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PhoneTB.Name = "PhoneTB";
            this.PhoneTB.Size = new System.Drawing.Size(202, 26);
            this.PhoneTB.TabIndex = 14;
            this.PhoneTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneTB_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(449, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Должность";
            // 
            // rolesCombo
            // 
            this.rolesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolesCombo.FormattingEnabled = true;
            this.rolesCombo.Items.AddRange(new object[] {
            "Воспитатель",
            "Методист"});
            this.rolesCombo.Location = new System.Drawing.Point(452, 74);
            this.rolesCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rolesCombo.Name = "rolesCombo";
            this.rolesCombo.Size = new System.Drawing.Size(202, 26);
            this.rolesCombo.TabIndex = 16;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelBtn.Location = new System.Drawing.Point(232, 93);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(221, 51);
            this.CancelBtn.TabIndex = 20;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginBtn.Location = new System.Drawing.Point(4, 93);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(220, 51);
            this.LoginBtn.TabIndex = 19;
            this.LoginBtn.Text = "Сохранить";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(4, 52);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(63, 18);
            this.passwordLabel.TabIndex = 21;
            this.passwordLabel.Text = "Пароль";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(4, 74);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(203, 26);
            this.PasswordTB.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ControlPanel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.GridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.83333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.0531F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.28318F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(799, 466);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.DeleteBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.UpdateBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 263);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(791, 46);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.famFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rolesFilterCombo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 39);
            this.panel1.TabIndex = 19;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ControlPanel.Controls.Add(this.CancelBtn);
            this.ControlPanel.Controls.Add(this.LoginBtn);
            this.ControlPanel.Controls.Add(this.rolesCombo);
            this.ControlPanel.Controls.Add(this.label7);
            this.ControlPanel.Controls.Add(this.PhoneTB);
            this.ControlPanel.Controls.Add(this.label6);
            this.ControlPanel.Controls.Add(this.NameTB);
            this.ControlPanel.Controls.Add(this.Имя);
            this.ControlPanel.Controls.Add(this.label5);
            this.ControlPanel.Controls.Add(this.FamTB);
            this.ControlPanel.Controls.Add(this.OtchTB);
            this.ControlPanel.Controls.Add(this.label4);
            this.ControlPanel.Controls.Add(this.PasswordTB);
            this.ControlPanel.Controls.Add(this.passwordLabel);
            this.ControlPanel.Controls.Add(this.LoginTB);
            this.ControlPanel.Controls.Add(this.label3);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel.Location = new System.Drawing.Point(3, 316);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(793, 147);
            this.ControlPanel.TabIndex = 24;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteBtn.Image = global::Tangram.Properties.Resources.delete;
            this.DeleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteBtn.Location = new System.Drawing.Point(530, 3);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(257, 40);
            this.DeleteBtn.TabIndex = 24;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateBtn.Image = global::Tangram.Properties.Resources.pencil;
            this.UpdateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateBtn.Location = new System.Drawing.Point(267, 3);
            this.UpdateBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(255, 40);
            this.UpdateBtn.TabIndex = 23;
            this.UpdateBtn.Text = "Редактировать";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBtn.Image = global::Tangram.Properties.Resources.plus;
            this.AddBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddBtn.Location = new System.Drawing.Point(4, 3);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(255, 40);
            this.AddBtn.TabIndex = 22;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // UserTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserTableControl";
            this.Size = new System.Drawing.Size(799, 466);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rolesFilterCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox famFilter;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FamTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label Имя;
        private System.Windows.Forms.TextBox OtchTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PhoneTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox rolesCombo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn fam;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn otch;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ControlPanel;
    }
}
