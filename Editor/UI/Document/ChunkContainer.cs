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

        public ChunkContainer(IndexModel index)
        {
            _index = index;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;

            Text = index.Name;
        }



        private void btnAddChunk_Click(object sender, EventArgs e)
        {
            _chunk = new ChunkModel { IndexId = _index.Id };

            var editor = new ChunkEditor(_chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                btnAddChunk.Enabled = false;

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);
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

        private void btnEditChunk_Click(object sender, EventArgs e)
        {
            var editor = new ChunkEditor(_chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                btnAddChunk.Enabled = false;

                _chunkExplorer.Close();

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);
            }
        }

        private void btnDeleteChunk_Click(object sender, EventArgs e)
        {

        }
    }
}
