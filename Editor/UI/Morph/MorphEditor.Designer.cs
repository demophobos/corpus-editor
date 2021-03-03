
namespace Morph
{
    partial class MorphEditor
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
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.txtFeature = new System.Windows.Forms.TextBox();
            this.morphSource = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDialect = new System.Windows.Forms.ComboBox();
            this.dictSource = new System.Windows.Forms.BindingSource(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbVoice = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbMood = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTense = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNumber = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPerson = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCase = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtForm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.txtLemma = new System.Windows.Forms.TextBox();
            this.loader1 = new Common.Control.Loader();
            this.table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // table
            // 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.txtFeature, 0, 13);
            this.table.Controls.Add(this.label14, 0, 13);
            this.table.Controls.Add(this.cmbDialect, 1, 12);
            this.table.Controls.Add(this.label13, 0, 12);
            this.table.Controls.Add(this.cmbDegree, 1, 11);
            this.table.Controls.Add(this.label12, 0, 11);
            this.table.Controls.Add(this.cmbVoice, 1, 10);
            this.table.Controls.Add(this.label11, 0, 10);
            this.table.Controls.Add(this.cmbMood, 1, 9);
            this.table.Controls.Add(this.label10, 0, 9);
            this.table.Controls.Add(this.cmbTense, 1, 8);
            this.table.Controls.Add(this.label9, 0, 8);
            this.table.Controls.Add(this.cmbNumber, 1, 7);
            this.table.Controls.Add(this.label8, 0, 7);
            this.table.Controls.Add(this.cmbPerson, 1, 6);
            this.table.Controls.Add(this.label7, 0, 6);
            this.table.Controls.Add(this.cmbCase, 1, 5);
            this.table.Controls.Add(this.label6, 0, 5);
            this.table.Controls.Add(this.cmbGender, 1, 4);
            this.table.Controls.Add(this.label5, 0, 4);
            this.table.Controls.Add(this.cmbPos, 1, 3);
            this.table.Controls.Add(this.label4, 0, 3);
            this.table.Controls.Add(this.txtForm, 1, 2);
            this.table.Controls.Add(this.label3, 0, 2);
            this.table.Controls.Add(this.label2, 0, 1);
            this.table.Controls.Add(this.flowLayoutPanel1, 1, 14);
            this.table.Controls.Add(this.label1, 0, 0);
            this.table.Controls.Add(this.cmbLang, 1, 0);
            this.table.Controls.Add(this.txtLemma, 1, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 15;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table.Size = new System.Drawing.Size(354, 413);
            this.table.TabIndex = 6;
            // 
            // txtFeature
            // 
            this.txtFeature.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.morphSource, "Feature", true));
            this.txtFeature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFeature.Location = new System.Drawing.Point(103, 354);
            this.txtFeature.Name = "txtFeature";
            this.txtFeature.Size = new System.Drawing.Size(248, 20);
            this.txtFeature.TabIndex = 28;
            // 
            // morphSource
            // 
            this.morphSource.DataSource = typeof(Model.MorphModel);
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 351);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 27);
            this.label14.TabIndex = 27;
            this.label14.Text = "особенность:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDialect
            // 
            this.cmbDialect.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Dialect", true));
            this.cmbDialect.DataSource = this.dictSource;
            this.cmbDialect.DisplayMember = "Code";
            this.cmbDialect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDialect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDialect.FormattingEnabled = true;
            this.cmbDialect.Location = new System.Drawing.Point(103, 327);
            this.cmbDialect.Name = "cmbDialect";
            this.cmbDialect.Size = new System.Drawing.Size(248, 21);
            this.cmbDialect.TabIndex = 26;
            this.cmbDialect.Tag = "Dialect";
            this.cmbDialect.ValueMember = "Code";
            // 
            // dictSource
            // 
            this.dictSource.DataSource = typeof(Model.TaxonomyModel);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 324);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 27);
            this.label13.TabIndex = 25;
            this.label13.Text = "стиль:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDegree
            // 
            this.cmbDegree.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Degree", true));
            this.cmbDegree.DataSource = this.dictSource;
            this.cmbDegree.DisplayMember = "Code";
            this.cmbDegree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.Location = new System.Drawing.Point(103, 300);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(248, 21);
            this.cmbDegree.TabIndex = 24;
            this.cmbDegree.Tag = "Degree";
            this.cmbDegree.ValueMember = "Code";
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 27);
            this.label12.TabIndex = 23;
            this.label12.Text = "степень:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbVoice
            // 
            this.cmbVoice.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Voice", true));
            this.cmbVoice.DataSource = this.dictSource;
            this.cmbVoice.DisplayMember = "Code";
            this.cmbVoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoice.FormattingEnabled = true;
            this.cmbVoice.Location = new System.Drawing.Point(103, 273);
            this.cmbVoice.Name = "cmbVoice";
            this.cmbVoice.Size = new System.Drawing.Size(248, 21);
            this.cmbVoice.TabIndex = 22;
            this.cmbVoice.Tag = "Voice";
            this.cmbVoice.ValueMember = "Code";
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 27);
            this.label11.TabIndex = 21;
            this.label11.Text = "залог:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMood
            // 
            this.cmbMood.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Mood", true));
            this.cmbMood.DataSource = this.dictSource;
            this.cmbMood.DisplayMember = "Code";
            this.cmbMood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMood.FormattingEnabled = true;
            this.cmbMood.Location = new System.Drawing.Point(103, 246);
            this.cmbMood.Name = "cmbMood";
            this.cmbMood.Size = new System.Drawing.Size(248, 21);
            this.cmbMood.TabIndex = 20;
            this.cmbMood.Tag = "Mood";
            this.cmbMood.ValueMember = "Code";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 27);
            this.label10.TabIndex = 19;
            this.label10.Text = "наклонение:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTense
            // 
            this.cmbTense.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Tense", true));
            this.cmbTense.DataSource = this.dictSource;
            this.cmbTense.DisplayMember = "Code";
            this.cmbTense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTense.FormattingEnabled = true;
            this.cmbTense.Location = new System.Drawing.Point(103, 219);
            this.cmbTense.Name = "cmbTense";
            this.cmbTense.Size = new System.Drawing.Size(248, 21);
            this.cmbTense.TabIndex = 18;
            this.cmbTense.Tag = "Tense";
            this.cmbTense.ValueMember = "Code";
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 27);
            this.label9.TabIndex = 17;
            this.label9.Text = "время:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNumber
            // 
            this.cmbNumber.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Number", true));
            this.cmbNumber.DataSource = this.dictSource;
            this.cmbNumber.DisplayMember = "Code";
            this.cmbNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumber.FormattingEnabled = true;
            this.cmbNumber.Location = new System.Drawing.Point(103, 192);
            this.cmbNumber.Name = "cmbNumber";
            this.cmbNumber.Size = new System.Drawing.Size(248, 21);
            this.cmbNumber.TabIndex = 16;
            this.cmbNumber.Tag = "Number";
            this.cmbNumber.ValueMember = "Code";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 27);
            this.label8.TabIndex = 15;
            this.label8.Text = "число:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPerson
            // 
            this.cmbPerson.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Person", true));
            this.cmbPerson.DataSource = this.dictSource;
            this.cmbPerson.DisplayMember = "Code";
            this.cmbPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerson.FormattingEnabled = true;
            this.cmbPerson.Location = new System.Drawing.Point(103, 165);
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Size = new System.Drawing.Size(248, 21);
            this.cmbPerson.TabIndex = 14;
            this.cmbPerson.Tag = "Person";
            this.cmbPerson.ValueMember = "Code";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 27);
            this.label7.TabIndex = 13;
            this.label7.Text = "лицо:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCase
            // 
            this.cmbCase.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Case", true));
            this.cmbCase.DataSource = this.dictSource;
            this.cmbCase.DisplayMember = "Code";
            this.cmbCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCase.FormattingEnabled = true;
            this.cmbCase.Location = new System.Drawing.Point(103, 138);
            this.cmbCase.Name = "cmbCase";
            this.cmbCase.Size = new System.Drawing.Size(248, 21);
            this.cmbCase.TabIndex = 12;
            this.cmbCase.Tag = "Case";
            this.cmbCase.ValueMember = "Code";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 27);
            this.label6.TabIndex = 11;
            this.label6.Text = "падеж:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGender
            // 
            this.cmbGender.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Gender", true));
            this.cmbGender.DataSource = this.dictSource;
            this.cmbGender.DisplayMember = "Code";
            this.cmbGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(103, 111);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(248, 21);
            this.cmbGender.TabIndex = 10;
            this.cmbGender.Tag = "Gender";
            this.cmbGender.ValueMember = "Code";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "род:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPos
            // 
            this.cmbPos.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Pos", true));
            this.cmbPos.DataSource = this.dictSource;
            this.cmbPos.DisplayMember = "Code";
            this.cmbPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPos.FormattingEnabled = true;
            this.cmbPos.Location = new System.Drawing.Point(103, 84);
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(248, 21);
            this.cmbPos.TabIndex = 8;
            this.cmbPos.Tag = "Pos";
            this.cmbPos.ValueMember = "Code";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "*часть речи:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForm
            // 
            this.txtForm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.morphSource, "Form", true));
            this.txtForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtForm.Location = new System.Drawing.Point(103, 57);
            this.txtForm.Name = "txtForm";
            this.txtForm.Size = new System.Drawing.Size(248, 20);
            this.txtForm.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "*форма:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "*лемма:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(103, 381);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(170, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(89, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "*язык:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLang
            // 
            this.cmbLang.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.morphSource, "Lang", true));
            this.cmbLang.DataSource = this.dictSource;
            this.cmbLang.DisplayMember = "Code";
            this.cmbLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(103, 3);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(248, 21);
            this.cmbLang.TabIndex = 2;
            this.cmbLang.Tag = "Lang";
            this.cmbLang.ValueMember = "Code";
            // 
            // txtLemma
            // 
            this.txtLemma.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.morphSource, "Lemma", true));
            this.txtLemma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLemma.Location = new System.Drawing.Point(103, 30);
            this.txtLemma.Name = "txtLemma";
            this.txtLemma.Size = new System.Drawing.Size(248, 20);
            this.txtLemma.TabIndex = 4;
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 0);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(354, 413);
            this.loader1.TabIndex = 7;
            // 
            // MorphEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 413);
            this.Controls.Add(this.table);
            this.Controls.Add(this.loader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MorphEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор определения";
            this.Load += new System.EventHandler(this.MorphEditor_Load);
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.TextBox txtFeature;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbDialect;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbDegree;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbVoice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbMood;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTense;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.TextBox txtLemma;
        private System.Windows.Forms.BindingSource morphSource;
        private System.Windows.Forms.BindingSource dictSource;
        private Common.Control.Loader loader1;
    }
}