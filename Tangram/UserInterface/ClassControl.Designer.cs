namespace Tangram.UserInterface
{
    partial class ClassControl
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
            this.StartGame = new System.Windows.Forms.Button();
            this.endClass = new System.Windows.Forms.Button();
            this.selectFigure = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.figurePicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.famLabel = new System.Windows.Forms.Label();
            this.difficultyCombo = new System.Windows.Forms.ComboBox();
            this.childCombo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.figurePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartGame.Location = new System.Drawing.Point(13, 436);
            this.StartGame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(287, 60);
            this.StartGame.TabIndex = 14;
            this.StartGame.Text = "Начать игру";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // endClass
            // 
            this.endClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endClass.Location = new System.Drawing.Point(351, 436);
            this.endClass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.endClass.Name = "endClass";
            this.endClass.Size = new System.Drawing.Size(298, 60);
            this.endClass.TabIndex = 15;
            this.endClass.Text = "Завершить занятие";
            this.endClass.UseVisualStyleBackColor = true;
            this.endClass.Click += new System.EventHandler(this.endClass_Click);
            // 
            // selectFigure
            // 
            this.selectFigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFigure.Location = new System.Drawing.Point(351, 382);
            this.selectFigure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectFigure.Name = "selectFigure";
            this.selectFigure.Size = new System.Drawing.Size(232, 42);
            this.selectFigure.TabIndex = 17;
            this.selectFigure.Text = "Выбрать фигуру...";
            this.selectFigure.UseVisualStyleBackColor = true;
            this.selectFigure.Click += new System.EventHandler(this.selectFigure_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.figurePicture);
            this.panel1.Location = new System.Drawing.Point(290, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 359);
            this.panel1.TabIndex = 18;
            // 
            // figurePicture
            // 
            this.figurePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.figurePicture.Location = new System.Drawing.Point(0, 0);
            this.figurePicture.Margin = new System.Windows.Forms.Padding(4);
            this.figurePicture.Name = "figurePicture";
            this.figurePicture.Size = new System.Drawing.Size(357, 357);
            this.figurePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.figurePicture.TabIndex = 16;
            this.figurePicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Уровень сложности";
            // 
            // famLabel
            // 
            this.famLabel.AutoSize = true;
            this.famLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.famLabel.Location = new System.Drawing.Point(39, 52);
            this.famLabel.Name = "famLabel";
            this.famLabel.Size = new System.Drawing.Size(64, 16);
            this.famLabel.TabIndex = 21;
            this.famLabel.Text = "Ребенок";
            // 
            // difficultyCombo
            // 
            this.difficultyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyCombo.FormattingEnabled = true;
            this.difficultyCombo.Items.AddRange(new object[] {
            "С контуром ",
            "Без контура"});
            this.difficultyCombo.Location = new System.Drawing.Point(42, 140);
            this.difficultyCombo.Margin = new System.Windows.Forms.Padding(4);
            this.difficultyCombo.Name = "difficultyCombo";
            this.difficultyCombo.Size = new System.Drawing.Size(179, 26);
            this.difficultyCombo.TabIndex = 20;
            // 
            // childCombo
            // 
            this.childCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.childCombo.FormattingEnabled = true;
            this.childCombo.Items.AddRange(new object[] {
            "<Не выбрано>"});
            this.childCombo.Location = new System.Drawing.Point(42, 72);
            this.childCombo.Margin = new System.Windows.Forms.Padding(4);
            this.childCombo.Name = "childCombo";
            this.childCombo.Size = new System.Drawing.Size(179, 26);
            this.childCombo.TabIndex = 19;
            // 
            // ClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 508);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.famLabel);
            this.Controls.Add(this.difficultyCombo);
            this.Controls.Add(this.childCombo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectFigure);
            this.Controls.Add(this.endClass);
            this.Controls.Add(this.StartGame);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClassControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление занятием";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassControl_FormClosing);
            this.Load += new System.EventHandler(this.ClassControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.figurePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button endClass;
        private System.Windows.Forms.PictureBox figurePicture;
        private System.Windows.Forms.Button selectFigure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label famLabel;
        private System.Windows.Forms.ComboBox difficultyCombo;
        private System.Windows.Forms.ComboBox childCombo;
    }
}