
namespace Document
{
    partial class ChunkListViewer
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
            this.components = new System.ComponentModel.Container();
            this.headerSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtChunk = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).BeginInit();
            this.SuspendLayout();
            // 
            // headerSource
            // 
            this.headerSource.DataSource = typeof(Model.HeaderModel);
            // 
            // txtChunk
            // 
            this.txtChunk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChunk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChunk.Location = new System.Drawing.Point(0, 0);
            this.txtChunk.Name = "txtChunk";
            this.txtChunk.Size = new System.Drawing.Size(584, 361);
            this.txtChunk.TabIndex = 0;
            this.txtChunk.Text = "";
            // 
            // ChunkListViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.txtChunk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HideOnClose = true;
            this.Name = "ChunkListViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Измененные фрагменты";
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource headerSource;
        private System.Windows.Forms.RichTextBox txtChunk;
    }
}