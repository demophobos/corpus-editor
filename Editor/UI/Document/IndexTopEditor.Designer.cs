
namespace Document
{
    partial class IndexTopEditor
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
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.startValue = new System.Windows.Forms.NumericUpDown();
            this.endValue = new System.Windows.Forms.NumericUpDown();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endValue)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRange
            // 
            this.chkRange.AutoSize = true;
            this.chkRange.Location = new System.Drawing.Point(91, 11);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(74, 17);
            this.chkRange.TabIndex = 1;
            this.chkRange.Text = "диапазон";
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            // 
            // startValue
            // 
            this.startValue.Location = new System.Drawing.Point(11, 9);
            this.startValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.startValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startValue.Name = "startValue";
            this.startValue.Size = new System.Drawing.Size(70, 20);
            this.startValue.TabIndex = 0;
            this.startValue.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.startValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // endValue
            // 
            this.endValue.Enabled = false;
            this.endValue.Location = new System.Drawing.Point(175, 9);
            this.endValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.endValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endValue.Name = "endValue";
            this.endValue.Size = new System.Drawing.Size(70, 20);
            this.endValue.TabIndex = 2;
            this.endValue.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.endValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endValue.ValueChanged += new System.EventHandler(this.startValue_ValueChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(255, 6);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(70, 25);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // IndexTopEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 40);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.endValue);
            this.Controls.Add(this.startValue);
            this.Controls.Add(this.chkRange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IndexTopEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Индекс верхнего уровня";
            ((System.ComponentModel.ISupportInitialize)(this.startValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkRange;
        private System.Windows.Forms.NumericUpDown startValue;
        private System.Windows.Forms.NumericUpDown endValue;
        private System.Windows.Forms.Button btnCreate;
    }
}