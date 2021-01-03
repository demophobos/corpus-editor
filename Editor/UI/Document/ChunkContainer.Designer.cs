
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
            this.btnShowHideMorphologyPane = new System.Windows.Forms.ToolStripButton();
            this.btnShowHideCommentPane = new System.Windows.Forms.ToolStripButton();
            this.btnShowHideTranslationPane = new System.Windows.Forms.ToolStripButton();
            this.btnShowHideContextPane = new System.Windows.Forms.ToolStripButton();
            this.btnAddChunk = new System.Windows.Forms.ToolStripButton();
            this.btnEditChunk = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteChunk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMorphAnalysis = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideMorphologyPane,
            this.btnShowHideCommentPane,
            this.btnShowHideTranslationPane,
            this.btnShowHideContextPane,
            this.btnAddChunk,
            this.btnEditChunk,
            this.btnDeleteChunk,
            this.toolStripSeparator1,
            this.btnMorphAnalysis});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(797, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnShowHideMorphologyPane
            // 
            this.btnShowHideMorphologyPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideMorphologyPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideMorphologyPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideMorphologyPane.Image")));
            this.btnShowHideMorphologyPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideMorphologyPane.Name = "btnShowHideMorphologyPane";
            this.btnShowHideMorphologyPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideMorphologyPane.Tag = "show";
            this.btnShowHideMorphologyPane.Text = "Показать морфологию";
            this.btnShowHideMorphologyPane.Click += new System.EventHandler(this.btnShowHideMorphologyPane_Click);
            // 
            // btnShowHideCommentPane
            // 
            this.btnShowHideCommentPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideCommentPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideCommentPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideCommentPane.Image")));
            this.btnShowHideCommentPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideCommentPane.Name = "btnShowHideCommentPane";
            this.btnShowHideCommentPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideCommentPane.Tag = "show";
            this.btnShowHideCommentPane.Text = "Показать комментарий";
            // 
            // btnShowHideTranslationPane
            // 
            this.btnShowHideTranslationPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideTranslationPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideTranslationPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideTranslationPane.Image")));
            this.btnShowHideTranslationPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideTranslationPane.Name = "btnShowHideTranslationPane";
            this.btnShowHideTranslationPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideTranslationPane.Tag = "show";
            this.btnShowHideTranslationPane.Text = "Показать перевод";
            // 
            // btnShowHideContextPane
            // 
            this.btnShowHideContextPane.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideContextPane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideContextPane.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideContextPane.Image")));
            this.btnShowHideContextPane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideContextPane.Name = "btnShowHideContextPane";
            this.btnShowHideContextPane.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideContextPane.Tag = "show";
            this.btnShowHideContextPane.Text = "Показать контекст";
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
            this.btnDeleteChunk.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteChunk.Image")));
            this.btnDeleteChunk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteChunk.Name = "btnDeleteChunk";
            this.btnDeleteChunk.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteChunk.Text = "Удалить фрагмент";
            this.btnDeleteChunk.Click += new System.EventHandler(this.btnDeleteChunk_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMorphAnalysis
            // 
            this.btnMorphAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMorphAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btnMorphAnalysis.Image")));
            this.btnMorphAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMorphAnalysis.Name = "btnMorphAnalysis";
            this.btnMorphAnalysis.Size = new System.Drawing.Size(23, 22);
            this.btnMorphAnalysis.Text = "Выполнить морфологический анализ";
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
        private System.Windows.Forms.ToolStripButton btnShowHideCommentPane;
        private System.Windows.Forms.ToolStripButton btnShowHideTranslationPane;
        private System.Windows.Forms.ToolStripButton btnShowHideContextPane;
        private System.Windows.Forms.ToolStripButton btnAddChunk;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripButton btnEditChunk;
        private System.Windows.Forms.ToolStripButton btnDeleteChunk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnMorphAnalysis;
    }
}
