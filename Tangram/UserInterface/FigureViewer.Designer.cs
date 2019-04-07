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
            this.GroupList = new System.Windows.Forms.ListBox();
            this.figureView = new System.Windows.Forms.ListView();
            this.groupsControl = new System.Windows.Forms.ToolStrip();
            this.AddGroup = new System.Windows.Forms.ToolStripButton();
            this.EditGroup = new System.Windows.Forms.ToolStripButton();
            this.DeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.figuresControl = new System.Windows.Forms.ToolStrip();
            this.AddFigure = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupsControl.SuspendLayout();
            this.figuresControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupList
            // 
            this.GroupList.FormattingEnabled = true;
            this.GroupList.ItemHeight = 14;
            this.GroupList.Location = new System.Drawing.Point(13, 37);
            this.GroupList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(183, 158);
            this.GroupList.TabIndex = 0;
            // 
            // figureView
            // 
            this.figureView.Location = new System.Drawing.Point(204, 37);
            this.figureView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.figureView.Name = "figureView";
            this.figureView.Size = new System.Drawing.Size(452, 270);
            this.figureView.TabIndex = 1;
            this.figureView.UseCompatibleStateImageBehavior = false;
            // 
            // groupsControl
            // 
            this.groupsControl.Dock = System.Windows.Forms.DockStyle.None;
            this.groupsControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddGroup,
            this.EditGroup,
            this.DeleteGroup});
            this.groupsControl.Location = new System.Drawing.Point(17, 9);
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
            this.toolStripButton2,
            this.toolStripButton3});
            this.figuresControl.Location = new System.Drawing.Point(208, 9);
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
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Tangram.Properties.Resources.pencil;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Редактировать фигуру";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Tangram.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Удалить фигуру";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(363, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Отбор";
            // 
            // FigureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.figuresControl);
            this.Controls.Add(this.groupsControl);
            this.Controls.Add(this.figureView);
            this.Controls.Add(this.GroupList);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FigureViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр фигур";
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
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}