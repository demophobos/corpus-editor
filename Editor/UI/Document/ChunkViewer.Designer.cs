
namespace Document
{
    partial class ChunkViewer
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
            this.lblChunk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChunk
            // 
            this.lblChunk.BackColor = System.Drawing.SystemColors.Info;
            this.lblChunk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChunk.Location = new System.Drawing.Point(0, 0);
            this.lblChunk.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblChunk.Name = "lblChunk";
            this.lblChunk.Size = new System.Drawing.Size(407, 313);
            this.lblChunk.TabIndex = 0;
            // 
            // ChunkViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 313);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lblChunk);
            this.Name = "ChunkViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChunk;
    }
}
