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
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.figureTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FigureNameTB = new System.Windows.Forms.TextBox();
            this.famLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.designerCanvas = new Tangram.GraphicsElements.DesignerCanvas();
            this.figureToolBox1 = new Tangram.GraphicsElements.FigureToolBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas)).BeginInit();
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
            this.panel2.Controls.Add(this.figureTypeCombo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.FigureNameTB);
            this.panel2.Controls.Add(this.famLabel);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(919, 56);
            this.panel2.TabIndex = 2;
            // 
            // figureTypeCombo
            // 
            this.figureTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureTypeCombo.FormattingEnabled = true;
            this.figureTypeCombo.Location = new System.Drawing.Point(626, 18);
            this.figureTypeCombo.Name = "figureTypeCombo";
            this.figureTypeCombo.Size = new System.Drawing.Size(157, 21);
            this.figureTypeCombo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(533, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Тип фигуры";
            // 
            // FigureNameTB
            // 
            this.FigureNameTB.Location = new System.Drawing.Point(326, 19);
            this.FigureNameTB.Margin = new System.Windows.Forms.Padding(2);
            this.FigureNameTB.Name = "FigureNameTB";
            this.FigureNameTB.Size = new System.Drawing.Size(190, 20);
            this.FigureNameTB.TabIndex = 13;
            // 
            // famLabel
            // 
            this.famLabel.AutoSize = true;
            this.famLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.famLabel.Location = new System.Drawing.Point(197, 20);
            this.famLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.famLabel.Name = "famLabel";
            this.famLabel.Size = new System.Drawing.Size(127, 16);
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
            this.splitContainer1.Panel1.Controls.Add(this.canvasPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.figureToolBox1);
            this.splitContainer1.Size = new System.Drawing.Size(919, 441);
            this.splitContainer1.SplitterDistance = 595;
            this.splitContainer1.TabIndex = 3;
            // 
            // canvasPanel
            // 
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.canvasPanel.Controls.Add(this.designerCanvas);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(595, 441);
            this.canvasPanel.TabIndex = 1;
            // 
            // designerCanvas
            // 
            this.designerCanvas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.designerCanvas.CurrentMode = Tangram.GraphicsElements.DesignerCanvas.Mode.MOVE;
            this.designerCanvas.GridEnabled = false;
            this.designerCanvas.GridSnapEnabled = false;
            this.designerCanvas.Location = new System.Drawing.Point(8, 0);
            this.designerCanvas.Name = "designerCanvas";
            this.designerCanvas.Size = new System.Drawing.Size(548, 438);
            this.designerCanvas.SnapAngle = 45F;
            this.designerCanvas.SnapDistance = 0F;
            this.designerCanvas.TabIndex = 0;
            this.designerCanvas.TabStop = false;
            // 
            // figureToolBox1
            // 
            this.figureToolBox1.AutoScroll = true;
            this.figureToolBox1.BackColor = System.Drawing.Color.Transparent;
            this.figureToolBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.figureToolBox1.Location = new System.Drawing.Point(0, 0);
            this.figureToolBox1.Name = "figureToolBox1";
            this.figureToolBox1.Padding = new System.Windows.Forms.Padding(10);
            this.figureToolBox1.Size = new System.Drawing.Size(320, 441);
            this.figureToolBox1.TabIndex = 0;
            // 
            // FigureDesigner
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 497);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "FigureDesigner";
            this.Text = "Редактирование фигур";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FigureDesigner_FormClosing);
            this.Load += new System.EventHandler(this.FigureDesigner_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.canvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas)).EndInit();
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
    }
}