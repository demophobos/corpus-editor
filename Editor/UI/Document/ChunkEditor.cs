using Model;
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

namespace Document
{
    public partial class ChunkEditor : Form
    {
        private ChunkModel _chunkModel;
        public ChunkEditor(ChunkModel chunkModel)
        {
            InitializeComponent();

            _chunkModel = chunkModel;

            chunkSource.DataSource = chunkModel;
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            chunkSource.EndEdit();

            var chunk = chunkSource.DataSource as ChunkModel;

            _chunkModel = await ChunkProcess.SaveChunkAndElements(chunk).ConfigureAwait(true);

            DialogResult = DialogResult.OK;
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtChunk.Text);
        }
    }
}
