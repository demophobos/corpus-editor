
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
            this.loader1 = new Common.Control.Loader();
            this.SuspendLayout();
            // 
            // lblChunk
            // 
            this.lblChunk.BackColor = System.Drawing.SystemColors.Info;
            this.lblChunk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChunk.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChunk.Location = new System.Drawing.Point(0, 0);
            this.lblChunk.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblChunk.Name = "lblChunk";
            this.lblChunk.Size = new System.Drawing.Size(582, 332);
            this.lblChunk.TabIndex = 0;
            // 
            // loader1
            // 
            this.loader1.BackColor = System.Drawing.SystemColors.Info;
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 0);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(582, 332);
            this.loader1.TabIndex = 1;
            // 
            // ChunkViewer
            // 
            this.AllowEndUserDocking = false;
            this.AutoHidePortion = 0.5D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 332);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.lblChunk);
            this.Controls.Add(this.loader1);
            this.Name = "ChunkViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChunk;
        private Common.Control.Loader loader1;
    }
}
