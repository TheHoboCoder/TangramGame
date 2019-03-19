namespace Tangram
{
    partial class TestForm3
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
            this.AddButton = new System.Windows.Forms.Button();
            this.figureTypeCombo = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorPreview = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.designerCanvas1 = new Tangram.GraphicsElements.DesignerCanvas();
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(609, 122);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(241, 81);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // figureTypeCombo
            // 
            this.figureTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureTypeCombo.FormattingEnabled = true;
            this.figureTypeCombo.Location = new System.Drawing.Point(609, 95);
            this.figureTypeCombo.Name = "figureTypeCombo";
            this.figureTypeCombo.Size = new System.Drawing.Size(241, 21);
            this.figureTypeCombo.TabIndex = 2;
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.DarkOrange;
            this.colorPreview.Location = new System.Drawing.Point(609, 50);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(102, 39);
            this.colorPreview.TabIndex = 3;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(717, 50);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(110, 39);
            this.colorButton.TabIndex = 4;
            this.colorButton.Text = "Цвет...";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // designerCanvas1
            // 
            this.designerCanvas1.AngleSnapEnabled = false;
            this.designerCanvas1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.designerCanvas1.CurrentMode = Tangram.GraphicsElements.DesignerCanvas.Mode.MOVE;
            this.designerCanvas1.GridEnabled = false;
            this.designerCanvas1.GridSnapEnabled = false;
            this.designerCanvas1.Location = new System.Drawing.Point(28, 50);
            this.designerCanvas1.Name = "designerCanvas1";
            this.designerCanvas1.Size = new System.Drawing.Size(564, 346);
            this.designerCanvas1.SnapAngle = 0F;
            this.designerCanvas1.TabIndex = 0;
            this.designerCanvas1.TabStop = false;
            // 
            // TestForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(886, 450);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.colorPreview);
            this.Controls.Add(this.figureTypeCombo);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.designerCanvas1);
            this.Name = "TestForm3";
            this.Text = "TestForm3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestForm3_FormClosed);
            this.Load += new System.EventHandler(this.TestForm3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestForm3_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestForm3_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TestForm3_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.designerCanvas1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GraphicsElements.DesignerCanvas designerCanvas1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ComboBox figureTypeCombo;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel colorPreview;
        private System.Windows.Forms.Button colorButton;
    }
}