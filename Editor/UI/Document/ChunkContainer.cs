using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
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
            cmbLanguages.Enabled =
            btnDeleteChunk.Enabled =
            btnEditChunk.Enabled =
            btnExport.Enabled =
            btnShowHideMorphologyPane.Enabled =
            btnShowHideTranslationPane.Enabled = _chunk != null;

            btnAddChunk.Enabled = _chunk == null;

            toolStrip1.Enabled = true;
        }

        private void ChunkExplorer_EnablePublishing(object sender, bool e)
        {
            btnPublishChunk.Enabled = e;
            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            DisableFinctions();

            var languages = await TaxonomyProcess.GetLanguages().ConfigureAwait(true);

            ComboProcess.CreateSelect(cmbLanguages, languages.ToArray());

            cmbLanguages.SelectedItem = languages.FirstOrDefault(i => i.Code == _documentProcess.Header.Lang);

            var query = new ChunkQuery { IndexId = Index.Id };

            _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.ElementsLoaded += ChunkExplorer_ElementsLoaded;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                btnShowHideMorphologyPane.Enabled = btnShowHideTranslationPane.Enabled = true;

                btnShowHideMorphologyPane.PerformClick();
            }

            EnableFunctions();
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
                await _morphSelector.LoadDataAsync(e);
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

            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private void MorphSelector_ElementMorphAccepted(object sender, ElementModel e)
        {
            _chunkExplorer.CheckMorphStatus(e);

            btnPublishChunk.Enabled = true;

            btnPublishChunk.ToolTipText = "Изменения не опубликованы";
        }

        private void btnShowHideMorphologyPane_Click(object sender, EventArgs e)
        {
            btnShowHideMorphologyPane.Checked = btnShowHideMorphologyPane.Tag.ToString() == "show";

            if (_morphSelector == null || _morphSelector.IsDisposed)
            {
                _morphSelector = new MorphSelector(_documentProcess, Index, _chunk);

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

        private void btnRunMorphService_Click(object sender, EventArgs e)
        {
            if (cmbLanguages.SelectedItem is TaxonomyModel lang)
            {
                switch (lang.Code)
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

        private async void btnPublishChunk_ClickAsync(object sender, EventArgs e)
        {
            await _chunkExplorer.PublishChunkAsync().ConfigureAwait(true);

            btnPublishChunk.ToolTipText = "Изменения опубликованы";
        }

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

    }
}
