using Common.Process;
using Model;
using Process;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkContainer : DockContent
    {

        public IndexModel Index { get; private set; }

        private ChunkExplorer _chunkExplorer;

        private ElementMorphSelector _morphSelector;

        private ChunkModel _chunk;

        public event EventHandler<ChunkModel> ChunkAdded;

        public event EventHandler<ChunkModel> ChunkUpdated;

        public event EventHandler<ChunkModel> ChunkDeleted;

        public ChunkContainer(IndexModel index)
        {
            Index = index;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;

            Text = index.Name;
        }

        private async void btnAddChunk_Click(object sender, EventArgs e)
        {
            _chunk = new ChunkModel { IndexId = Index.Id };

            var editor = new ChunkEditor(Index, _chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                _chunk = await ChunkProcess.GetChunk(Index.Id).ConfigureAwait(true);

                btnAddChunk.Enabled = false;

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = true;

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                ChunkAdded.Invoke(this, _chunk);
            }
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            _chunk = await ChunkProcess.GetChunk(Index.Id).ConfigureAwait(true);

            btnAddChunk.Enabled = _chunk == null;

            btnDeleteChunk.Enabled = btnEditChunk.Enabled = _chunk != null;

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.Show(dockPanel1, DockState.Document);
            }
        }

        private async void btnEditChunk_Click(object sender, EventArgs e)
        {
            var editor = new ChunkEditor(Index, _chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                btnAddChunk.Enabled = false;

                _chunkExplorer.Close();

                _chunk = await ChunkProcess.GetChunk(Index.Id).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                ChunkUpdated.Invoke(this, _chunk);
            }
        }

        private async void ChunkExplorer_ElementSelected(object sender, ElementModel e)
        {
            if (_morphSelector != null)
            {
                await _morphSelector.LoadDataAsync(e);
            }
        }

        private async void btnDeleteChunk_Click(object sender, EventArgs e)
        {
            if (DialogProcess.DeleteWarning(_chunk) == DialogResult.Yes)
            {
                await ChunkProcess.RemoveChunk(_chunk).ConfigureAwait(true);

                _chunkExplorer.Close();

                btnAddChunk.Enabled = true;

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = false;

                ChunkDeleted.Invoke(this, _chunk);
            }
        }

        private void btnShowHideMorphologyPane_Click(object sender, EventArgs e)
        {
            btnShowHideMorphologyPane.Checked = btnShowHideMorphologyPane.Tag.ToString() == "show";

            if (_morphSelector == null || _morphSelector.IsDisposed)
            {
                _morphSelector = new ElementMorphSelector(Index);

                _morphSelector.ElementMorphAccepted += MorphSelector_ElementMorphAccepted;

                _morphSelector.ElementMorphRejected += MorphSelector_ElementMorphRejected;

                _morphSelector.Show(dockPanel1, DockState.DockBottom);

                btnShowHideMorphologyPane.ToolTipText = "Cкрыть морфологию";

                btnShowHideMorphologyPane.Tag = "hide";
            }
            else
            {

                if (btnShowHideMorphologyPane.Tag.ToString() == "hide")
                {
                    _morphSelector.Hide();

                    btnShowHideMorphologyPane.ToolTipText = "Показать морфологию";

                    btnShowHideMorphologyPane.Tag = "show";
                }
                else
                {
                    _morphSelector.Show();

                    btnShowHideMorphologyPane.ToolTipText = "Cкрыть морфологию";

                    btnShowHideMorphologyPane.Tag = "hide";
                }
            }
        }

        private void MorphSelector_ElementMorphRejected(object sender, ElementModel e)
        {
            _chunkExplorer.MarkElement(e);
        }

        private void MorphSelector_ElementMorphAccepted(object sender, ElementModel e)
        {
            _chunkExplorer.MarkElement(e);
        }
    }
}
