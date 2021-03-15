
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
            this.mnuTextReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportTextCommented = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportParallelText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextReportParallelTextCommented = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChunkReport = new System.Windows.Forms.ToolStripMenuItem();
            this.безПараллельногоТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сНеопределеннымиСловамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWordReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWordReportUndefinedWord = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCommentReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatReportReadinessStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseAllWindows = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuTextReport,
            this.mnuChunkReport,
            this.mnuWordReport,
            this.mnuCommentReport,
            this.mnuStatReport,
            this.mnuWindow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuTextReport
            // 
            this.mnuTextReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextReportText,
            this.mnuTextReportTextCommented,
            this.mnuTextReportParallelText,
            this.mnuTextReportParallelTextCommented});
            this.mnuTextReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuTextReport.Image")));
            this.mnuTextReport.MergeIndex = 1;
            this.mnuTextReport.Name = "mnuTextReport";
            this.mnuTextReport.Size = new System.Drawing.Size(64, 20);
            this.mnuTextReport.Text = "Текст";
            // 
            // mnuTextReportText
            // 
            this.mnuTextReportText.Name = "mnuTextReportText";
            this.mnuTextReportText.Size = new System.Drawing.Size(285, 22);
            this.mnuTextReportText.Text = "Текст";
            this.mnuTextReportText.Click += new System.EventHandler(this.mnuTextReportText_Click);
            // 
            // mnuTextReportTextCommented
            // 
            this.mnuTextReportTextCommented.Name = "mnuTextReportTextCommented";
            this.mnuTextReportTextCommented.Size = new System.Drawing.Size(285, 22);
            this.mnuTextReportTextCommented.Text = "Текст с комментарием";
            this.mnuTextReportTextCommented.Click += new System.EventHandler(this.mnuTextReportTextCommented_Click);
            // 
            // mnuTextReportParallelText
            // 
            this.mnuTextReportParallelText.Name = "mnuTextReportParallelText";
            this.mnuTextReportParallelText.Size = new System.Drawing.Size(285, 22);
            this.mnuTextReportParallelText.Text = "Параллельный текст";
            this.mnuTextReportParallelText.Click += new System.EventHandler(this.mnuTextReportParallelText_Click);
            // 
            // mnuTextReportParallelTextCommented
            // 
            this.mnuTextReportParallelTextCommented.Name = "mnuTextReportParallelTextCommented";
            this.mnuTextReportParallelTextCommented.Size = new System.Drawing.Size(285, 22);
            this.mnuTextReportParallelTextCommented.Text = "Параллельный текст с комментарием";
            this.mnuTextReportParallelTextCommented.Click += new System.EventHandler(this.mnuTextReportParallelTextCommented_Click);
            // 
            // mnuChunkReport
            // 
            this.mnuChunkReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.безПараллельногоТекстаToolStripMenuItem,
            this.сНеопределеннымиСловамиToolStripMenuItem});
            this.mnuChunkReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuChunkReport.Image")));
            this.mnuChunkReport.Name = "mnuChunkReport";
            this.mnuChunkReport.Size = new System.Drawing.Size(98, 20);
            this.mnuChunkReport.Text = "Фрагменты";
            // 
            // безПараллельногоТекстаToolStripMenuItem
            // 
            this.безПараллельногоТекстаToolStripMenuItem.Name = "безПараллельногоТекстаToolStripMenuItem";
            this.безПараллельногоТекстаToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.безПараллельногоТекстаToolStripMenuItem.Text = "Без параллельного текста";
            this.безПараллельногоТекстаToolStripMenuItem.Click += new System.EventHandler(this.mnuChunkReportChunkWithoutVersion_Click);
            // 
            // сНеопределеннымиСловамиToolStripMenuItem
            // 
            this.сНеопределеннымиСловамиToolStripMenuItem.Name = "сНеопределеннымиСловамиToolStripMenuItem";
            this.сНеопределеннымиСловамиToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.сНеопределеннымиСловамиToolStripMenuItem.Text = "С неопределенными словами";
            this.сНеопределеннымиСловамиToolStripMenuItem.Click += new System.EventHandler(this.mnuChunkReportChunkWithUndefinedWord_Click);
            // 
            // mnuWordReport
            // 
            this.mnuWordReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWordReportUndefinedWord});
            this.mnuWordReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuWordReport.Image")));
            this.mnuWordReport.Name = "mnuWordReport";
            this.mnuWordReport.Size = new System.Drawing.Size(69, 20);
            this.mnuWordReport.Text = "Слова";
            // 
            // mnuWordReportUndefinedWord
            // 
            this.mnuWordReportUndefinedWord.Name = "mnuWordReportUndefinedWord";
            this.mnuWordReportUndefinedWord.Size = new System.Drawing.Size(170, 22);
            this.mnuWordReportUndefinedWord.Text = "Неопределенные";
            this.mnuWordReportUndefinedWord.Click += new System.EventHandler(this.mnuWordReportUndefinedWord_Click);
            // 
            // mnuCommentReport
            // 
            this.mnuCommentReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuCommentReport.Image")));
            this.mnuCommentReport.Name = "mnuCommentReport";
            this.mnuCommentReport.Size = new System.Drawing.Size(112, 20);
            this.mnuCommentReport.Text = "Комментарии";
            // 
            // mnuStatReport
            // 
            this.mnuStatReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStatReportReadinessStatistics});
            this.mnuStatReport.Image = ((System.Drawing.Image)(resources.GetObject("mnuStatReport.Image")));
            this.mnuStatReport.Name = "mnuStatReport";
            this.mnuStatReport.Size = new System.Drawing.Size(96, 20);
            this.mnuStatReport.Text = "Статистика";
            // 
            // mnuStatReportReadinessStatistics
            // 
            this.mnuStatReportReadinessStatistics.Name = "mnuStatReportReadinessStatistics";
            this.mnuStatReportReadinessStatistics.Size = new System.Drawing.Size(144, 22);
            this.mnuStatReportReadinessStatistics.Text = "Выполнение";
            this.mnuStatReportReadinessStatistics.Click += new System.EventHandler(this.mnuStatReportReadinessStatistics_Click);
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
            this.mnuWindow.Visible = false;
            // 
            // mnuCloseAllWindows
            // 
            this.mnuCloseAllWindows.Image = ((System.Drawing.Image)(resources.GetObject("mnuCloseAllWindows.Image")));
            this.mnuCloseAllWindows.Name = "mnuCloseAllWindows";
            this.mnuCloseAllWindows.Size = new System.Drawing.Size(207, 22);
            this.mnuCloseAllWindows.Text = "Закрыть все фрагменты";
            this.mnuCloseAllWindows.Click += new System.EventHandler(this.mnuCloseAllWindows_Click);
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
        private System.Windows.Forms.ToolStripMenuItem mnuTextReport;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseAllWindows;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportText;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportParallelText;
        private System.Windows.Forms.ToolStripMenuItem mnuChunkReport;
        private System.Windows.Forms.ToolStripMenuItem безПараллельногоТекстаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сНеопределеннымиСловамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuWordReport;
        private System.Windows.Forms.ToolStripMenuItem mnuWordReportUndefinedWord;
        private System.Windows.Forms.ToolStripMenuItem mnuCommentReport;
        private System.Windows.Forms.ToolStripMenuItem mnuStatReport;
        private System.Windows.Forms.ToolStripMenuItem mnuStatReportReadinessStatistics;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportTextCommented;
        private System.Windows.Forms.ToolStripMenuItem mnuTextReportParallelTextCommented;
    }
}
