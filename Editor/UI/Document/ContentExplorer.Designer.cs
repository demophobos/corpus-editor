﻿
namespace Document
{
    partial class ContentExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentExplorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddFirstLevelSection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddSubsection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditSection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveSection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBindInterp = new System.Windows.Forms.ToolStripButton();
            this.btnImportChunks = new System.Windows.Forms.ToolStripSplitButton();
            this.btnLoadJSON = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(366, 450);
            this.treeView1.TabIndex = 9;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DocumentOutline_16x.png");
            this.imageList1.Images.SetKeyName(1, "DocumentOutline_16x.png");
            this.imageList1.Images.SetKeyName(2, "StatusInformationOutline_16x.png");
            this.imageList1.Images.SetKeyName(3, "StatusOKOutline_16x.png");
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFirstLevelSection,
            this.toolStripSeparator1,
            this.btnImportChunks,
            this.btnBindInterp});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(366, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddFirstLevelSection
            // 
            this.btnAddFirstLevelSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFirstLevelSection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFirstLevelSection.Image")));
            this.btnAddFirstLevelSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFirstLevelSection.Name = "btnAddFirstLevelSection";
            this.btnAddFirstLevelSection.Size = new System.Drawing.Size(23, 22);
            this.btnAddFirstLevelSection.Text = "Добавить раздел";
            this.btnAddFirstLevelSection.Click += new System.EventHandler(this.btnAddFirstLevelSection_ClickAsync);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSubsection,
            this.btnEditSection,
            this.btnRemoveSection,
            this.toolStripMenuItem1,
            this.btnOpenEditor});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 98);
            // 
            // btnAddSubsection
            // 
            this.btnAddSubsection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubsection.Image")));
            this.btnAddSubsection.Name = "btnAddSubsection";
            this.btnAddSubsection.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.btnAddSubsection.Size = new System.Drawing.Size(249, 22);
            this.btnAddSubsection.Text = "Добавить подраздел";
            this.btnAddSubsection.Visible = false;
            this.btnAddSubsection.Click += new System.EventHandler(this.btnAddSubsection_ClickAsync);
            // 
            // btnEditSection
            // 
            this.btnEditSection.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSection.Image")));
            this.btnEditSection.Name = "btnEditSection";
            this.btnEditSection.Size = new System.Drawing.Size(249, 22);
            this.btnEditSection.Text = "Редактировать раздел";
            this.btnEditSection.Click += new System.EventHandler(this.btnEditSection_Click);
            // 
            // btnRemoveSection
            // 
            this.btnRemoveSection.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSection.Image")));
            this.btnRemoveSection.Name = "btnRemoveSection";
            this.btnRemoveSection.Size = new System.Drawing.Size(249, 22);
            this.btnRemoveSection.Text = "Удалить раздел";
            this.btnRemoveSection.Click += new System.EventHandler(this.BtnRemoveSection_ClickAsync);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // btnOpenEditor
            // 
            this.btnOpenEditor.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenEditor.Image")));
            this.btnOpenEditor.Name = "btnOpenEditor";
            this.btnOpenEditor.Size = new System.Drawing.Size(249, 22);
            this.btnOpenEditor.Text = "Редактор фрагмента";
            this.btnOpenEditor.Click += new System.EventHandler(this.btnOpenEditor_Click);
            // 
            // btnBindInterp
            // 
            this.btnBindInterp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBindInterp.Image = ((System.Drawing.Image)(resources.GetObject("btnBindInterp.Image")));
            this.btnBindInterp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBindInterp.Name = "btnBindInterp";
            this.btnBindInterp.Size = new System.Drawing.Size(23, 22);
            this.btnBindInterp.Text = "Связать с переводом";
            this.btnBindInterp.Click += new System.EventHandler(this.btnBindInterp_Click);
            // 
            // btnImportChunks
            // 
            this.btnImportChunks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnImportChunks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadJSON});
            this.btnImportChunks.Image = ((System.Drawing.Image)(resources.GetObject("btnImportChunks.Image")));
            this.btnImportChunks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportChunks.Name = "btnImportChunks";
            this.btnImportChunks.Size = new System.Drawing.Size(32, 22);
            this.btnImportChunks.Text = "Импортировать фрагменты";
            // 
            // btnLoadJSON
            // 
            this.btnLoadJSON.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadJSON.Image")));
            this.btnLoadJSON.Name = "btnLoadJSON";
            this.btnLoadJSON.Size = new System.Drawing.Size(286, 22);
            this.btnLoadJSON.Text = "Загрузить фрагменты в JSON формате";
            this.btnLoadJSON.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // ContentExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 475);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ContentExplorer";
            this.Text = "Содержание";
            this.Load += new System.EventHandler(this.ContentExplorer_LoadAsync);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddFirstLevelSection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAddSubsection;
        private System.Windows.Forms.ToolStripMenuItem btnEditSection;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveSection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnOpenEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBindInterp;
        private System.Windows.Forms.ToolStripSplitButton btnImportChunks;
        private System.Windows.Forms.ToolStripMenuItem btnLoadJSON;
    }
}
