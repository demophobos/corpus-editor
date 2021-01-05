using Model;
using Process;
using System;
using System.Windows.Forms;

namespace Document
{
    public partial class ChunkEditor : Form
    {
        public ChunkEditor(IndexModel _index, ChunkModel chunkModel)
        {
            InitializeComponent();

            Text = $"{Text} [{_index.Name}]";

            chunkSource.DataSource = chunkModel;
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            chunkSource.EndEdit();

            var chunk = chunkSource.DataSource as ChunkModel;

            await ChunkProcess.SaveChunkAndElements(chunk).ConfigureAwait(true);

            DialogResult = DialogResult.OK;
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtChunk.Text);
        }
    }
}
