﻿using Model;
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
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            chunkSource.EndEdit();

            var chunk = (ChunkModel)chunkSource.DataSource;

            var chunkBase = new ChunkModel { Id = chunk.Id, IndexId = chunk.IndexId, Value = chunk.Value, HeaderId = _index.HeaderId };

            await ChunkProcess.SaveChunkAndElements(chunkBase).ConfigureAwait(true);

            DialogResult = DialogResult.OK;
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(txtChunk.Text);
        }
    }
}
