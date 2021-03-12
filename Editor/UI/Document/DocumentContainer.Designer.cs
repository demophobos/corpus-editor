
namespace Document
{
    partial class DocumentContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentContainer));
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCloseAllChunks = new System.Windows.Forms.ToolStripButton();
            this.btnReport = new System.Windows.Forms.ToolStripSplitButton();
            this.btnReportFullText = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportOriginalAndVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportReadinessStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportChunkWithoutVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportChunkWithUndefinedWord = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportChunkUnpublished = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportVersionAndOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(640, 461);
            this.dockPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCloseAllChunks,
            this.btnReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(640, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCloseAllChunks
            // 
            this.btnCloseAllChunks.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseAllChunks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseAllChunks.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAllChunks.Image")));
            this.btnCloseAllChunks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseAllChunks.Name = "btnCloseAllChunks";
            this.btnCloseAllChunks.Size = new System.Drawing.Size(23, 22);
            this.btnCloseAllChunks.Text = "Закрыть фрагменты";
            this.btnCloseAllChunks.Click += new System.EventHandler(this.btnCloseAllChunks_Click);
            // 
            // btnReport
            // 
            this.btnReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportFullText,
            this.btnReportOriginalAndVersion,
            this.btnReportVersionAndOriginal,
            this.toolStripMenuItem1,
            this.btnReportChunkWithoutVersion,
            this.btnReportChunkWithUndefinedWord,
            this.btnReportChunkUnpublished,
            this.toolStripMenuItem2,
            this.btnReportReadinessStatistics});
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(80, 22);
            this.btnReport.Text = "Отчеты";
            // 
            // btnReportFullText
            // 
            this.btnReportFullText.Name = "btnReportFullText";
            this.btnReportFullText.Size = new System.Drawing.Size(304, 22);
            this.btnReportFullText.Text = "Полный текст";
            this.btnReportFullText.Click += new System.EventHandler(this.btnReportFullText_Click);
            // 
            // btnReportOriginalAndVersion
            // 
            this.btnReportOriginalAndVersion.Name = "btnReportOriginalAndVersion";
            this.btnReportOriginalAndVersion.Size = new System.Drawing.Size(304, 22);
            this.btnReportOriginalAndVersion.Text = "Оригинал + перевод";
            // 
            // btnReportReadinessStatistics
            // 
            this.btnReportReadinessStatistics.Name = "btnReportReadinessStatistics";
            this.btnReportReadinessStatistics.Size = new System.Drawing.Size(304, 22);
            this.btnReportReadinessStatistics.Text = "Статистика выполнения";
            this.btnReportReadinessStatistics.Click += new System.EventHandler(this.btnReportReadinessStatistics_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(301, 6);
            // 
            // btnReportChunkWithoutVersion
            // 
            this.btnReportChunkWithoutVersion.Name = "btnReportChunkWithoutVersion";
            this.btnReportChunkWithoutVersion.Size = new System.Drawing.Size(304, 22);
            this.btnReportChunkWithoutVersion.Text = "Фрагменты без параллельного текста";
            this.btnReportChunkWithoutVersion.Click += new System.EventHandler(this.btnReportChunkWithoutVersion_Click);
            // 
            // btnReportChunkWithUndefinedWord
            // 
            this.btnReportChunkWithUndefinedWord.Name = "btnReportChunkWithUndefinedWord";
            this.btnReportChunkWithUndefinedWord.Size = new System.Drawing.Size(304, 22);
            this.btnReportChunkWithUndefinedWord.Text = "Фрагменты с неопределенными словами";
            this.btnReportChunkWithUndefinedWord.Click += new System.EventHandler(this.btnReportChunkWithUndefinedWord_Click);
            // 
            // btnReportChunkUnpublished
            // 
            this.btnReportChunkUnpublished.Name = "btnReportChunkUnpublished";
            this.btnReportChunkUnpublished.Size = new System.Drawing.Size(304, 22);
            this.btnReportChunkUnpublished.Text = "Неопубликованные фрагменты";
            this.btnReportChunkUnpublished.Click += new System.EventHandler(this.btnReportChunkUnpublished_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(301, 6);
            // 
            // btnReportVersionAndOriginal
            // 
            this.btnReportVersionAndOriginal.Name = "btnReportVersionAndOriginal";
            this.btnReportVersionAndOriginal.Size = new System.Drawing.Size(304, 22);
            this.btnReportVersionAndOriginal.Text = "Перевод + оригинал";
            // 
            // DocumentContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 486);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "DocumentContainer";
            this.Load += new System.EventHandler(this.DocumentContainer_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCloseAllChunks;
        private System.Windows.Forms.ToolStripSplitButton btnReport;
        private System.Windows.Forms.ToolStripMenuItem btnReportFullText;
        private System.Windows.Forms.ToolStripMenuItem btnReportOriginalAndVersion;
        private System.Windows.Forms.ToolStripMenuItem btnReportReadinessStatistics;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnReportChunkWithoutVersion;
        private System.Windows.Forms.ToolStripMenuItem btnReportChunkWithUndefinedWord;
        private System.Windows.Forms.ToolStripMenuItem btnReportChunkUnpublished;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem btnReportVersionAndOriginal;
    }
}
