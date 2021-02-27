using Model;
using Process;
using System;
using System.Windows.Forms;

namespace Document
{
    public partial class ChunkEditor : Form
    {
        private IndexModel _index;
        public ChunkEditor(IndexModel index, ChunkModel chunkModel)
        {
            _index = index;

            InitializeComponent();

            Text = $"{Text} [{_index.Name}]";

            chunkSource.DataSource = chunkModel;

            txtChunk.Text = txtChunk.Text.ToString();
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            loader1.BringToFront();

            btnSave.Enabled = btnCancel.Enabled = false;

            loader1.SetStatus("Обработка и сохранение фрагмента ...");

            chunkSource.EndEdit();

            var chunk = (ChunkModel)chunkSource.DataSource;

            var chunkBase = new ChunkModel { Id = chunk.Id, IndexId = chunk.IndexId, Value = chunk.Value, HeaderId = _index.HeaderId };

            await ChunkProcess.SaveChunkAndElements(chunkBase).ConfigureAwait(true);

            loader1.SendToBack();

            DialogResult = DialogResult.OK;
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtChunk.Text);
        }
    }
}
