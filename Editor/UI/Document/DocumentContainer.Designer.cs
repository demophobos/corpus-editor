
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportToRusCorporaXml = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportParallelText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunk = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunkReportIndexWithEmptyText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunkReportWithoutParallelText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunkReportChunkWithUndefinedWord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunkReportUnpublished = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatPosReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStatReportReadinessStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.morphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAllWindowsExceptActive = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockRightPortion = 0.2D;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(831, 440);
            this.dockPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuReport,
            this.mnuTools,
            this.mnuWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuExport
            // 
            this.mnuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportToRusCorporaXml});
            this.mnuExport.Image = ((System.Drawing.Image)(resources.GetObject("mnuExport.Image")));
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.ShowShortcutKeys = false;
            this.mnuExport.Size = new System.Drawing.Size(80, 20);
            this.mnuExport.Text = "Экспорт";
            // 
            // mnuExportToRusCorporaXml
            // 
            this.mnuExportToRusCorporaXml.Image = ((System.Drawing.Image)(resources.GetObject("mnuExportToRusCorporaXml.Image")));
            this.mnuExportToRusCorporaXml.Name = "mnuExportToRusCorporaXml";
            this.mnuExportToRusCorporaXml.Size = new System.Drawing.Size(159, 22);
            this.mnuExportToRusCorporaXml.Text = "RusCorpora.xml";
            this.mnuExportToRusCorporaXml.Click += new System.EventHandler(this.mnuExportToRusCorporaXml_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuText,
            this.mnuChunk,
            this.mnuWord,
            this.mnuComment,
            this.toolStripMenuItem1,
            this.mnuStatistics});
            this.mnuReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuReport.Image")));
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(76, 20);
            this.mnuReport.Text = "Отчеты";
            // 
            // mnuText
            // 
            this.mnuText.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextReportText,
            this.mnuTextReportParallelText});
            this.mnuText.Image = ((System.Drawing.Image)(resources.GetObject("mnuText.Image")));
            this.mnuText.Name = "mnuText";
            this.mnuText.Size = new System.Drawing.Size(180, 22);
            this.mnuText.Text = "Текст";
            // 
            // mnuTextReportText
            // 
            this.mnuTextReportText.Name = "mnuTextReportText";
            this.mnuTextReportText.Size = new System.Drawing.Size(189, 22);
            this.mnuTextReportText.Text = "Текст";
            this.mnuTextReportText.Click += new System.EventHandler(this.mnuTextReportText_Click);
            // 
            // mnuTextReportParallelText
            // 
            this.mnuTextReportParallelText.Name = "mnuTextReportParallelText";
            this.mnuTextReportParallelText.Size = new System.Drawing.Size(189, 22);
            this.mnuTextReportParallelText.Text = "Параллельный текст";
            this.mnuTextReportParallelText.Click += new System.EventHandler(this.mnuTextReportParallelText_Click);
            // 
            // mnuChunk
            // 
            this.mnuChunk.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChunkReportIndexWithEmptyText,
            this.mnuChunkReportWithoutParallelText,
            this.mnuChunkReportChunkWithUndefinedWord,
            this.mnuChunkReportUnpublished});
            this.mnuChunk.Image = ((System.Drawing.Image)(resources.GetObject("mnuChunk.Image")));
            this.mnuChunk.Name = "mnuChunk";
            this.mnuChunk.Size = new System.Drawing.Size(180, 22);
            this.mnuChunk.Text = "Фрагмент";
            // 
            // mnuChunkReportIndexWithEmptyText
            // 
            this.mnuChunkReportIndexWithEmptyText.Name = "mnuChunkReportIndexWithEmptyText";
            this.mnuChunkReportIndexWithEmptyText.Size = new System.Drawing.Size(240, 22);
            this.mnuChunkReportIndexWithEmptyText.Text = "Индекс без текста";
            this.mnuChunkReportIndexWithEmptyText.Click += new System.EventHandler(this.mnuChunkReportIndexWithEmptyText_Click);
            // 
            // mnuChunkReportWithoutParallelText
            // 
            this.mnuChunkReportWithoutParallelText.Name = "mnuChunkReportWithoutParallelText";
            this.mnuChunkReportWithoutParallelText.Size = new System.Drawing.Size(240, 22);
            this.mnuChunkReportWithoutParallelText.Text = "Без параллельного текста";
            this.mnuChunkReportWithoutParallelText.Click += new System.EventHandler(this.mnuChunkReportChunkWithoutParallelText_Click);
            // 
            // mnuChunkReportChunkWithUndefinedWord
            // 
            this.mnuChunkReportChunkWithUndefinedWord.Name = "mnuChunkReportChunkWithUndefinedWord";
            this.mnuChunkReportChunkWithUndefinedWord.Size = new System.Drawing.Size(240, 22);
            this.mnuChunkReportChunkWithUndefinedWord.Text = "С неопределенными словами";
            this.mnuChunkReportChunkWithUndefinedWord.Click += new System.EventHandler(this.mnuChunkReportChunkWithUndefinedWord_Click);
            // 
            // mnuChunkReportUnpublished
            // 
            this.mnuChunkReportUnpublished.Name = "mnuChunkReportUnpublished";
            this.mnuChunkReportUnpublished.Size = new System.Drawing.Size(240, 22);
            this.mnuChunkReportUnpublished.Text = "Неопубликованные";
            this.mnuChunkReportUnpublished.Click += new System.EventHandler(this.mnuChunkReportUnpublished_Click);
            // 
            // mnuWord
            // 
            this.mnuWord.Image = ((System.Drawing.Image)(resources.GetObject("mnuWord.Image")));
            this.mnuWord.Name = "mnuWord";
            this.mnuWord.Size = new System.Drawing.Size(180, 22);
            this.mnuWord.Text = "Слово";
            // 
            // mnuComment
            // 
            this.mnuComment.Image = ((System.Drawing.Image)(resources.GetObject("mnuComment.Image")));
            this.mnuComment.Name = "mnuComment";
            this.mnuComment.Size = new System.Drawing.Size(180, 22);
            this.mnuComment.Text = "Комментарий";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuStatistics
            // 
            this.mnuStatistics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStatPosReport,
            this.toolStripSeparator2,
            this.mnuStatReportReadinessStatistics});
            this.mnuStatistics.Image = ((System.Drawing.Image)(resources.GetObject("mnuStatistics.Image")));
            this.mnuStatistics.Name = "mnuStatistics";
            this.mnuStatistics.Size = new System.Drawing.Size(180, 22);
            this.mnuStatistics.Text = "Статистика";
            // 
            // mnuStatPosReport
            // 
            this.mnuStatPosReport.Name = "mnuStatPosReport";
            this.mnuStatPosReport.Size = new System.Drawing.Size(180, 22);
            this.mnuStatPosReport.Text = "Части речи";
            this.mnuStatPosReport.Click += new System.EventHandler(this.mnuStatPosReport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuStatReportReadinessStatistics
            // 
            this.mnuStatReportReadinessStatistics.Name = "mnuStatReportReadinessStatistics";
            this.mnuStatReportReadinessStatistics.Size = new System.Drawing.Size(180, 22);
            this.mnuStatReportReadinessStatistics.Text = "Выполнение";
            this.mnuStatReportReadinessStatistics.Click += new System.EventHandler(this.mnuStatReportReadinessStatistics_Click_1);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.morphToolStripMenuItem});
            this.mnuTools.Image = ((System.Drawing.Image)(resources.GetObject("mnuTools.Image")));
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(111, 20);
            this.mnuTools.Text = "Инструменты";
            // 
            // morphToolStripMenuItem
            // 
            this.morphToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("morphToolStripMenuItem.Image")));
            this.morphToolStripMenuItem.Name = "morphToolStripMenuItem";
            this.morphToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.morphToolStripMenuItem.Text = "Морфология";
            this.morphToolStripMenuItem.Click += new System.EventHandler(this.mnuMorphTable_Click);
            // 
            // mnuWindow
            // 
            this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloseAllWindows,
            this.mnuCloseAllWindowsExceptActive});
            this.mnuWindow.Image = ((System.Drawing.Image)(resources.GetObject("mnuWindow.Image")));
            this.mnuWindow.MergeIndex = 2;
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new System.Drawing.Size(64, 20);
            this.mnuWindow.Text = "Окно";
            // 
            // mnuCloseAllWindows
            // 
            this.mnuCloseAllWindows.Image = ((System.Drawing.Image)(resources.GetObject("mnuCloseAllWindows.Image")));
            this.mnuCloseAllWindows.Name = "mnuCloseAllWindows";
            this.mnuCloseAllWindows.Size = new System.Drawing.Size(241, 22);
            this.mnuCloseAllWindows.Text = "Закрыть все фрагменты";
            this.mnuCloseAllWindows.Click += new System.EventHandler(this.mnuCloseAllWindows_Click);
            // 
            // mnuCloseAllWindowsExceptActive
            // 
            this.mnuCloseAllWindowsExceptActive.Name = "mnuCloseAllWindowsExceptActive";
            this.mnuCloseAllWindowsExceptActive.Size = new System.Drawing.Size(241, 22);
            this.mnuCloseAllWindowsExceptActive.Text = "Закрыть все, кроме активного";
            this.mnuCloseAllWindowsExceptActive.Click += new System.EventHandler(this.mnuCloseAllWindowsExceptActive_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(831, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // DocumentContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 486);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DocumentContainer";
            this.Load += new System.EventHandler(this.DocumentContainer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAllWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAllWindowsExceptActive;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuExportToRusCorporaXml;
        private System.Windows.Forms.ToolStripMenuItem mnuText;
        private System.Windows.Forms.ToolStripMenuItem mnuChunk;
        private System.Windows.Forms.ToolStripMenuItem mnuWord;
        private System.Windows.Forms.ToolStripMenuItem mnuComment;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuStatistics;
        private System.Windows.Forms.ToolStripMenuItem morphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportText;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportParallelText;
        private System.Windows.Forms.ToolStripMenuItem mnuChunkReportIndexWithEmptyText;
        private System.Windows.Forms.ToolStripMenuItem mnuChunkReportWithoutParallelText;
        private System.Windows.Forms.ToolStripMenuItem mnuChunkReportChunkWithUndefinedWord;
        private System.Windows.Forms.ToolStripMenuItem mnuChunkReportUnpublished;
        private System.Windows.Forms.ToolStripMenuItem mnuStatPosReport;
        private System.Windows.Forms.ToolStripMenuItem mnuStatReportReadinessStatistics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
