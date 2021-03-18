
namespace Document
{
    partial class MorphSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorphSelector));
            this.btnAcceptDefinition = new System.Windows.Forms.ToolStripButton();
            this.mnuTools = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnClone = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCopyForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAcceptForAllCases = new System.Windows.Forms.ToolStripButton();
            this.btnCreateRule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelDefinition = new System.Windows.Forms.ToolStripButton();
            this.btnCancelAllCases = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveRule = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IsRule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lemmaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.degreeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dialectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.langDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morphId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.morphSource = new System.Windows.Forms.BindingSource(this.components);
            this.loader1 = new Common.Control.Loader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAcceptDefinition
            // 
            this.btnAcceptDefinition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAcceptDefinition.Enabled = false;
            this.btnAcceptDefinition.Image = ((System.Drawing.Image)(resources.GetObject("btnAcceptDefinition.Image")));
            this.btnAcceptDefinition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptDefinition.Name = "btnAcceptDefinition";
            this.btnAcceptDefinition.Size = new System.Drawing.Size(23, 22);
            this.btnAcceptDefinition.ToolTipText = "Принять определение";
            this.btnAcceptDefinition.Click += new System.EventHandler(this.btnAcceptDefinition_ClickAsync);
            // 
            // mnuTools
            // 
            this.mnuTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnClone,
            this.btnEdit,
            this.btnDelete,
            this.btnCopyForm,
            this.toolStripSeparator1,
            this.btnAcceptDefinition,
            this.btnCancelDefinition,
            this.toolStripSeparator4,
            this.btnAcceptForAllCases,
            this.btnCancelAllCases,
            this.toolStripSeparator2,
            this.btnCreateRule,
            this.btnRemoveRule});
            this.mnuTools.Location = new System.Drawing.Point(0, 0);
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnuTools.Size = new System.Drawing.Size(984, 25);
            this.mnuTools.TabIndex = 17;
            this.mnuTools.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.ToolTipText = "Создать";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClone
            // 
            this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClone.Enabled = false;
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(23, 22);
            this.btnClone.ToolTipText = "Создать на основе текущего";
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.ToolTipText = "Редактировать";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.ToolTipText = "Удалить определение";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_ClickAsync);
            // 
            // btnCopyForm
            // 
            this.btnCopyForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyForm.Enabled = false;
            this.btnCopyForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyForm.Image")));
            this.btnCopyForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyForm.Name = "btnCopyForm";
            this.btnCopyForm.Size = new System.Drawing.Size(23, 22);
            this.btnCopyForm.Text = "Копировать форму в буфер обмена";
            this.btnCopyForm.Visible = false;
            this.btnCopyForm.Click += new System.EventHandler(this.btnCopyForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAcceptForAllCases
            // 
            this.btnAcceptForAllCases.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAcceptForAllCases.Enabled = false;
            this.btnAcceptForAllCases.Image = ((System.Drawing.Image)(resources.GetObject("btnAcceptForAllCases.Image")));
            this.btnAcceptForAllCases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptForAllCases.Name = "btnAcceptForAllCases";
            this.btnAcceptForAllCases.Size = new System.Drawing.Size(23, 22);
            this.btnAcceptForAllCases.ToolTipText = "Применить ко всему тексту";
            this.btnAcceptForAllCases.Click += new System.EventHandler(this.btnAcceptForAllCases_Click);
            // 
            // btnCreateRule
            // 
            this.btnCreateRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateRule.Enabled = false;
            this.btnCreateRule.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateRule.Image")));
            this.btnCreateRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRule.Name = "btnCreateRule";
            this.btnCreateRule.Size = new System.Drawing.Size(23, 22);
            this.btnCreateRule.ToolTipText = "Содать правило";
            this.btnCreateRule.Click += new System.EventHandler(this.btnCreateRule_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancelDefinition
            // 
            this.btnCancelDefinition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelDefinition.Enabled = false;
            this.btnCancelDefinition.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelDefinition.Image")));
            this.btnCancelDefinition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDefinition.Name = "btnCancelDefinition";
            this.btnCancelDefinition.Size = new System.Drawing.Size(23, 22);
            this.btnCancelDefinition.ToolTipText = "Снять определение";
            this.btnCancelDefinition.Click += new System.EventHandler(this.btnUndoAccept_Click);
            // 
            // btnCancelAllCases
            // 
            this.btnCancelAllCases.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancelAllCases.Enabled = false;
            this.btnCancelAllCases.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAllCases.Image")));
            this.btnCancelAllCases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelAllCases.Name = "btnCancelAllCases";
            this.btnCancelAllCases.Size = new System.Drawing.Size(23, 22);
            this.btnCancelAllCases.ToolTipText = "Отменить для всего текста";
            this.btnCancelAllCases.Click += new System.EventHandler(this.btnCancelAllCases_Click);
            // 
            // btnRemoveRule
            // 
            this.btnRemoveRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveRule.Enabled = false;
            this.btnRemoveRule.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRule.Image")));
            this.btnRemoveRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveRule.Name = "btnRemoveRule";
            this.btnRemoveRule.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveRule.ToolTipText = "Удалить правило";
            this.btnRemoveRule.Click += new System.EventHandler(this.btnRemoveRule_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsRule,
            this.Form,
            this.lemmaDataGridViewTextBoxColumn,
            this.posDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.caseDataGridViewTextBoxColumn,
            this.personDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.tenseDataGridViewTextBoxColumn,
            this.moodDataGridViewTextBoxColumn,
            this.voiceDataGridViewTextBoxColumn,
            this.degreeDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.dialectDataGridViewTextBoxColumn,
            this.langDataGridViewTextBoxColumn,
            this.morphId});
            this.dataGridView1.DataSource = this.morphSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 397);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // IsRule
            // 
            this.IsRule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IsRule.DataPropertyName = "IsRule";
            this.IsRule.HeaderText = "П";
            this.IsRule.MinimumWidth = 24;
            this.IsRule.Name = "IsRule";
            this.IsRule.ReadOnly = true;
            this.IsRule.ToolTipText = "Принимать по умолчанию";
            this.IsRule.Width = 24;
            // 
            // Form
            // 
            this.Form.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Form.DataPropertyName = "Form";
            this.Form.HeaderText = "Форма";
            this.Form.Name = "Form";
            this.Form.ReadOnly = true;
            this.Form.Width = 69;
            // 
            // lemmaDataGridViewTextBoxColumn
            // 
            this.lemmaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lemmaDataGridViewTextBoxColumn.DataPropertyName = "Lemma";
            this.lemmaDataGridViewTextBoxColumn.HeaderText = "Лемма";
            this.lemmaDataGridViewTextBoxColumn.Name = "lemmaDataGridViewTextBoxColumn";
            this.lemmaDataGridViewTextBoxColumn.ReadOnly = true;
            this.lemmaDataGridViewTextBoxColumn.Width = 68;
            // 
            // posDataGridViewTextBoxColumn
            // 
            this.posDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.posDataGridViewTextBoxColumn.DataPropertyName = "Pos";
            this.posDataGridViewTextBoxColumn.HeaderText = "ЧР";
            this.posDataGridViewTextBoxColumn.Name = "posDataGridViewTextBoxColumn";
            this.posDataGridViewTextBoxColumn.ReadOnly = true;
            this.posDataGridViewTextBoxColumn.Width = 47;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Род";
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.ReadOnly = true;
            this.genderDataGridViewTextBoxColumn.Width = 51;
            // 
            // caseDataGridViewTextBoxColumn
            // 
            this.caseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.caseDataGridViewTextBoxColumn.DataPropertyName = "Case";
            this.caseDataGridViewTextBoxColumn.HeaderText = "Падеж";
            this.caseDataGridViewTextBoxColumn.Name = "caseDataGridViewTextBoxColumn";
            this.caseDataGridViewTextBoxColumn.ReadOnly = true;
            this.caseDataGridViewTextBoxColumn.Width = 66;
            // 
            // personDataGridViewTextBoxColumn
            // 
            this.personDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.personDataGridViewTextBoxColumn.DataPropertyName = "Person";
            this.personDataGridViewTextBoxColumn.HeaderText = "Лицо";
            this.personDataGridViewTextBoxColumn.Name = "personDataGridViewTextBoxColumn";
            this.personDataGridViewTextBoxColumn.ReadOnly = true;
            this.personDataGridViewTextBoxColumn.Width = 58;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Число";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 64;
            // 
            // tenseDataGridViewTextBoxColumn
            // 
            this.tenseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tenseDataGridViewTextBoxColumn.DataPropertyName = "Tense";
            this.tenseDataGridViewTextBoxColumn.HeaderText = "Время";
            this.tenseDataGridViewTextBoxColumn.Name = "tenseDataGridViewTextBoxColumn";
            this.tenseDataGridViewTextBoxColumn.ReadOnly = true;
            this.tenseDataGridViewTextBoxColumn.Width = 65;
            // 
            // moodDataGridViewTextBoxColumn
            // 
            this.moodDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.moodDataGridViewTextBoxColumn.DataPropertyName = "Mood";
            this.moodDataGridViewTextBoxColumn.HeaderText = "Наклонение";
            this.moodDataGridViewTextBoxColumn.Name = "moodDataGridViewTextBoxColumn";
            this.moodDataGridViewTextBoxColumn.ReadOnly = true;
            this.moodDataGridViewTextBoxColumn.Width = 94;
            // 
            // voiceDataGridViewTextBoxColumn
            // 
            this.voiceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.voiceDataGridViewTextBoxColumn.DataPropertyName = "Voice";
            this.voiceDataGridViewTextBoxColumn.HeaderText = "Залог";
            this.voiceDataGridViewTextBoxColumn.Name = "voiceDataGridViewTextBoxColumn";
            this.voiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.voiceDataGridViewTextBoxColumn.Width = 62;
            // 
            // degreeDataGridViewTextBoxColumn
            // 
            this.degreeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.degreeDataGridViewTextBoxColumn.DataPropertyName = "Degree";
            this.degreeDataGridViewTextBoxColumn.HeaderText = "Степень";
            this.degreeDataGridViewTextBoxColumn.Name = "degreeDataGridViewTextBoxColumn";
            this.degreeDataGridViewTextBoxColumn.ReadOnly = true;
            this.degreeDataGridViewTextBoxColumn.Width = 74;
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Особенность";
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            this.featureDataGridViewTextBoxColumn.ReadOnly = true;
            this.featureDataGridViewTextBoxColumn.Width = 99;
            // 
            // dialectDataGridViewTextBoxColumn
            // 
            this.dialectDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dialectDataGridViewTextBoxColumn.DataPropertyName = "Dialect";
            this.dialectDataGridViewTextBoxColumn.HeaderText = "Стиль";
            this.dialectDataGridViewTextBoxColumn.Name = "dialectDataGridViewTextBoxColumn";
            this.dialectDataGridViewTextBoxColumn.ReadOnly = true;
            this.dialectDataGridViewTextBoxColumn.Width = 62;
            // 
            // langDataGridViewTextBoxColumn
            // 
            this.langDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.langDataGridViewTextBoxColumn.DataPropertyName = "Lang";
            this.langDataGridViewTextBoxColumn.HeaderText = "Язык";
            this.langDataGridViewTextBoxColumn.Name = "langDataGridViewTextBoxColumn";
            this.langDataGridViewTextBoxColumn.ReadOnly = true;
            this.langDataGridViewTextBoxColumn.Width = 60;
            // 
            // morphId
            // 
            this.morphId.DataPropertyName = "Id";
            this.morphId.HeaderText = "Id";
            this.morphId.Name = "morphId";
            this.morphId.ReadOnly = true;
            this.morphId.Visible = false;
            // 
            // morphSource
            // 
            this.morphSource.DataSource = typeof(Model.MorphModel);
            this.morphSource.DataSourceChanged += new System.EventHandler(this.morphSource_DataSourceChanged);
            this.morphSource.CurrentChanged += new System.EventHandler(this.morphSource_CurrentChanged);
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 25);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(984, 419);
            this.loader1.TabIndex = 19;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MorphSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 444);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.loader1);
            this.Controls.Add(this.mnuTools);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Enabled = false;
            this.HideOnClose = true;
            this.Name = "MorphSelector";
            this.Text = "Морфология";
            this.mnuTools.ResumeLayout(false);
            this.mnuTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.morphSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnAcceptDefinition;
        private System.Windows.Forms.ToolStrip mnuTools;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCancelDefinition;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource morphSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCreateRule;
        private System.Windows.Forms.ToolStripButton btnRemoveRule;
        private System.Windows.Forms.ToolStripButton btnCopyForm;
        private System.Windows.Forms.ToolStripButton btnAcceptForAllCases;
        private System.Windows.Forms.ToolStripButton btnCancelAllCases;
        private System.Windows.Forms.ToolStripButton btnClone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn lemmaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn posDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn degreeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dialectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn langDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn morphId;
        private Common.Control.Loader loader1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
