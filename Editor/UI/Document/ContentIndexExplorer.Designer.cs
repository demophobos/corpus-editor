﻿
namespace Document
{
    partial class ContentIndexExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentIndexExplorer));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnCreateTopIndex = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowBookmarks = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveAllBookmarks = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPublish = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddSubsection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditSection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveSection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.loader1 = new Common.Control.Loader();
            this.bookmarkedSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearchNode = new System.Windows.Forms.ToolStripTextBox();
            this.btnOpenNode = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookmarkedSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
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
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Text_16x.png");
            this.imageList1.Images.SetKeyName(1, "bookmark");
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateTopIndex,
            this.toolStripSeparator2,
            this.txtSearchNode,
            this.btnOpenNode,
            this.toolStripSeparator4,
            this.btnShowBookmarks,
            this.btnRemoveAllBookmarks,
            this.toolStripSeparator1,
            this.btnPublish});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(366, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnCreateTopIndex
            // 
            this.btnCreateTopIndex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateTopIndex.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateTopIndex.Image")));
            this.btnCreateTopIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateTopIndex.Name = "btnCreateTopIndex";
            this.btnCreateTopIndex.Size = new System.Drawing.Size(23, 22);
            this.btnCreateTopIndex.Text = "Добавить раздел верхнего уровня";
            this.btnCreateTopIndex.Click += new System.EventHandler(this.btnCreateTopIndex_ClickAsync);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShowBookmarks
            // 
            this.btnShowBookmarks.Image = ((System.Drawing.Image)(resources.GetObject("btnShowBookmarks.Image")));
            this.btnShowBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowBookmarks.Name = "btnShowBookmarks";
            this.btnShowBookmarks.Size = new System.Drawing.Size(23, 22);
            this.btnShowBookmarks.ToolTipText = "Показать закладки";
            this.btnShowBookmarks.Click += new System.EventHandler(this.btnShowBookmarks_Click);
            // 
            // btnRemoveAllBookmarks
            // 
            this.btnRemoveAllBookmarks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveAllBookmarks.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllBookmarks.Image")));
            this.btnRemoveAllBookmarks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveAllBookmarks.Name = "btnRemoveAllBookmarks";
            this.btnRemoveAllBookmarks.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveAllBookmarks.ToolTipText = "Удалить закладки";
            this.btnRemoveAllBookmarks.Click += new System.EventHandler(this.btnRemoveAllBookmarks_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPublish
            // 
            this.btnPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPublish.Image = ((System.Drawing.Image)(resources.GetObject("btnPublish.Image")));
            this.btnPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(23, 22);
            this.btnPublish.ToolTipText = "Опубликовать все измененные фрагменты";
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSubsection,
            this.btnEditSection,
            this.btnRemoveSection,
            this.toolStripMenuItem1,
            this.btnOpenEditor,
            this.toolStripSeparator3,
            this.btnSetBookmark,
            this.btnRemoveBookmark});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 148);
            // 
            // btnAddSubsection
            // 
            this.btnAddSubsection.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubsection.Image")));
            this.btnAddSubsection.Name = "btnAddSubsection";
            this.btnAddSubsection.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.btnAddSubsection.Size = new System.Drawing.Size(249, 22);
            this.btnAddSubsection.Text = "Добавить подраздел";
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(246, 6);
            // 
            // btnSetBookmark
            // 
            this.btnSetBookmark.Image = ((System.Drawing.Image)(resources.GetObject("btnSetBookmark.Image")));
            this.btnSetBookmark.Name = "btnSetBookmark";
            this.btnSetBookmark.Size = new System.Drawing.Size(249, 22);
            this.btnSetBookmark.Text = "Добавить закладку";
            this.btnSetBookmark.Click += new System.EventHandler(this.btnSetBookmark_Click);
            // 
            // btnRemoveBookmark
            // 
            this.btnRemoveBookmark.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveBookmark.Image")));
            this.btnRemoveBookmark.Name = "btnRemoveBookmark";
            this.btnRemoveBookmark.Size = new System.Drawing.Size(249, 22);
            this.btnRemoveBookmark.Text = "Удалить закладку";
            this.btnRemoveBookmark.Click += new System.EventHandler(this.btnRemoveBookmark_ClickAsync);
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 25);
            this.loader1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(366, 450);
            this.loader1.TabIndex = 10;
            // 
            // bookmarkedSource
            // 
            this.bookmarkedSource.AllowNew = false;
            this.bookmarkedSource.DataSource = typeof(Model.IndexModel);
            this.bookmarkedSource.PositionChanged += new System.EventHandler(this.bookmarkedSource_PositionChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSearchNode
            // 
            this.txtSearchNode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearchNode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchNode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchNode.Name = "txtSearchNode";
            this.txtSearchNode.Size = new System.Drawing.Size(75, 25);
            this.txtSearchNode.TextChanged += new System.EventHandler(this.txtSearchNode_TextChanged);
            // 
            // btnOpenNode
            // 
            this.btnOpenNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenNode.Enabled = false;
            this.btnOpenNode.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenNode.Image")));
            this.btnOpenNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenNode.Name = "btnOpenNode";
            this.btnOpenNode.Size = new System.Drawing.Size(23, 22);
            this.btnOpenNode.Text = "Открыть раздел";
            this.btnOpenNode.Click += new System.EventHandler(this.btnOpenNode_Click);
            // 
            // ContentIndexExplorer
            // 
            this.AllowEndUserDocking = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 475);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.ControlBox = false;
            this.Controls.Add(this.loader1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip2);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight;
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.HideOnClose = true;
            this.Name = "ContentIndexExplorer";
            this.Text = "Содержание";
            this.Load += new System.EventHandler(this.ContentExplorer_LoadAsync);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookmarkedSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnCreateTopIndex;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAddSubsection;
        private System.Windows.Forms.ToolStripMenuItem btnEditSection;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveSection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnOpenEditor;
        private Common.Control.Loader loader1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnShowBookmarks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnSetBookmark;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveBookmark;
        private System.Windows.Forms.BindingSource bookmarkedSource;
        private System.Windows.Forms.ToolStripButton btnRemoveAllBookmarks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPublish;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtSearchNode;
        private System.Windows.Forms.ToolStripButton btnOpenNode;
    }
}
