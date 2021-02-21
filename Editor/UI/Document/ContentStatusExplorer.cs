using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ContentStatusExplorer : DockContent
    {
        public event EventHandler<ChunkStatusModel> ChunkSelected;

        DocumentProcess _documentProcess;
        private List<ChunkViewModel> _chunks;

        public ContentStatusExplorer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();

        }

        private async Task LoadDataAsync()
        {
            loader1.BringToFront();

            loader1.SetStatus("Обновление фрагментов");

            _chunks = await _documentProcess.GetChunksByHeader().ConfigureAwait(true);

            var statusItems = _chunks.OrderBy(i=>i.IndexOrder).Select(i => CreateStatusModel(i)).OrderByDescending(i=>i.UnresolvedItems);

            dataSource.DataSource = statusItems;

            lblTotalValue.Text = statusItems.Count().ToString();

            lblDoneValue.Text = statusItems.Count(i => i.UnresolvedItems == 0).ToString();

            lblTotalWordsValue.Text = (statusItems.Sum(i => i.ResolvedItems) + statusItems.Sum(i => i.UnresolvedItems)).ToString();

            lblWordsDoneValue.Text = statusItems.Sum(i => i.ResolvedItems).ToString();

            loader1.SendToBack();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["unresolvedItemsCount"].Value != null && (int)row.Cells["unresolvedItemsCount"].Value == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                }
            }
        }
        private static ChunkStatusModel CreateStatusModel(ChunkViewModel chunk)
        {
            var publishedElements = JsonConvert.DeserializeObject<ChunkValueItemModel[]>(chunk.ValueObj).Where(i => i.Type == (int)ElementTypeEnum.Word);

            var resolvedItems = publishedElements.Count(j => j.MorphId != null);

            var unresolvedItems = publishedElements.Count(j => j.MorphId == null);

            return new ChunkStatusModel
            {
                Id = chunk.Id,
                IndexId = chunk.IndexId,
                IndexName = chunk.IndexName,
                ChunkText = chunk.Value,
                ResolvedItems = resolvedItems,
                UnresolvedItems = unresolvedItems
            };
        }

        private async void ContentStatusExplorer_Load(object sender, EventArgs e)
        {
            await LoadDataAsync().ConfigureAwait(true);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync().ConfigureAwait(true);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataSource.Current != null && dataSource.Current is ChunkStatusModel chunkStatus)
            {
                ChunkSelected.Invoke(this, chunkStatus);
            }
        }

        private async void btnPublish_Click(object sender, EventArgs e)
        {
            var updatedChunks = new List<ChunkViewModel>();

            loader1.BringToFront();

            loader1.SetStatus("Публикация фрагментов ...");

            statusStrip1.Enabled = toolStrip2.Enabled = false;

            var chunks = await ChunkProcess.GetChunksByQuery(new ChunkQuery { HeaderId = _documentProcess.Header.Id });
            
            int updatedCount = 0;

            int count = 0;

            foreach (var chunkView in chunks)
            {
                var chunk = new ChunkModel { Id = chunkView.Id, HeaderId = chunkView.HeaderId, IndexId = chunkView.IndexId, Value = chunkView.Value, ValueObj = chunkView.ValueObj };

                var elements = await ElementProcess.GetElements(new ElementQuery { chunkId = chunk.Id }).ConfigureAwait(true);

                var newValueObj = await ChunkProcess.CreateChunkValueObjs(elements).ConfigureAwait(true);

                var published = await ChunkProcess.PublishChunkValueObj(chunk, newValueObj).ConfigureAwait(true);

                if (published != null)
                {
                    updatedCount += 1;
                    updatedChunks.Add(chunkView);
                }

                count += 1;

                loader1.SetStatus($"Опубликовано фрагментов: {updatedCount} из {chunks.Count}. Обработано: {count}");
            }

            await LoadDataAsync().ConfigureAwait(true);

            DialogProcess.InfoMessage($"Публикация фрагментов { _documentProcess.Header.Code}", $"Опубликовано: {updatedCount} из {chunks.Count}: {string.Join(", ", updatedChunks.Select(i => i.IndexName))}");

            statusStrip1.Enabled = toolStrip2.Enabled = true;
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int wrapLen = 84;
            if ((e.RowIndex >= 0) && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string cellText = cell.Value.ToString();
                if (cellText.Length >= wrapLen)
                {
                    cell.ToolTipText = "";
                    int n = cellText.Length / wrapLen;
                    for (int i = 0; i <= n; i++)
                    {
                        int wStart = wrapLen * i;
                        int wEnd = wrapLen * (i + 1);

                        if (wEnd >= cellText.Length)
                            wEnd = cellText.Length;

                        cell.ToolTipText += cellText.Substring(wStart, wEnd - wStart) + "\n";
                    }
                }
            }
        }
    }
}
