
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
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportFullText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportOriginalAndVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportVersionAndOriginal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReportChunkWithoutVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportChunkWithUndefinedWord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportChunkUnpublished = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReportReadinessStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(640, 462);
            this.dockPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReport,
            this.mnuWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuReport
            // 
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportFullText,
            this.mnuReportOriginalAndVersion,
            this.mnuReportVersionAndOriginal,
            this.toolStripMenuItem3,
            this.mnuReportChunkWithoutVersion,
            this.mnuReportChunkWithUndefinedWord,
            this.mnuReportChunkUnpublished,
            this.toolStripMenuItem4,
            this.mnuReportReadinessStatistics});
            this.mnuReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuReport.Image")));
            this.mnuReport.MergeIndex = 1;
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(76, 20);
            this.mnuReport.Text = "Отчеты";
            // 
            // mnuWindow
            // 
            this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCloseAllWindows});
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
            this.mnuCloseAllWindows.Size = new System.Drawing.Size(207, 22);
            this.mnuCloseAllWindows.Text = "Закрыть все фрагменты";
            this.mnuCloseAllWindows.Click += new System.EventHandler(this.mnuCloseAllWindows_Click);
            // 
            // mnuReportFullText
            // 
            this.mnuReportFullText.Name = "mnuReportFullText";
            this.mnuReportFullText.Size = new System.Drawing.Size(304, 22);
            this.mnuReportFullText.Text = "Полный текст";
            this.mnuReportFullText.Click += new System.EventHandler(this.mnuReportFullText_Click);
            // 
            // mnuReportOriginalAndVersion
            // 
            this.mnuReportOriginalAndVersion.Name = "mnuReportOriginalAndVersion";
            this.mnuReportOriginalAndVersion.Size = new System.Drawing.Size(304, 22);
            this.mnuReportOriginalAndVersion.Text = "Оригинал + перевод";
            this.mnuReportOriginalAndVersion.Click += new System.EventHandler(this.mnuReportOriginalAndVersion_Click);
            // 
            // mnuReportVersionAndOriginal
            // 
            this.mnuReportVersionAndOriginal.Name = "mnuReportVersionAndOriginal";
            this.mnuReportVersionAndOriginal.Size = new System.Drawing.Size(304, 22);
            this.mnuReportVersionAndOriginal.Text = "Перевод + оригинал";
            this.mnuReportVersionAndOriginal.Click += new System.EventHandler(this.mnuReportVersionAndOriginal_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(301, 6);
            // 
            // mnuReportChunkWithoutVersion
            // 
            this.mnuReportChunkWithoutVersion.Name = "mnuReportChunkWithoutVersion";
            this.mnuReportChunkWithoutVersion.Size = new System.Drawing.Size(304, 22);
            this.mnuReportChunkWithoutVersion.Text = "Фрагменты без параллельного текста";
            this.mnuReportChunkWithoutVersion.Click += new System.EventHandler(this.mnuReportChunkWithoutVersion_Click);
            // 
            // mnuReportChunkWithUndefinedWord
            // 
            this.mnuReportChunkWithUndefinedWord.Name = "mnuReportChunkWithUndefinedWord";
            this.mnuReportChunkWithUndefinedWord.Size = new System.Drawing.Size(304, 22);
            this.mnuReportChunkWithUndefinedWord.Text = "Фрагменты с неопределенными словами";
            this.mnuReportChunkWithUndefinedWord.Click += new System.EventHandler(this.mnuReportChunkWithUndefinedWord_Click);
            // 
            // mnuReportChunkUnpublished
            // 
            this.mnuReportChunkUnpublished.Name = "mnuReportChunkUnpublished";
            this.mnuReportChunkUnpublished.Size = new System.Drawing.Size(304, 22);
            this.mnuReportChunkUnpublished.Text = "Неопубликованные фрагменты";
            this.mnuReportChunkUnpublished.Click += new System.EventHandler(this.mnuReportChunkUnpublished_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(301, 6);
            // 
            // mnuReportReadinessStatistics
            // 
            this.mnuReportReadinessStatistics.Name = "mnuReportReadinessStatistics";
            this.mnuReportReadinessStatistics.Size = new System.Drawing.Size(304, 22);
            this.mnuReportReadinessStatistics.Text = "Статистика выполнения";
            this.mnuReportReadinessStatistics.Click += new System.EventHandler(this.mnuReportReadinessStatistics_Click);
            // 
            // DocumentContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 486);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DocumentContainer";
            this.Load += new System.EventHandler(this.DocumentContainer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAllWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuReportFullText;
        private System.Windows.Forms.ToolStripMenuItem mnuReportOriginalAndVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuReportVersionAndOriginal;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuReportChunkWithoutVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuReportChunkWithUndefinedWord;
        private System.Windows.Forms.ToolStripMenuItem mnuReportChunkUnpublished;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuReportReadinessStatistics;
    }
}
