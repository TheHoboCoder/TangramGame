namespace Tangram.UserInterface
{
    partial class FigureDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FigureDesigner));
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.AddFigureGroup = new System.Windows.Forms.ToolStripButton();
            this.figureTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FigureNameTB = new System.Windows.Forms.TextBox();
            this.famLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Designer = new System.Windows.Forms.TableLayoutPanel();
            this.MainToolBox = new System.Windows.Forms.ToolStrip();
            this.gridSnapBtn = new System.Windows.Forms.ToolStripButton();
            this.PickColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoButton = new System.Windows.Forms.ToolStripButton();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.designerCanvas = new Tangram.GraphicsElements.DesignerCanvas();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SelectMode = new System.Windows.Forms.ToolStripButton();
            this.PanMode = new System.Windows.Forms.ToolStripButton();
            this.figureToolBox1 = new Tangram.GraphicsElements.FigureToolBox();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Designer.SuspendLayout();
            this.MainToolBox.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить фигуру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.toolStrip2);
            this.panel2.Controls.Add(this.figureTypeCombo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.FigureNameTB);
            this.panel2.Controls.Add(this.famLabel);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(990, 56);
            this.panel2.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFigureGroup});
            this.toolStrip2.Location = new System.Drawing.Point(805, 17);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(35, 25);
            this.toolStrip2.TabIndex = 27;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // AddFigureGroup
            // 
            this.AddFigureGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFigureGroup.Image = global::Tangram.Properties.Resources.plus_green;
            this.AddFigureGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFigureGroup.Name = "AddFigureGroup";
            this.AddFigureGroup.Size = new System.Drawing.Size(23, 22);
            this.AddFigureGroup.Text = "toolStripButton1";
            this.AddFigureGroup.Click += new System.EventHandler(this.AddFigureGroup_Click);
            // 
            // figureTypeCombo
            // 
            this.figureTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureTypeCombo.FormattingEnabled = true;
            this.figureTypeCombo.Location = new System.Drawing.Point(645, 16);
            this.figureTypeCombo.Name = "figureTypeCombo";
            this.figureTypeCombo.Size = new System.Drawing.Size(157, 26);
            this.figureTypeCombo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(549, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Тип фигуры";
            // 
            // FigureNameTB
            // 
            this.FigureNameTB.Location = new System.Drawing.Point(338, 17);
            this.FigureNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.FigureNameTB.Name = "FigureNameTB";
            this.FigureNameTB.Size = new System.Drawing.Size(190, 26);
            this.FigureNameTB.TabIndex = 13;
            // 
            // famLabel
            // 
            this.famLabel.AutoSize = true;
            this.famLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.famLabel.Location = new System.Drawing.Point(197, 20);
            this.famLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.famLabel.Name = "famLabel";
            this.famLabel.Size = new System.Drawing.Size(137, 18);
            this.famLabel.TabIndex = 12;
            this.famLabel.Text = "Название фигуры";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Designer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.figureToolBox1);
            this.splitContainer1.Size = new System.Drawing.Size(990, 424);
            this.splitContainer1.SplitterDistance = 631;
            this.splitContainer1.TabIndex = 3;
            // 
            // Designer
            // 
            this.Designer.ColumnCount = 2;
            this.Designer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.Designer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Designer.Controls.Add(this.MainToolBox, 1, 0);
            this.Designer.Controls.Add(this.canvasPanel, 1, 1);
            this.Designer.Controls.Add(this.toolStrip1, 0, 1);
            this.Designer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Designer.Location = new System.Drawing.Point(0, 0);
            this.Designer.Name = "Designer";
            this.Designer.RowCount = 2;
            this.Designer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.Designer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Designer.Size = new System.Drawing.Size(631, 424);
            this.Designer.TabIndex = 2;
            this.Designer.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // MainToolBox
            // 
            this.MainToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSnapBtn,
            this.PickColor,
            this.toolStripSeparator1,
            this.InfoButton});
            this.MainToolBox.Location = new System.Drawing.Point(38, 0);
            this.MainToolBox.Name = "MainToolBox";
            this.MainToolBox.Size = new System.Drawing.Size(593, 32);
            this.MainToolBox.TabIndex = 0;
            this.MainToolBox.Text = "toolStrip1";
            // 
            // gridSnapBtn
            // 
            this.gridSnapBtn.BackColor = System.Drawing.SystemColors.Control;
            this.gridSnapBtn.Checked = true;
            this.gridSnapBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridSnapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gridSnapBtn.Image = global::Tangram.Properties.Resources.grid_snap;
            this.gridSnapBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gridSnapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gridSnapBtn.Name = "gridSnapBtn";
            this.gridSnapBtn.Size = new System.Drawing.Size(28, 29);
            this.gridSnapBtn.Text = "Отключить привязку к сетке";
            this.gridSnapBtn.Click += new System.EventHandler(this.gridSnapBtn_Click);
            // 
            // PickColor
            // 
            this.PickColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PickColor.Image = global::Tangram.Properties.Resources.color_small;
            this.PickColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PickColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PickColor.Name = "PickColor";
            this.PickColor.Size = new System.Drawing.Size(28, 29);
            this.PickColor.Text = "Выбор цвета";
            this.PickColor.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // InfoButton
            // 
            this.InfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoButton.Image = global::Tangram.Properties.Resources.info_small;
            this.InfoButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InfoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(28, 29);
            this.InfoButton.Text = "Информация";
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // canvasPanel
            // 
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.canvasPanel.Controls.Add(this.designerCanvas);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(41, 35);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(587, 386);
            this.canvasPanel.TabIndex = 1;
            // 
            // designerCanvas
            // 
            this.designerCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.designerCanvas.CurrentMode = Tangram.GraphicsElements.DesignerCanvas.Mode.SELECT;
            this.designerCanvas.FigureColors = System.Drawing.Color.Orange;
            this.designerCanvas.GridEnabled = false;
            this.designerCanvas.GridSnapEnabled = true;
            this.designerCanvas.Location = new System.Drawing.Point(46, 43);
            this.designerCanvas.Name = "designerCanvas";
            this.designerCanvas.Size = new System.Drawing.Size(498, 307);
            this.designerCanvas.SnapAngle = 45F;
            this.designerCanvas.SnapDistance = 20F;
            this.designerCanvas.TabIndex = 0;
            this.designerCanvas.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectMode,
            this.PanMode});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(38, 392);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SelectMode
            // 
            this.SelectMode.Checked = true;
            this.SelectMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectMode.Image = global::Tangram.Properties.Resources.cursor;
            this.SelectMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectMode.Name = "SelectMode";
            this.SelectMode.Size = new System.Drawing.Size(36, 20);
            this.SelectMode.Text = "Режим выбора";
            this.SelectMode.Click += new System.EventHandler(this.SelectMode_Click);
            // 
            // PanMode
            // 
            this.PanMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanMode.Image = global::Tangram.Properties.Resources.hand;
            this.PanMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanMode.Name = "PanMode";
            this.PanMode.Size = new System.Drawing.Size(36, 20);
            this.PanMode.Text = "Перемещение";
            this.PanMode.Click += new System.EventHandler(this.PanMode_Click);
            // 
            // figureToolBox1
            // 
            this.figureToolBox1.AutoScroll = true;
            this.figureToolBox1.BackColor = System.Drawing.Color.Transparent;
            this.figureToolBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.figureToolBox1.Location = new System.Drawing.Point(0, 0);
            this.figureToolBox1.Name = "figureToolBox1";
            this.figureToolBox1.Padding = new System.Windows.Forms.Padding(10);
            this.figureToolBox1.Size = new System.Drawing.Size(355, 424);
            this.figureToolBox1.TabIndex = 0;
            // 
            // FigureDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 480);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FigureDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование фигур";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FigureDesigner_FormClosing);
            this.Load += new System.EventHandler(this.FigureDesigner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FigureDesigner_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Designer.ResumeLayout(false);
            this.Designer.PerformLayout();
            this.MainToolBox.ResumeLayout(false);
            this.MainToolBox.PerformLayout();
            this.canvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GraphicsElements.DesignerCanvas designerCanvas;
        private GraphicsElements.FigureToolBox figureToolBox1;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FigureNameTB;
        private System.Windows.Forms.Label famLabel;
        private System.Windows.Forms.ComboBox figureTypeCombo;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddFigureGroup;
        private System.Windows.Forms.TableLayoutPanel Designer;
        private System.Windows.Forms.ToolStrip MainToolBox;
        private System.Windows.Forms.ToolStripButton PickColor;
        private System.Windows.Forms.ToolStripButton InfoButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SelectMode;
        private System.Windows.Forms.ToolStripButton PanMode;
        private System.Windows.Forms.ToolStripButton gridSnapBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}