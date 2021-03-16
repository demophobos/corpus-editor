using Model;
using Model.Enum;
using Process;
using System;
using System.Windows.Forms;

namespace Document
{
    public partial class ChunkEditor : Form
    {
        private IndexModel _index;

        private string _ruleLang;
        public ChunkEditor(IndexModel index, ChunkModel chunkModel, string lang)
        {
            _index = index;

            _ruleLang = lang;

            InitializeComponent();

            Text = $"{Text} [{_index.Name}]";

            chunkSource.DataSource = chunkModel;
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            loader1.BringToFront();

            btnSave.Enabled = btnCancel.Enabled = false;

            loader1.SetStatus("Обработка и сохранение фрагмента ...");

            chunkSource.EndEdit();

            var chunk = (ChunkModel)chunkSource.DataSource;

            var chunkBase = new ChunkModel
            {
                Id = chunk.Id,
                IndexId = chunk.IndexId,
                Value = chunk.Value,
                HeaderId = _index.HeaderId,
                Status = ChunkStatusEnum.Changed
            };

            await ChunkProcess.SaveChunkAndElements(chunkBase, _ruleLang).ConfigureAwait(true);

            loader1.SendToBack();

            DialogResult = DialogResult.OK;
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtChunk.Text);
        }

        private void txtChunk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                ((RichTextBox)sender).Paste(DataFormats.GetFormat("Text"));
                e.Handled = true;
            }
        }
    }
}
