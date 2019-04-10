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
            this.figurePicture = new System.Windows.Forms.PictureBox();
            this.selectFigure = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.famLabel = new System.Windows.Forms.Label();
            this.difficultyCombo = new System.Windows.Forms.ComboBox();
            this.childCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.figurePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartGame.Location = new System.Drawing.Point(12, 327);
            this.StartGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(230, 43);
            this.StartGame.TabIndex = 14;
            this.StartGame.Text = "Начать игру";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // endClass
            // 
            this.endClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endClass.Location = new System.Drawing.Point(285, 327);
            this.endClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.endClass.Name = "endClass";
            this.endClass.Size = new System.Drawing.Size(242, 43);
            this.endClass.TabIndex = 15;
            this.endClass.Text = "Завершить занятие";
            this.endClass.UseVisualStyleBackColor = true;
            this.endClass.Click += new System.EventHandler(this.endClass_Click);
            // 
            // figurePicture
            // 
            this.figurePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.figurePicture.Location = new System.Drawing.Point(0, 0);
            this.figurePicture.Name = "figurePicture";
            this.figurePicture.Size = new System.Drawing.Size(258, 258);
            this.figurePicture.TabIndex = 16;
            this.figurePicture.TabStop = false;
            // 
            // selectFigure
            // 
            this.selectFigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFigure.Location = new System.Drawing.Point(260, 277);
            this.selectFigure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectFigure.Name = "selectFigure";
            this.selectFigure.Size = new System.Drawing.Size(220, 30);
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
            this.panel1.Location = new System.Drawing.Point(238, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 260);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(29, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Уровень сложности";
            // 
            // famLabel
            // 
            this.famLabel.AutoSize = true;
            this.famLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.famLabel.Location = new System.Drawing.Point(29, 28);
            this.famLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.difficultyCombo.Location = new System.Drawing.Point(32, 104);
            this.difficultyCombo.Name = "difficultyCombo";
            this.difficultyCombo.Size = new System.Drawing.Size(163, 21);
            this.difficultyCombo.TabIndex = 20;
            // 
            // childCombo
            // 
            this.childCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.childCombo.FormattingEnabled = true;
            this.childCombo.Items.AddRange(new object[] {
            "<Не выбрано>"});
            this.childCombo.Location = new System.Drawing.Point(32, 47);
            this.childCombo.Name = "childCombo";
            this.childCombo.Size = new System.Drawing.Size(163, 21);
            this.childCombo.TabIndex = 19;
            // 
            // ClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.famLabel);
            this.Controls.Add(this.difficultyCombo);
            this.Controls.Add(this.childCombo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectFigure);
            this.Controls.Add(this.endClass);
            this.Controls.Add(this.StartGame);
            this.Name = "ClassControl";
            this.Text = "Управление занятием";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassControl_FormClosing);
            this.Load += new System.EventHandler(this.ClassControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.figurePicture)).EndInit();
            this.panel1.ResumeLayout(false);
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