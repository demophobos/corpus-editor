using Common.Process;
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
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkContainer : DockContent
    {

        private IndexModel _index;

        private ChunkExplorer _chunkExplorer;

        private ChunkModel _chunk;

        public event EventHandler<ChunkModel> ChunkAdded;

        public event EventHandler<ChunkModel> ChunkUpdated;

        public event EventHandler<ChunkModel> ChunkDeleted;

        public ChunkContainer(IndexModel index)
        {
            _index = index;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;

            Text = index.Name;
        }

        private async void btnAddChunk_Click(object sender, EventArgs e)
        {
            _chunk = new ChunkModel { IndexId = _index.Id };

            var editor = new ChunkEditor(_index, _chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                _chunk = await ChunkProcess.GetChunk(_index.Id).ConfigureAwait(true);

                btnAddChunk.Enabled = false;

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = btnMorphAnalysis.Enabled = true;

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                ChunkAdded.Invoke(this, _chunk);
            }
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            _chunk = await ChunkProcess.GetChunk(_index.Id).ConfigureAwait(true);

            btnAddChunk.Enabled = _chunk == null;

            btnDeleteChunk.Enabled = btnEditChunk.Enabled = btnMorphAnalysis.Enabled = _chunk != null;

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);
            }
        }

        private async void btnEditChunk_Click(object sender, EventArgs e)
        {
            var editor = new ChunkEditor(_index, _chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                btnAddChunk.Enabled = false;

                _chunkExplorer.Close();

                _chunk = await ChunkProcess.GetChunk(_index.Id).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                ChunkUpdated.Invoke(this, _chunk);
            }
        }

        private async void btnDeleteChunk_Click(object sender, EventArgs e)
        {
            if (DialogProcess.DeleteWarning(_chunk) == DialogResult.Yes)
            {
                await ChunkProcess.RemoveChunk(_chunk).ConfigureAwait(true);

                _chunkExplorer.Close();

                btnAddChunk.Enabled = true;

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = btnMorphAnalysis.Enabled = false;

                ChunkDeleted.Invoke(this, _chunk);
            }
        }
    }
}
