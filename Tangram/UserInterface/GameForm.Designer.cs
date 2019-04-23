namespace Tangram.UserInterface
{
    partial class GameForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.figureToolBox1 = new Tangram.GraphicsElements.FigureToolBox();
            this.ChildName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.canvasPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.figureToolBox1);
            this.splitContainer1.Size = new System.Drawing.Size(901, 432);
            this.splitContainer1.SplitterDistance = 579;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 4;
            // 
            // canvasPanel
            // 
            this.canvasPanel.AutoScroll = true;
            this.canvasPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Margin = new System.Windows.Forms.Padding(4);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(579, 432);
            this.canvasPanel.TabIndex = 1;
            // 
            // figureToolBox1
            // 
            this.figureToolBox1.AutoScroll = true;
            this.figureToolBox1.BackColor = System.Drawing.Color.Transparent;
            this.figureToolBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.figureToolBox1.Location = new System.Drawing.Point(0, 0);
            this.figureToolBox1.Margin = new System.Windows.Forms.Padding(4);
            this.figureToolBox1.Name = "figureToolBox1";
            this.figureToolBox1.Padding = new System.Windows.Forms.Padding(15, 14, 15, 14);
            this.figureToolBox1.Size = new System.Drawing.Size(316, 432);
            this.figureToolBox1.TabIndex = 0;
            // 
            // ChildName
            // 
            this.ChildName.AutoSize = true;
            this.ChildName.Location = new System.Drawing.Point(23, 19);
            this.ChildName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ChildName.Name = "ChildName";
            this.ChildName.Size = new System.Drawing.Size(50, 18);
            this.ChildName.TabIndex = 5;
            this.ChildName.Text = "label1";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 486);
            this.Controls.Add(this.ChildName);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel canvasPanel;
        private GraphicsElements.FigureToolBox figureToolBox1;
        private System.Windows.Forms.Label ChildName;
    }
}