
namespace Document
{
    partial class ChunkExportSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChunkExportSelector));
            this.rbtnText = new System.Windows.Forms.RadioButton();
            this.rbtnIndex = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtIndeces = new System.Windows.Forms.TextBox();
            this.chkChildren = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rbtnText
            // 
            this.rbtnText.AutoSize = true;
            this.rbtnText.Checked = true;
            this.rbtnText.Location = new System.Drawing.Point(12, 13);
            this.rbtnText.Name = "rbtnText";
            this.rbtnText.Size = new System.Drawing.Size(81, 17);
            this.rbtnText.TabIndex = 0;
            this.rbtnText.TabStop = true;
            this.rbtnText.Text = "Весь текст";
            this.rbtnText.UseVisualStyleBackColor = true;
            this.rbtnText.CheckedChanged += new System.EventHandler(this.rbtnText_CheckedChanged);
            // 
            // rbtnIndex
            // 
            this.rbtnIndex.AutoSize = true;
            this.rbtnIndex.Location = new System.Drawing.Point(103, 13);
            this.rbtnIndex.Name = "rbtnIndex";
            this.rbtnIndex.Size = new System.Drawing.Size(66, 17);
            this.rbtnIndex.TabIndex = 1;
            this.rbtnIndex.Text = "Индекс:";
            this.rbtnIndex.UseVisualStyleBackColor = true;
            this.rbtnIndex.CheckedChanged += new System.EventHandler(this.rbtnText_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(372, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtIndeces
            // 
            this.txtIndeces.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtIndeces.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIndeces.Enabled = false;
            this.txtIndeces.Location = new System.Drawing.Point(167, 11);
            this.txtIndeces.Name = "txtIndeces";
            this.txtIndeces.Size = new System.Drawing.Size(81, 20);
            this.txtIndeces.TabIndex = 3;
            this.txtIndeces.TextChanged += new System.EventHandler(this.txtIndeces_TextChanged);
            // 
            // chkChildren
            // 
            this.chkChildren.AutoSize = true;
            this.chkChildren.Enabled = false;
            this.chkChildren.Location = new System.Drawing.Point(258, 13);
            this.chkChildren.Name = "chkChildren";
            this.chkChildren.Size = new System.Drawing.Size(104, 17);
            this.chkChildren.TabIndex = 4;
            this.chkChildren.Text = "Дочерние узлы";
            this.chkChildren.UseVisualStyleBackColor = true;
            this.chkChildren.CheckedChanged += new System.EventHandler(this.chkChildren_CheckedChanged);
            // 
            // ChunkExportSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 41);
            this.Controls.Add(this.chkChildren);
            this.Controls.Add(this.txtIndeces);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.rbtnIndex);
            this.Controls.Add(this.rbtnText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChunkExportSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Экспорт";
            this.Load += new System.EventHandler(this.ChunkExportSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnText;
        private System.Windows.Forms.RadioButton rbtnIndex;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtIndeces;
        private System.Windows.Forms.CheckBox chkChildren;
    }
}