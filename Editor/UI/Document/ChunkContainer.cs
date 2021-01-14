using Common.Process;
using Model;
using Model.Query;
using Process;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkContainer : DockContent
    {
        private DocumentProcess _documentProcess;
        public IndexModel Index { get; private set; }

        private ChunkExplorer _chunkExplorer;

        private ElementMorphSelector _morphSelector;

        private InterpContainer _interpContainer;

        private ChunkModel _chunk;

        public event EventHandler<ChunkModel> ChunkAdded;

        public event EventHandler<ChunkModel> ChunkUpdated;

        public event EventHandler<ChunkModel> ChunkDeleted;

        public ChunkContainer(IndexModel index, DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

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
                var query = new ChunkQuery { indexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                btnAddChunk.Enabled = false;

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = true;

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                btnShowHideMorphologyPane.Enabled = btnShowHideTranslationPane.Enabled = _chunk != null;

                ChunkAdded.Invoke(this, _chunk);
            }
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            var query = new ChunkQuery { indexId = Index.Id };

            _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

            btnAddChunk.Enabled = _chunk == null;

            btnDeleteChunk.Enabled = btnEditChunk.Enabled = _chunk != null;

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                btnShowHideMorphologyPane.Enabled = btnShowHideTranslationPane.Enabled = true;

                btnShowHideMorphologyPane.PerformClick();
            }
        }

        private async void btnEditChunk_Click(object sender, EventArgs e)
        {
            var editor = new ChunkEditor(Index, _chunk);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                btnAddChunk.Enabled = false;

                _chunkExplorer.Close();

                var query = new ChunkQuery { indexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

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

                btnDeleteChunk.Enabled = btnEditChunk.Enabled = btnShowHideMorphologyPane.Enabled = btnShowHideTranslationPane.Enabled = false;

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

        private void btnShowHideTranslationPane_Click(object sender, EventArgs e)
        {
            btnShowHideTranslationPane.Checked = btnShowHideTranslationPane.Tag.ToString() == "show";

            if (_interpContainer == null || _interpContainer.IsDisposed)
            {
                ShowInterpretationContainer();
            }
            else
            {

                if (btnShowHideTranslationPane.Tag.ToString() == "hide")
                {
                    _interpContainer.Hide();

                    btnShowHideTranslationPane.ToolTipText = "Показать переводы";

                    btnShowHideTranslationPane.Tag = "show";
                }
                else
                {
                    _interpContainer.Show();

                    btnShowHideTranslationPane.ToolTipText = "Cкрыть переводы";

                    btnShowHideTranslationPane.Tag = "hide";
                }
            }
        }

        private void ShowInterpretationContainer()
        {
            _interpContainer = new InterpContainer(_documentProcess, Index, _chunk);

            _interpContainer.Show(dockPanel1, DockState.DockBottom);

            btnShowHideTranslationPane.ToolTipText = "Cкрыть переводы";

            btnShowHideTranslationPane.Tag = "hide";

            btnShowHideTranslationPane.Checked = true;

            _interpContainer.Activate();
        }
    }
}
