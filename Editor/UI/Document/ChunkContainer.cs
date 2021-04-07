using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkContainer : DockContent
    {
        private DocumentProcess _documentProcess;

        public IndexModel Index { get; private set; }

        private ChunkExplorer _chunkExplorer;

        private MorphSelector _morphSelector;

        private InterpContainer _interpContainer;

        private ChunkModel _chunk;

        private ElementModel _currentElement;

        public event EventHandler<Tuple<List<ChunkModel>, ElementModel, ChunkEditAction>> ChunkBulkMorphChanged;

        public event EventHandler<string> StatusInfoShown;

        public ReplaceDialog ReplaceDialog;
        public ChunkContainer(IndexModel index, DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            Index = index;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;

            Text = index.Name;
        }

        private void DisableFinctions()
        {
            toolStrip1.Enabled = false;
        }

        private void EnableFunctions()
        {
            btnRunMorphService.Enabled =
            cmbMorphService.Enabled =
            btnDeleteChunk.Enabled =
            btnEditChunk.Enabled =
            btnReplaceAll.Enabled = _chunk != null;

            btnAddChunk.Enabled = _chunk == null;

            toolStrip1.Enabled = true;
        }

        private void ChunkExplorer_EnablePublishing(object sender, bool e)
        {
            btnPublishChunk.Enabled = e;

            StatusInfoShown?.Invoke(this, $"Фрагмент {Index.Name} изменен");

            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            DisableFinctions();

            var services = TaxonomyProcess.GetMorphServices();

            ComboProcess.CreateSelect(cmbMorphService, services.ToArray());

            cmbMorphService.SelectedItem = services.FirstOrDefault(i => i.Id == _documentProcess.Header.Lang);

            var query = new ChunkQuery { IndexId = Index.Id };

            _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

            _morphSelector = new MorphSelector(Index);

            _morphSelector.ElementMorphAccepted += MorphSelector_ElementMorphAccepted;

            _morphSelector.ElementMorphRejected += MorphSelector_ElementMorphRejected;

            _morphSelector.ChunkBulkMorphChanged += MorphSelector_ChunkBulkMorphChanged;

            _interpContainer = new InterpContainer(_documentProcess, Index);

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.ElementsLoaded += ChunkExplorer_ElementsLoaded;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                _interpContainer.Show(dockPanel1, DockState.DockBottom);

                _morphSelector.Show(dockPanel1, DockState.DockBottom);

                await _interpContainer.LoadData(_chunk).ConfigureAwait(true);

            }
            else
            {
                _morphSelector.Show(dockPanel1, DockState.DockBottom);

                _interpContainer.Show(dockPanel1, DockState.DockBottom);
            }

            _morphSelector.StatusInfoShown += MorphSelector_StatusInfoShown;

            EnableFunctions();
        }

        private void MorphSelector_StatusInfoShown(object sender, string e)
        {
            StatusInfoShown?.Invoke(sender, e);
        }

        private void ChunkExplorer_ElementsLoaded(object sender, EventArgs e)
        {
            EnableFunctions();
        }

        private async void btnAddChunk_Click(object sender, EventArgs e)
        {
            _chunk = new ChunkModel { IndexId = Index.Id };

            var editor = new ChunkEditor(Index, _chunk, _documentProcess.Header.Lang);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                DisableFinctions();

                var query = new ChunkQuery { IndexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.ElementsLoaded += ChunkExplorer_ElementsLoaded;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Interpretation)
                {
                    await _interpContainer.CreateLinkAndLoadOriginal(_chunk).ConfigureAwait(true);
                }
                else
                {
                    await _interpContainer.LoadData(_chunk).ConfigureAwait(true);
                }
            }
        }

        private async void btnEditChunk_Click(object sender, EventArgs e)
        {
            var editor = new ChunkEditor(Index, _chunk, _documentProcess.Header.Lang);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                DisableFinctions();

                _chunkExplorer.Close();

                var query = new ChunkQuery { IndexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.ElementsLoaded += ChunkExplorer_ElementsLoaded;
            }
        }

        private async void ChunkExplorer_ElementSelected(object sender, ElementModel e)
        {
            btnCopyToClipboard.Enabled = true;

            _currentElement = e;

            if (_morphSelector != null)
            {
                await _morphSelector.LoadDataAsync(e, _chunk);
            }
        }

        private async void btnDeleteChunk_Click(object sender, EventArgs e)
        {
            if (DialogProcess.DeleteWarning(_chunk) == DialogResult.Yes)
            {
                DisableFinctions();

                await ChunkProcess.RemoveChunk(_chunk).ConfigureAwait(true);

                _chunkExplorer.Close();

                _chunk = null;

                EnableFunctions();
            }
        }

        private void MorphSelector_ElementMorphRejected(object sender, ElementModel e)
        {
            _chunkExplorer.CheckMorphStatus(e);

            btnPublishChunk.Enabled = true;

            StatusInfoShown?.Invoke(this, $"Фрагмент {Index.Name} изменен");

            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private void MorphSelector_ElementMorphAccepted(object sender, ElementModel e)
        {
            _chunkExplorer.CheckMorphStatus(e);

            btnPublishChunk.Enabled = true;

            StatusInfoShown?.Invoke(this, $"Фрагмент {Index.Name} изменен");

            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private void MorphSelector_ChunkBulkMorphChanged(object sender, Tuple<List<ChunkModel>, ElementModel, ChunkEditAction> e)
        {
            ChunkBulkMorphChanged?.Invoke(sender, e);
        }

        #region Morph service
        private void btnRunMorphService_Click(object sender, EventArgs e)
        {
            if (cmbMorphService.SelectedItem is TaxonomyModel service)
            {
                switch (service.Id)
                {
                    case LangStringEnum.Greek:
                        _chunkExplorer.RunGreekMorphService();
                        break;
                    case LangStringEnum.Latin:
                        _chunkExplorer.RunLatinMorphService();
                        break;
                    case LangStringEnum.Russian:
                        _chunkExplorer.RunRussianMorphService();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Publish
        private async void btnPublishChunk_ClickAsync(object sender, EventArgs e)
        {
            await _chunkExplorer.PublishChunkAsync().ConfigureAwait(true);

            StatusInfoShown?.Invoke(this, $"Изменения фрагмента {Index.Name} опубликованы");

            btnPublishChunk.ToolTipText = "Изменения опубликованы";
        }
        #endregion

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_currentElement.Value);

            StatusInfoShown?.Invoke(this, $"Форма '{_currentElement.Value}' скопирована в буфер обмена");
        }

        private async void btnReplaceAll_Click(object sender, EventArgs e)
        {

            ReplaceDialog.Input = _chunk.Value;

            if (ReplaceDialog.ShowDialog() == DialogResult.OK)
            {

                var document = dockPanel1.DocumentsToArray().FirstOrDefault();

                document.DockHandler.DockPanel = null;

                document.DockHandler.Close();

                var chunk = new ChunkModel
                {
                    HeaderId = _chunk.HeaderId,
                    Id = _chunk.Id,
                    IndexId = _chunk.IndexId,
                    Status = ChunkStatusEnum.Changed,
                    Value = ReplaceDialog.Output,
                    ValueObj = _chunk.ValueObj
                };

                await ChunkProcess.SaveChunkAndElements(chunk, _documentProcess.Header.Lang).ConfigureAwait(true);

                var query = new ChunkQuery { IndexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.ElementsLoaded += ChunkExplorer_ElementsLoaded;
            }
        }
    }
}
