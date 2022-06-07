
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
            this.btnAddChunk = new System.Windows.Forms.ToolStripButton();
            this.btnEditChunk = new System.Windows.Forms.ToolStripButton();
            this.btnReplaceAll = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteChunk = new System.Windows.Forms.ToolStripButton();
            this.btnPublishChunk = new System.Windows.Forms.ToolStripButton();
            this.lblUpdated = new System.Windows.Forms.ToolStripLabel();
            this.lblCreated = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyToClipboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbMorphService = new System.Windows.Forms.ToolStripComboBox();
            this.btnRunMorphService = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.createdSep = new System.Windows.Forms.ToolStripSeparator();
            this.updatedSep = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddChunk,
            this.btnEditChunk,
            this.btnReplaceAll,
            this.btnDeleteChunk,
            this.toolStripSeparator1,
            this.btnCopyToClipboard,
            this.toolStripSeparator2,
            this.cmbMorphService,
            this.btnRunMorphService,
            this.toolStripSeparator3,
            this.btnPublishChunk,
            this.createdSep,
            this.lblCreated,
            this.updatedSep,
            this.lblUpdated});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(797, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddChunk
            // 
            this.btnAddChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChunk.Image")));
            this.btnAddChunk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnEditChunk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditChunk.Name = "btnEditChunk";
            this.btnEditChunk.Size = new System.Drawing.Size(23, 22);
            this.btnEditChunk.Text = "Редактировать фрагмент";
            this.btnEditChunk.Click += new System.EventHandler(this.btnEditChunk_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplaceAll.Enabled = false;
            this.btnReplaceAll.Image = ((System.Drawing.Image)(resources.GetObject("btnReplaceAll.Image")));
            this.btnReplaceAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReplaceAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(23, 22);
            this.btnReplaceAll.Text = "Заменить";
            this.btnReplaceAll.ToolTipText = "Заменить строку";
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnDeleteChunk
            // 
            this.btnDeleteChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteChunk.Enabled = false;
            this.btnDeleteChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteChunk.Image")));
            this.btnDeleteChunk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteChunk.Name = "btnDeleteChunk";
            this.btnDeleteChunk.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteChunk.Text = "Удалить фрагмент";
            this.btnDeleteChunk.Click += new System.EventHandler(this.btnDeleteChunk_Click);
            // 
            // btnPublishChunk
            // 
            this.btnPublishChunk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPublishChunk.Enabled = false;
            this.btnPublishChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnPublishChunk.Image")));
            this.btnPublishChunk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPublishChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPublishChunk.Name = "btnPublishChunk";
            this.btnPublishChunk.Size = new System.Drawing.Size(23, 22);
            this.btnPublishChunk.Text = "Опубликовать";
            this.btnPublishChunk.Click += new System.EventHandler(this.btnPublishChunk_ClickAsync);
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = false;
            this.lblUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(120, 22);
            this.lblUpdated.ToolTipText = "Изменено";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = false;
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(120, 22);
            this.lblCreated.ToolTipText = "Создано";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyToClipboard.Enabled = false;
            this.btnCopyToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyToClipboard.Image")));
            this.btnCopyToClipboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCopyToClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(23, 22);
            this.btnCopyToClipboard.Text = "Копировать в буфер";
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbMorphService
            // 
            this.cmbMorphService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMorphService.Enabled = false;
            this.cmbMorphService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMorphService.Name = "cmbMorphService";
            this.cmbMorphService.Size = new System.Drawing.Size(250, 25);
            // 
            // btnRunMorphService
            // 
            this.btnRunMorphService.Enabled = false;
            this.btnRunMorphService.Image = ((System.Drawing.Image)(resources.GetObject("btnRunMorphService.Image")));
            this.btnRunMorphService.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRunMorphService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunMorphService.Name = "btnRunMorphService";
            this.btnRunMorphService.Size = new System.Drawing.Size(62, 22);
            this.btnRunMorphService.Text = "Поиск";
            this.btnRunMorphService.ToolTipText = "Поиск морфологической информации";
            this.btnRunMorphService.Click += new System.EventHandler(this.btnRunMorphService_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBottomPortion = 0.75D;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this.dockPanel1.DocumentTabStripLocation = WeifenLuo.WinFormsUI.Docking.DocumentTabStripLocation.Bottom;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(797, 459);
            this.dockPanel1.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // createdSep
            // 
            this.createdSep.Name = "createdSep";
            this.createdSep.Size = new System.Drawing.Size(6, 25);
            this.createdSep.Visible = false;
            // 
            // updatedSep
            // 
            this.updatedSep.Name = "updatedSep";
            this.updatedSep.Size = new System.Drawing.Size(6, 25);
            this.updatedSep.Visible = false;
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
        private System.Windows.Forms.ToolStripButton btnAddChunk;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripButton btnEditChunk;
        private System.Windows.Forms.ToolStripButton btnDeleteChunk;
        private System.Windows.Forms.ToolStripButton btnPublishChunk;
        private System.Windows.Forms.ToolStripComboBox cmbMorphService;
        private System.Windows.Forms.ToolStripButton btnRunMorphService;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCopyToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReplaceAll;
        private System.Windows.Forms.ToolStripLabel lblCreated;
        private System.Windows.Forms.ToolStripLabel lblUpdated;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator createdSep;
        private System.Windows.Forms.ToolStripSeparator updatedSep;
    }
}
