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

        private RusCorporaReportProcess _rusCorporaReportProcess;
        public IndexModel Index { get; private set; }

        private ChunkExplorer _chunkExplorer;

        private MorphSelector _morphSelector;

        private InterpContainer _interpContainer;

        private ChunkModel _chunk;

        private SaveFileDialog _saveFileDialog;

        public event EventHandler<Tuple<List<ChunkModel>, ElementModel, ChunkEditAction>> ChunkBulkMorphChanged;

        public event EventHandler<string> StatusInfoShown;
        public ChunkContainer(IndexModel index, DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            _rusCorporaReportProcess = new RusCorporaReportProcess(_documentProcess);

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
            btnExport.Enabled = _chunk != null;

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

        #region Export to file
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            _saveFileDialog = new SaveFileDialog
            {
                Title = $"Сохранение фрагмента {_documentProcess.Header.Code}_{Index.Name}",

                Filter = "Текст (*.txt) |*.txt | Json (*.json) |*.json | RusCorpora (*.xml) |*.xml",

                FileName = $"{_documentProcess.Header.Code}_{Index.Name}",

                OverwritePrompt = true,

                AddExtension = true,

                AutoUpgradeEnabled = true,

                SupportMultiDottedExtensions = false

            };

            _saveFileDialog.ValidateNames = true;

            _saveFileDialog.FileOk += SaveFileDialog_FileOk;

            _saveFileDialog.ShowDialog();
        }

        private async void SaveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (_saveFileDialog.FilterIndex == 1)
                {
                    using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                    {
                        sw.Write(_chunk.Value);
                    }
                }

                if (_saveFileDialog.FilterIndex == 2)
                {
                    using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                    {
                        sw.Write(_chunk.ValueObj);
                    }
                }

                if (_saveFileDialog.FilterIndex == 3)
                {
                    using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                    {
                        try
                        {
                            var chunkView = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = _chunk.IndexId });

                            var data = await _rusCorporaReportProcess.CreateRusCorporaChunkReport(chunkView).ConfigureAwait(true);

                            sw.Write(data);
                        }
                        catch (Exception ex)
                        {
                            DialogProcess.InfoMessage("Ошибка сохранения", ex.Message);

                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        #endregion

    }
}
