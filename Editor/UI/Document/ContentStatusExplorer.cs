using Model;
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

            _chunks = await _documentProcess.GetChunksByHeader().ConfigureAwait(true);

            var statusItems = _chunks.OrderBy(i=>i.IndexOrder).Select(i => CreateStatusModel(i)).OrderBy(i=>i.IndexName);

            dataSource.DataSource = statusItems;

            loader1.SendToBack();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((int)row.Cells["unresolvedItemsCount"].Value == 0)
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
            var publishedElements = JsonConvert.DeserializeObject<ChunkValueItemModel[]>(chunk.ValueObj).Where(i => i.Type == 0);

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
    }
}
