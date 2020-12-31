
namespace Project
{
    partial class ProjectExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorer));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.mnuHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCreateHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.loader1 = new Common.Control.Loader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnuHeader.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ApplicationConnectionDiagram_16x.png");
            this.imageList1.Images.SetKeyName(1, "Text_16x.png");
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.mnuHeader;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(314, 301);
            this.treeView1.TabIndex = 10;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // mnuHeader
            // 
            this.mnuHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateHeader,
            this.mnuEditHeader,
            this.mnuDeleteHeader});
            this.mnuHeader.Name = "mnuHeader";
            this.mnuHeader.Size = new System.Drawing.Size(150, 70);
            // 
            // mnuCreateHeader
            // 
            this.mnuCreateHeader.Image = ((System.Drawing.Image)(resources.GetObject("mnuCreateHeader.Image")));
            this.mnuCreateHeader.Name = "mnuCreateHeader";
            this.mnuCreateHeader.Size = new System.Drawing.Size(149, 22);
            this.mnuCreateHeader.Text = "Create Header";
            this.mnuCreateHeader.Visible = false;
            this.mnuCreateHeader.Click += new System.EventHandler(this.mnuCreateHeader_Click);
            // 
            // mnuEditHeader
            // 
            this.mnuEditHeader.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditHeader.Image")));
            this.mnuEditHeader.Name = "mnuEditHeader";
            this.mnuEditHeader.Size = new System.Drawing.Size(149, 22);
            this.mnuEditHeader.Text = "Edit Header";
            this.mnuEditHeader.Visible = false;
            this.mnuEditHeader.Click += new System.EventHandler(this.mnuEditHeader_Click);
            // 
            // mnuDeleteHeader
            // 
            this.mnuDeleteHeader.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteHeader.Image")));
            this.mnuDeleteHeader.Name = "mnuDeleteHeader";
            this.mnuDeleteHeader.Size = new System.Drawing.Size(149, 22);
            this.mnuDeleteHeader.Text = "Delete Header";
            this.mnuDeleteHeader.Visible = false;
            this.mnuDeleteHeader.Click += new System.EventHandler(this.mnuDeleteHeader_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(314, 25);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Создать";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "Редактировать";
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
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 0);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(314, 301);
            this.loader1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loader1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 301);
            this.panel1.TabIndex = 13;
            // 
            // ProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 326);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "ProjectExplorer";
            this.Text = "Проекты";
            this.mnuHeader.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private Common.Control.Loader loader1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip mnuHeader;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateHeader;
        private System.Windows.Forms.ToolStripMenuItem mnuEditHeader;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteHeader;
    }
}
