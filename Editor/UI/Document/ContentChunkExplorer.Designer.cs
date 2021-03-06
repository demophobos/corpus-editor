
namespace Document
{
    partial class ContentChunkExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentChunkExplorer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPublish = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IndexName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChunkText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unresolvedItemsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resolvedItemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSource = new System.Windows.Forms.BindingSource(this.components);
            this.loader1 = new Common.Control.Loader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDone = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDoneValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalWordsValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWordsDone = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWordsDoneValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPublish});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(433, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPublish
            // 
            this.btnPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPublish.Enabled = false;
            this.btnPublish.Image = ((System.Drawing.Image)(resources.GetObject("btnPublish.Image")));
            this.btnPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(23, 22);
            this.btnPublish.Text = "Опубликовать";
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexName,
            this.ChunkText,
            this.unresolvedItemsCount,
            this.resolvedItemsDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(433, 373);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // IndexName
            // 
            this.IndexName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IndexName.DataPropertyName = "IndexName";
            this.IndexName.HeaderText = "Индекс";
            this.IndexName.Name = "IndexName";
            this.IndexName.ReadOnly = true;
            this.IndexName.Width = 70;
            // 
            // ChunkText
            // 
            this.ChunkText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChunkText.DataPropertyName = "ChunkText";
            this.ChunkText.HeaderText = "Текст";
            this.ChunkText.Name = "ChunkText";
            this.ChunkText.ReadOnly = true;
            // 
            // unresolvedItemsCount
            // 
            this.unresolvedItemsCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.unresolvedItemsCount.DataPropertyName = "UnresolvedItems";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.unresolvedItemsCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.unresolvedItemsCount.HeaderText = "Не принято";
            this.unresolvedItemsCount.Name = "unresolvedItemsCount";
            this.unresolvedItemsCount.ReadOnly = true;
            this.unresolvedItemsCount.Width = 90;
            // 
            // resolvedItemsDataGridViewTextBoxColumn
            // 
            this.resolvedItemsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.resolvedItemsDataGridViewTextBoxColumn.DataPropertyName = "ResolvedItems";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resolvedItemsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.resolvedItemsDataGridViewTextBoxColumn.HeaderText = "Принято";
            this.resolvedItemsDataGridViewTextBoxColumn.Name = "resolvedItemsDataGridViewTextBoxColumn";
            this.resolvedItemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.resolvedItemsDataGridViewTextBoxColumn.Width = 75;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataSource
            // 
            this.dataSource.AllowNew = false;
            this.dataSource.DataSource = typeof(Model.ChunkStatusModel);
            // 
            // loader1
            // 
            this.loader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loader1.Location = new System.Drawing.Point(0, 0);
            this.loader1.Name = "loader1";
            this.loader1.Size = new System.Drawing.Size(433, 420);
            this.loader1.TabIndex = 11;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotal,
            this.lblTotalValue,
            this.lblDone,
            this.lblDoneValue,
            this.lblTotalWords,
            this.lblTotalWordsValue,
            this.lblWordsDone,
            this.lblWordsDoneValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(433, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotal
            // 
            this.lblTotal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTotal.Image = ((System.Drawing.Image)(resources.GetObject("lblTotal.Image")));
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(77, 17);
            this.lblTotal.Text = "Фрагментов:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(0, 17);
            // 
            // lblDone
            // 
            this.lblDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblDone.Image = ((System.Drawing.Image)(resources.GetObject("lblDone.Image")));
            this.lblDone.Name = "lblDone";
            this.lblDone.Size = new System.Drawing.Size(16, 17);
            this.lblDone.ToolTipText = "Фрагментов завершено";
            // 
            // lblDoneValue
            // 
            this.lblDoneValue.Name = "lblDoneValue";
            this.lblDoneValue.Size = new System.Drawing.Size(0, 17);
            // 
            // lblTotalWords
            // 
            this.lblTotalWords.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblTotalWords.Image = ((System.Drawing.Image)(resources.GetObject("lblTotalWords.Image")));
            this.lblTotalWords.Name = "lblTotalWords";
            this.lblTotalWords.Size = new System.Drawing.Size(38, 17);
            this.lblTotalWords.Text = "Слов:";
            this.lblTotalWords.ToolTipText = "Всего слов";
            // 
            // lblTotalWordsValue
            // 
            this.lblTotalWordsValue.Name = "lblTotalWordsValue";
            this.lblTotalWordsValue.Size = new System.Drawing.Size(0, 17);
            // 
            // lblWordsDone
            // 
            this.lblWordsDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblWordsDone.Image = ((System.Drawing.Image)(resources.GetObject("lblWordsDone.Image")));
            this.lblWordsDone.Name = "lblWordsDone";
            this.lblWordsDone.Size = new System.Drawing.Size(16, 17);
            this.lblWordsDone.Text = "завершено:";
            this.lblWordsDone.ToolTipText = "Принято определений";
            // 
            // lblWordsDoneValue
            // 
            this.lblWordsDoneValue.Name = "lblWordsDoneValue";
            this.lblWordsDoneValue.Size = new System.Drawing.Size(0, 17);
            // 
            // ContentChunkExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 420);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.loader1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.HideOnClose = true;
            this.Name = "ContentChunkExplorer";
            this.Text = "Фрагменты";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Common.Control.Loader loader1;
        private System.Windows.Forms.BindingSource dataSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChunkText;
        private System.Windows.Forms.DataGridViewTextBoxColumn unresolvedItemsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn resolvedItemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalValue;
        private System.Windows.Forms.ToolStripStatusLabel lblDone;
        private System.Windows.Forms.ToolStripStatusLabel lblDoneValue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPublish;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalWords;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalWordsValue;
        private System.Windows.Forms.ToolStripStatusLabel lblWordsDone;
        private System.Windows.Forms.ToolStripStatusLabel lblWordsDoneValue;
    }
}
