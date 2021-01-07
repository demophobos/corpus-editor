
namespace Document
{
    partial class InterpSelector
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtChunk = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbHeader = new System.Windows.Forms.ComboBox();
            this.headerSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbIndex = new System.Windows.Forms.ComboBox();
            this.indexSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexSource)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSelect);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 260);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(536, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(458, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtChunk
            // 
            this.txtChunk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.txtChunk, 2);
            this.txtChunk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChunk.Enabled = false;
            this.txtChunk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChunk.Location = new System.Drawing.Point(3, 30);
            this.txtChunk.Name = "txtChunk";
            this.txtChunk.ReadOnly = true;
            this.txtChunk.Size = new System.Drawing.Size(536, 224);
            this.txtChunk.TabIndex = 1;
            this.txtChunk.Text = "";
            this.txtChunk.TextChanged += new System.EventHandler(this.txtChunk_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 428F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtChunk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbIndex, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 293);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // cmbHeader
            // 
            this.cmbHeader.DataSource = this.headerSource;
            this.cmbHeader.DisplayMember = "Code";
            this.cmbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeader.FormattingEnabled = true;
            this.cmbHeader.Location = new System.Drawing.Point(3, 3);
            this.cmbHeader.Name = "cmbHeader";
            this.cmbHeader.Size = new System.Drawing.Size(422, 21);
            this.cmbHeader.TabIndex = 2;
            this.cmbHeader.ValueMember = "Id";
            // 
            // headerSource
            // 
            this.headerSource.DataSource = typeof(Model.HeaderModel);
            this.headerSource.CurrentChanged += new System.EventHandler(this.headerSource_CurrentChanged);
            // 
            // cmbIndex
            // 
            this.cmbIndex.DataSource = this.indexSource;
            this.cmbIndex.DisplayMember = "Name";
            this.cmbIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIndex.Enabled = false;
            this.cmbIndex.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbIndex.FormattingEnabled = true;
            this.cmbIndex.Location = new System.Drawing.Point(431, 3);
            this.cmbIndex.Name = "cmbIndex";
            this.cmbIndex.Size = new System.Drawing.Size(108, 21);
            this.cmbIndex.TabIndex = 3;
            this.cmbIndex.ValueMember = "Id";
            // 
            // indexSource
            // 
            this.indexSource.DataSource = typeof(Model.IndexModel);
            this.indexSource.CurrentChanged += new System.EventHandler(this.indexSource_CurrentChanged);
            // 
            // InterpSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 293);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterpSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор перевода";
            this.Load += new System.EventHandler(this.InterpSelector_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indexSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtChunk;
        private System.Windows.Forms.ComboBox cmbHeader;
        private System.Windows.Forms.ComboBox cmbIndex;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource headerSource;
        private System.Windows.Forms.BindingSource indexSource;
    }
}
