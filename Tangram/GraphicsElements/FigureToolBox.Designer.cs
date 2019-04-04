namespace Tangram.GraphicsElements
{
    partial class FigureToolBox
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
            this.SuspendLayout();
            // 
            // FigureToolBox
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(409, 301);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FigureToolBox_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
