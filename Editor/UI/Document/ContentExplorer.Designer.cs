
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddSubsection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditSection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveSection = new System.Windows.Forms.ToolStripMenuItem();
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
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
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
            this.btnAddFirstLevelSection});
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSubsection,
            this.btnEditSection,
            this.btnRemoveSection});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 70);
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
    }
}
