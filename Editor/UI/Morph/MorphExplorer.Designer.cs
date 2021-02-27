
namespace Morph
{
    partial class MorphExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorphExplorer));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IsRule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.posDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lemmaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.degreeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.langDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morphSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnIsRule = new System.Windows.Forms.ToolStripButton();
            this.cmbPos = new System.Windows.Forms.ToolStripComboBox();
            this.txtLemma = new System.Windows.Forms.ToolStripTextBox();
            this.txtForm = new System.Windows.Forms.ToolStripTextBox();
            this.cmbGender = new System.Windows.Forms.ToolStripComboBox();
            this.cmbCase = new System.Windows.Forms.ToolStripComboBox();
            this.cmbPerson = new System.Windows.Forms.ToolStripComboBox();
            this.cmbNumber = new System.Windows.Forms.ToolStripComboBox();
            this.cmbTense = new System.Windows.Forms.ToolStripComboBox();
            this.cmbMood = new System.Windows.Forms.ToolStripComboBox();
            this.cmbVoice = new System.Windows.Forms.ToolStripComboBox();
            this.cmbDegree = new System.Windows.Forms.ToolStripComboBox();
            this.btnRunFilter = new System.Windows.Forms.ToolStripButton();
            this.btnUndoRule = new System.Windows.Forms.ToolStripButton();
            this.btnApplyRule = new System.Windows.Forms.ToolStripButton();
            this.btnShowUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnClone = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.loader1 = new Common.Control.Loader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsageStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbLang = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsRule,
            this.posDataGridViewTextBoxColumn,
            this.lemmaDataGridViewTextBoxColumn,
            this.formDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.caseDataGridViewTextBoxColumn,
            this.personDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.tenseDataGridViewTextBoxColumn,
            this.moodDataGridViewTextBoxColumn,
            this.voiceDataGridViewTextBoxColumn,
            this.degreeDataGridViewTextBoxColumn,
            this.dialectDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.langDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.morphSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 403);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // IsRule
            // 
            this.IsRule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsRule.DataPropertyName = "IsRule";
            this.IsRule.HeaderText = "";
            this.IsRule.MinimumWidth = 24;
            this.IsRule.Name = "IsRule";
            this.IsRule.ReadOnly = true;
            this.IsRule.Width = 24;
            // 
            // posDataGridViewTextBoxColumn
            // 
            this.posDataGridViewTextBoxColumn.DataPropertyName = "Pos";
            this.posDataGridViewTextBoxColumn.HeaderText = "Часть речи";
            this.posDataGridViewTextBoxColumn.Name = "posDataGridViewTextBoxColumn";
            this.posDataGridViewTextBoxColumn.ReadOnly = true;
            this.posDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.posDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // lemmaDataGridViewTextBoxColumn
            // 
            this.lemmaDataGridViewTextBoxColumn.DataPropertyName = "Lemma";
            this.lemmaDataGridViewTextBoxColumn.HeaderText = "Лемма";
            this.lemmaDataGridViewTextBoxColumn.Name = "lemmaDataGridViewTextBoxColumn";
            this.lemmaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formDataGridViewTextBoxColumn
            // 
            this.formDataGridViewTextBoxColumn.DataPropertyName = "Form";
            this.formDataGridViewTextBoxColumn.HeaderText = "Форма";
            this.formDataGridViewTextBoxColumn.Name = "formDataGridViewTextBoxColumn";
            this.formDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Род";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            this.genderDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.genderDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // caseDataGridViewTextBoxColumn
            // 
            this.caseDataGridViewTextBoxColumn.DataPropertyName = "Case";
            this.caseDataGridViewTextBoxColumn.HeaderText = "Падеж";
            this.caseDataGridViewTextBoxColumn.Name = "caseDataGridViewTextBoxColumn";
            this.caseDataGridViewTextBoxColumn.ReadOnly = true;
            this.caseDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.caseDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // personDataGridViewTextBoxColumn
            // 
            this.personDataGridViewTextBoxColumn.DataPropertyName = "Person";
            this.personDataGridViewTextBoxColumn.HeaderText = "Лицо";
            this.personDataGridViewTextBoxColumn.Name = "personDataGridViewTextBoxColumn";
            this.personDataGridViewTextBoxColumn.ReadOnly = true;
            this.personDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.personDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Число";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // tenseDataGridViewTextBoxColumn
            // 
            this.tenseDataGridViewTextBoxColumn.DataPropertyName = "Tense";
            this.tenseDataGridViewTextBoxColumn.HeaderText = "Время";
            this.tenseDataGridViewTextBoxColumn.Name = "tenseDataGridViewTextBoxColumn";
            this.tenseDataGridViewTextBoxColumn.ReadOnly = true;
            this.tenseDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tenseDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // moodDataGridViewTextBoxColumn
            // 
            this.moodDataGridViewTextBoxColumn.DataPropertyName = "Mood";
            this.moodDataGridViewTextBoxColumn.HeaderText = "Наклонение";
            this.moodDataGridViewTextBoxColumn.Name = "moodDataGridViewTextBoxColumn";
            this.moodDataGridViewTextBoxColumn.ReadOnly = true;
            this.moodDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.moodDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // voiceDataGridViewTextBoxColumn
            // 
            this.voiceDataGridViewTextBoxColumn.DataPropertyName = "Voice";
            this.voiceDataGridViewTextBoxColumn.HeaderText = "Залог";
            this.voiceDataGridViewTextBoxColumn.Name = "voiceDataGridViewTextBoxColumn";
            this.voiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.voiceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.voiceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // degreeDataGridViewTextBoxColumn
            // 
            this.degreeDataGridViewTextBoxColumn.DataPropertyName = "Degree";
            this.degreeDataGridViewTextBoxColumn.HeaderText = "Степень";
            this.degreeDataGridViewTextBoxColumn.Name = "degreeDataGridViewTextBoxColumn";
            this.degreeDataGridViewTextBoxColumn.ReadOnly = true;
            this.degreeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.degreeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dialectDataGridViewTextBoxColumn
            // 
            this.dialectDataGridViewTextBoxColumn.DataPropertyName = "Dialect";
            this.dialectDataGridViewTextBoxColumn.HeaderText = "Стиль";
            this.dialectDataGridViewTextBoxColumn.Name = "dialectDataGridViewTextBoxColumn";
            this.dialectDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Особенность";
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            this.featureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // langDataGridViewTextBoxColumn
            // 
            this.langDataGridViewTextBoxColumn.DataPropertyName = "Lang";
            this.langDataGridViewTextBoxColumn.HeaderText = "Язык";
            this.langDataGridViewTextBoxColumn.Name = "langDataGridViewTextBoxColumn";
            this.langDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // morphSource
            // 
            this.morphSource.DataSource = typeof(Model.MorphModel);
            this.morphSource.CurrentChanged += new System.EventHandler(this.morphSource_CurrentChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIsRule,
            this.cmbPos,
            this.txtLemma,
            this.txtForm,
            this.cmbGender,
            this.cmbCase,
            this.cmbPerson,
            this.cmbNumber,
            this.cmbTense,
            this.cmbMood,
            this.cmbVoice,
            this.cmbDegree,
            this.cmbLang,
            this.btnRunFilter,
            this.btnUndoRule,
            this.btnApplyRule,
            this.btnShowUsage,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnClone,
            this.btnEdit,
            this.btnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1338, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnIsRule
            // 
            this.btnIsRule.CheckOnClick = true;
            this.btnIsRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIsRule.Image = ((System.Drawing.Image)(resources.GetObject("btnIsRule.Image")));
            this.btnIsRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIsRule.Name = "btnIsRule";
            this.btnIsRule.Size = new System.Drawing.Size(23, 22);
            this.btnIsRule.Text = "toolStripButton2";
            this.btnIsRule.Click += new System.EventHandler(this.btnIsRule_Click);
            // 
            // cmbPos
            // 
            this.cmbPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPos.Name = "cmbPos";
            this.cmbPos.Size = new System.Drawing.Size(99, 25);
            // 
            // txtLemma
            // 
            this.txtLemma.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLemma.Name = "txtLemma";
            this.txtLemma.Size = new System.Drawing.Size(98, 25);
            // 
            // txtForm
            // 
            this.txtForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtForm.Name = "txtForm";
            this.txtForm.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbCase
            // 
            this.cmbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCase.Name = "cmbCase";
            this.cmbCase.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbPerson
            // 
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerson.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbNumber
            // 
            this.cmbNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbNumber.Name = "cmbNumber";
            this.cmbNumber.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbTense
            // 
            this.cmbTense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTense.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTense.Name = "cmbTense";
            this.cmbTense.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbMood
            // 
            this.cmbMood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMood.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMood.Name = "cmbMood";
            this.cmbMood.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbVoice
            // 
            this.cmbVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbVoice.Name = "cmbVoice";
            this.cmbVoice.Size = new System.Drawing.Size(98, 25);
            // 
            // cmbDegree
            // 
            this.cmbDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegree.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(98, 25);
            // 
            // btnRunFilter
            // 
            this.btnRunFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRunFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnRunFilter.Image")));
            this.btnRunFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunFilter.Name = "btnRunFilter";
            this.btnRunFilter.Size = new System.Drawing.Size(23, 22);
            this.btnRunFilter.Text = "Найти";
            this.btnRunFilter.Click += new System.EventHandler(this.btnRunFilter_Click);
            // 
            // btnUndoRule
            // 
            this.btnUndoRule.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnUndoRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndoRule.Enabled = false;
            this.btnUndoRule.Image = ((System.Drawing.Image)(resources.GetObject("btnUndoRule.Image")));
            this.btnUndoRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndoRule.Name = "btnUndoRule";
            this.btnUndoRule.Size = new System.Drawing.Size(23, 22);
            this.btnUndoRule.Text = "Отменить правило";
            this.btnUndoRule.Click += new System.EventHandler(this.btnUndoRule_Click);
            // 
            // btnApplyRule
            // 
            this.btnApplyRule.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnApplyRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApplyRule.Enabled = false;
            this.btnApplyRule.Image = ((System.Drawing.Image)(resources.GetObject("btnApplyRule.Image")));
            this.btnApplyRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyRule.Name = "btnApplyRule";
            this.btnApplyRule.Size = new System.Drawing.Size(23, 22);
            this.btnApplyRule.Text = "Применить правило";
            this.btnApplyRule.Click += new System.EventHandler(this.btnApplyRule_Click);
            // 
            // btnShowUsage
            // 
            this.btnShowUsage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowUsage.Image = ((System.Drawing.Image)(resources.GetObject("btnShowUsage.Image")));
            this.btnShowUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowUsage.Name = "btnShowUsage";
            this.btnShowUsage.Size = new System.Drawing.Size(23, 22);
            this.btnShowUsage.Text = "Случаев использования";
            this.btnShowUsage.Click += new System.EventHandler(this.btnShowUsage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 20);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClone
            // 
            this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(23, 20);
            this.btnClone.Text = "Копировать";
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 20);
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 20);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 25);
            this.loader1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(1338, 403);
            this.loader1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsageStat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1338, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsageStat
            // 
            this.lblUsageStat.Name = "lblUsageStat";
            this.lblUsageStat.Size = new System.Drawing.Size(0, 17);
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(98, 25);
            // 
            // MorphExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loader1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MorphExplorer";
            this.Text = "Морфология";
            this.Load += new System.EventHandler(this.MorphExplorer_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbPos;
        private System.Windows.Forms.ToolStripTextBox txtLemma;
        private System.Windows.Forms.ToolStripTextBox txtForm;
        private System.Windows.Forms.BindingSource morphSource;
        private Common.Control.Loader loader1;
        private System.Windows.Forms.ToolStripComboBox cmbGender;
        private System.Windows.Forms.ToolStripComboBox cmbPerson;
        private System.Windows.Forms.ToolStripComboBox cmbNumber;
        private System.Windows.Forms.ToolStripComboBox cmbTense;
        private System.Windows.Forms.ToolStripComboBox cmbMood;
        private System.Windows.Forms.ToolStripComboBox cmbVoice;
        private System.Windows.Forms.ToolStripComboBox cmbDegree;
        private System.Windows.Forms.ToolStripComboBox cmbCase;
        private System.Windows.Forms.ToolStripButton btnRunFilter;
        private System.Windows.Forms.ToolStripButton btnIsRule;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsageStat;
        private System.Windows.Forms.ToolStripButton btnUndoRule;
        private System.Windows.Forms.ToolStripButton btnApplyRule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnShowUsage;
        private System.Windows.Forms.ToolStripButton btnClone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn posDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lemmaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn degreeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dialectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn langDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox cmbLang;
    }
}