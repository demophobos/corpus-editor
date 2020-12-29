﻿
namespace Project
{
    partial class HeaderEditor
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
            this.codeSource = new System.Windows.Forms.BindingSource(this.components);
            this.langSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.headerSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEditionCode = new System.Windows.Forms.TextBox();
            this.cmbEditionType = new System.Windows.Forms.ComboBox();
            this.editionTypeSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.codeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.langSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editionTypeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codeSource
            // 
            this.codeSource.DataSource = typeof(Model.TaxonomyItem);
            // 
            // langSource
            // 
            this.langSource.DataSource = typeof(Model.TaxonomyItem);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbLang, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtEditionCode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbEditionType, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 161);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(278, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Тип:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.tableLayoutPanel1.SetRowSpan(this.label4, 2);
            this.label4.Size = new System.Drawing.Size(60, 99);
            this.label4.TabIndex = 6;
            this.label4.Text = "Издание:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 7);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 128);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(419, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtTitle, 6);
            this.txtTitle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.headerSource, "Desc", true));
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(69, 29);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(512, 67);
            this.txtTitle.TabIndex = 2;
            // 
            // headerSource
            // 
            this.headerSource.AllowNew = true;
            this.headerSource.DataSource = typeof(Model.HeaderModel);
            // 
            // cmbLang
            // 
            this.cmbLang.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.headerSource, "Lang", true));
            this.cmbLang.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.headerSource, "Lang", true));
            this.cmbLang.DataSource = this.langSource;
            this.cmbLang.DisplayMember = "Name";
            this.cmbLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(468, 102);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(113, 21);
            this.cmbLang.TabIndex = 1;
            this.cmbLang.ValueMember = "Name";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Проект:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditionCode
            // 
            this.txtEditionCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.headerSource, "Code", true));
            this.txtEditionCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditionCode.Location = new System.Drawing.Point(105, 102);
            this.txtEditionCode.Name = "txtEditionCode";
            this.txtEditionCode.Size = new System.Drawing.Size(167, 20);
            this.txtEditionCode.TabIndex = 7;
            // 
            // cmbEditionType
            // 
            this.cmbEditionType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.headerSource, "EditionType", true));
            this.cmbEditionType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.headerSource, "EditionType", true));
            this.cmbEditionType.DataSource = this.editionTypeSource;
            this.cmbEditionType.DisplayMember = "Name";
            this.cmbEditionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEditionType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEditionType.FormattingEnabled = true;
            this.cmbEditionType.Location = new System.Drawing.Point(314, 102);
            this.cmbEditionType.Name = "cmbEditionType";
            this.cmbEditionType.Size = new System.Drawing.Size(97, 21);
            this.cmbEditionType.TabIndex = 9;
            this.cmbEditionType.ValueMember = "Name";
            // 
            // editionTypeSource
            // 
            this.editionTypeSource.DataSource = typeof(Model.TaxonomyItem);
            // 
            // lblCode
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lblCode, 6);
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Location = new System.Drawing.Point(69, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(512, 26);
            this.lblCode.TabIndex = 10;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(69, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Код:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(417, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Язык:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HeaderEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор заголовка";
            this.Load += new System.EventHandler(this.HeaderEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.codeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.langSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editionTypeSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource codeSource;
        private System.Windows.Forms.BindingSource langSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.BindingSource headerSource;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEditionCode;
        private System.Windows.Forms.ComboBox cmbEditionType;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource editionTypeSource;
        private System.Windows.Forms.Label label2;
    }
}