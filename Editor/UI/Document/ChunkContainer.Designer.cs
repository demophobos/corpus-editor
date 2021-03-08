
namespace Document
{
    partial class ChunkContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChunkContainer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnShowHideTranslationPane = new System.Windows.Forms.ToolStripButton();
            this.btnShowHideMorphologyPane = new System.Windows.Forms.ToolStripButton();
            this.btnAddChunk = new System.Windows.Forms.ToolStripButton();
            this.btnEditChunk = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteChunk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbLanguages = new System.Windows.Forms.ToolStripComboBox();
            this.btnRunMorphService = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPublishChunk = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideTranslationPane,
            this.btnShowHideMorphologyPane,
            this.btnAddChunk,
            this.btnEditChunk,
            this.btnDeleteChunk,
            this.toolStripSeparator3,
            this.btnExport,
            this.toolStripSeparator1,
            this.cmbLanguages,
            this.btnRunMorphService,
            this.toolStripSeparator2,
            this.btnPublishChunk});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(797, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnShowHideTranslationPane
            // 
            this.btnShowHideTranslationPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideTranslationPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideTranslationPane.Enabled = false;
            this.btnShowHideTranslationPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideTranslationPane.Image")));
            this.btnShowHideTranslationPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideTranslationPane.Name = "btnShowHideTranslationPane";
            this.btnShowHideTranslationPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideTranslationPane.Tag = "show";
            this.btnShowHideTranslationPane.Text = "Перевод";
            this.btnShowHideTranslationPane.Click += new System.EventHandler(this.btnShowHideTranslationPane_Click);
            // 
            // btnShowHideMorphologyPane
            // 
            this.btnShowHideMorphologyPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideMorphologyPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideMorphologyPane.Enabled = false;
            this.btnShowHideMorphologyPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideMorphologyPane.Image")));
            this.btnShowHideMorphologyPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideMorphologyPane.Name = "btnShowHideMorphologyPane";
            this.btnShowHideMorphologyPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideMorphologyPane.Tag = "show";
            this.btnShowHideMorphologyPane.Text = "Морфология";
            this.btnShowHideMorphologyPane.Click += new System.EventHandler(this.btnShowHideMorphologyPane_Click);
            // 
            // btnAddChunk
            // 
            this.btnAddChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChunk.Image")));
            this.btnAddChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddChunk.Name = "btnAddChunk";
            this.btnAddChunk.Size = new System.Drawing.Size(23, 22);
            this.btnAddChunk.Text = "Добавить фрагмент";
            this.btnAddChunk.Click += new System.EventHandler(this.btnAddChunk_Click);
            // 
            // btnEditChunk
            // 
            this.btnEditChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditChunk.Enabled = false;
            this.btnEditChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnEditChunk.Image")));
            this.btnEditChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditChunk.Name = "btnEditChunk";
            this.btnEditChunk.Size = new System.Drawing.Size(23, 22);
            this.btnEditChunk.Text = "Редактировать фрагмент";
            this.btnEditChunk.Click += new System.EventHandler(this.btnEditChunk_Click);
            // 
            // btnDeleteChunk
            // 
            this.btnDeleteChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteChunk.Enabled = false;
            this.btnDeleteChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteChunk.Image")));
            this.btnDeleteChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteChunk.Name = "btnDeleteChunk";
            this.btnDeleteChunk.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteChunk.Text = "Удалить фрагмент";
            this.btnDeleteChunk.Click += new System.EventHandler(this.btnDeleteChunk_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 22);
            this.btnExport.Text = "Экспорт фрагмента...";
            this.btnExport.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbLanguages
            // 
            this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguages.Enabled = false;
            this.cmbLanguages.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbLanguages.Name = "cmbLanguages";
            this.cmbLanguages.Size = new System.Drawing.Size(100, 25);
            // 
            // btnRunMorphService
            // 
            this.btnRunMorphService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRunMorphService.Enabled = false;
            this.btnRunMorphService.Image = ((System.Drawing.Image)(resources.GetObject("btnRunMorphService.Image")));
            this.btnRunMorphService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunMorphService.Name = "btnRunMorphService";
            this.btnRunMorphService.Size = new System.Drawing.Size(23, 22);
            this.btnRunMorphService.ToolTipText = "Морфологический разбор...";
            this.btnRunMorphService.Click += new System.EventHandler(this.btnRunMorphService_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPublishChunk
            // 
            this.btnPublishChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPublishChunk.Enabled = false;
            this.btnPublishChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnPublishChunk.Image")));
            this.btnPublishChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPublishChunk.Name = "btnPublishChunk";
            this.btnPublishChunk.Size = new System.Drawing.Size(23, 22);
            this.btnPublishChunk.Text = "Опубликовать";
            this.btnPublishChunk.Click += new System.EventHandler(this.btnPublishChunk_ClickAsync);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(797, 459);
            this.dockPanel1.TabIndex = 3;
            // 
            // ChunkContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 484);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChunkContainer";
            this.Load += new System.EventHandler(this.ChunkContainer_LoadAsync);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnShowHideMorphologyPane;
        private System.Windows.Forms.ToolStripButton btnShowHideTranslationPane;
        private System.Windows.Forms.ToolStripButton btnAddChunk;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripButton btnEditChunk;
        private System.Windows.Forms.ToolStripButton btnDeleteChunk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPublishChunk;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripComboBox cmbLanguages;
        private System.Windows.Forms.ToolStripButton btnRunMorphService;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}
