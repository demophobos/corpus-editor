using Model;
using Model.Enum;
using Process;
using System;
using System.Text;
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
                Status = ChunkStatusEnum.Changed,
                Created = chunk.Created,
                Updated = chunk.Updated
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
                btnPoeticFormat.Enabled = txtChunk.Lines.Length > 0;
            }
        }

        private void btnPoeticFormat_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < txtChunk.Lines.Length; i++)
            {
                if (i > 0 && i % 5 == 0)
                {
                    var indexLength = i.ToString().Length * 2;
                    sb.AppendFormat("{0}{1}{2}", i, new string(' ', 6 - indexLength), txtChunk.Lines[i]);
                }
                else
                {
                    sb.AppendFormat("{0}{1}", new string(' ', 6), txtChunk.Lines[i]);
                }
                if (i <= txtChunk.Lines.Length)
                {
                    sb.Append("\n");
                }
            }
            txtChunk.Text = sb.ToString().TrimEnd();
        }
    }
}
