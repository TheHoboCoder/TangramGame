namespace Tangram.UserInterface
{
    partial class FigureViewer
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("еннн", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("почка", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("пам", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("точка", 0);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("роккк");
            this.GroupList = new System.Windows.Forms.ListBox();
            this.figureView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupsControl = new System.Windows.Forms.ToolStrip();
            this.AddGroup = new System.Windows.Forms.ToolStripButton();
            this.EditGroup = new System.Windows.Forms.ToolStripButton();
            this.DeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.figuresControl = new System.Windows.Forms.ToolStrip();
            this.AddFigure = new System.Windows.Forms.ToolStripButton();
            this.editFigure = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.userFilterCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showAllBtn = new System.Windows.Forms.Button();
            this.hint = new System.Windows.Forms.Label();
            this.groupsControl.SuspendLayout();
            this.figuresControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupList
            // 
            this.GroupList.FormattingEnabled = true;
            this.GroupList.ItemHeight = 18;
            this.GroupList.Location = new System.Drawing.Point(15, 48);
            this.GroupList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(205, 202);
            this.GroupList.TabIndex = 0;
            // 
            // figureView
            // 
            this.figureView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            listViewGroup1.Header = "еннн";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup1.Tag = "пам";
            listViewGroup2.Header = "почка";
            listViewGroup2.Name = "listViewGroup2";
            this.figureView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            listViewItem1.Group = listViewGroup2;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup2;
            this.figureView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.figureView.Location = new System.Drawing.Point(230, 48);
            this.figureView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.figureView.MultiSelect = false;
            this.figureView.Name = "figureView";
            this.figureView.Size = new System.Drawing.Size(551, 331);
            this.figureView.TabIndex = 1;
            this.figureView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "бам";
            // 
            // groupsControl
            // 
            this.groupsControl.Dock = System.Windows.Forms.DockStyle.None;
            this.groupsControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroup,
            this.EditGroup,
            this.DeleteGroup});
            this.groupsControl.Location = new System.Drawing.Point(19, 12);
            this.groupsControl.Name = "groupsControl";
            this.groupsControl.Size = new System.Drawing.Size(81, 25);
            this.groupsControl.TabIndex = 18;
            this.groupsControl.Text = "groupControlPanael";
            // 
            // AddGroup
            // 
            this.AddGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddGroup.Image = global::Tangram.Properties.Resources.plus_green;
            this.AddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(23, 22);
            this.AddGroup.Text = "Добавить";
            this.AddGroup.ToolTipText = "Добавить группу";
            this.AddGroup.Click += new System.EventHandler(this.AddGroup_Click);
            // 
            // EditGroup
            // 
            this.EditGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditGroup.Image = global::Tangram.Properties.Resources.pencil;
            this.EditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditGroup.Name = "EditGroup";
            this.EditGroup.Size = new System.Drawing.Size(23, 22);
            this.EditGroup.Text = "Редактировать группу";
            this.EditGroup.Click += new System.EventHandler(this.EditGroup_Click);
            // 
            // DeleteGroup
            // 
            this.DeleteGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteGroup.Image = global::Tangram.Properties.Resources.delete;
            this.DeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteGroup.Name = "DeleteGroup";
            this.DeleteGroup.Size = new System.Drawing.Size(23, 22);
            this.DeleteGroup.Text = "Удалить группу";
            this.DeleteGroup.Click += new System.EventHandler(this.DeleteGroup_Click);
            // 
            // figuresControl
            // 
            this.figuresControl.Dock = System.Windows.Forms.DockStyle.None;
            this.figuresControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFigure,
            this.editFigure,
            this.toolStripButton3});
            this.figuresControl.Location = new System.Drawing.Point(234, 12);
            this.figuresControl.Name = "figuresControl";
            this.figuresControl.Size = new System.Drawing.Size(81, 25);
            this.figuresControl.TabIndex = 19;
            this.figuresControl.Text = "groupControlPanael";
            // 
            // AddFigure
            // 
            this.AddFigure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFigure.Image = global::Tangram.Properties.Resources.plus_green;
            this.AddFigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFigure.Name = "AddFigure";
            this.AddFigure.Size = new System.Drawing.Size(23, 22);
            this.AddFigure.Text = "Добавить фигуру";
            this.AddFigure.ToolTipText = "Добавить фигуру";
            this.AddFigure.Click += new System.EventHandler(this.AddFigure_Click);
            // 
            // editFigure
            // 
            this.editFigure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editFigure.Image = global::Tangram.Properties.Resources.pencil;
            this.editFigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editFigure.Name = "editFigure";
            this.editFigure.Size = new System.Drawing.Size(23, 22);
            this.editFigure.Text = "Редактировать фигуру";
            this.editFigure.Click += new System.EventHandler(this.editFigure_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Tangram.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Удалить фигуру";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // userFilterCombo
            // 
            this.userFilterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userFilterCombo.FormattingEnabled = true;
            this.userFilterCombo.Items.AddRange(new object[] {
            "<Не выбрано>",
            "Мои фигуры",
            "Не мои фигуры"});
            this.userFilterCombo.Location = new System.Drawing.Point(408, 14);
            this.userFilterCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userFilterCombo.Name = "userFilterCombo";
            this.userFilterCombo.Size = new System.Drawing.Size(172, 26);
            this.userFilterCombo.TabIndex = 20;
            this.userFilterCombo.SelectedIndexChanged += new System.EventHandler(this.userFilterCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Отбор";
            // 
            // showAllBtn
            // 
            this.showAllBtn.Location = new System.Drawing.Point(14, 258);
            this.showAllBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(207, 49);
            this.showAllBtn.TabIndex = 22;
            this.showAllBtn.Text = "Показать все";
            this.showAllBtn.UseVisualStyleBackColor = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // hint
            // 
            this.hint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hint.AutoSize = true;
            this.hint.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hint.Location = new System.Drawing.Point(16, 393);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(241, 14);
            this.hint.TabIndex = 23;
            this.hint.Text = "Выберите фигуру двойным щелчком";
            this.hint.Visible = false;
            // 
            // FigureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 414);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.showAllBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userFilterCombo);
            this.Controls.Add(this.figuresControl);
            this.Controls.Add(this.groupsControl);
            this.Controls.Add(this.figureView);
            this.Controls.Add(this.GroupList);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FigureViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр фигур";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FigureViewer_FormClosing);
            this.Load += new System.EventHandler(this.FigureViewer_Load);
            this.groupsControl.ResumeLayout(false);
            this.groupsControl.PerformLayout();
            this.figuresControl.ResumeLayout(false);
            this.figuresControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox GroupList;
        private System.Windows.Forms.ListView figureView;
        private System.Windows.Forms.ToolStrip groupsControl;
        private System.Windows.Forms.ToolStripButton AddGroup;
        private System.Windows.Forms.ToolStripButton EditGroup;
        private System.Windows.Forms.ToolStripButton DeleteGroup;
        private System.Windows.Forms.ToolStrip figuresControl;
        private System.Windows.Forms.ToolStripButton AddFigure;
        private System.Windows.Forms.ToolStripButton editFigure;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ComboBox userFilterCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button showAllBtn;
        private System.Windows.Forms.Label hint;
    }
}