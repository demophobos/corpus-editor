
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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.loader1 = new Common.Control.Loader();
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).BeginInit();
            this.SuspendLayout();
            // 
            // headerSource
            // 
            this.headerSource.DataSource = typeof(Model.HeaderModel);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.ColumnCount = 2;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panel.Size = new System.Drawing.Size(584, 361);
            this.panel.TabIndex = 0;
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 0);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(584, 361);
            this.loader1.TabIndex = 0;
            // 
            // ChunkListViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.loader1);
            this.Controls.Add(this.panel);
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
        private System.Windows.Forms.TableLayoutPanel panel;
        private Common.Control.Loader loader1;
    }
}