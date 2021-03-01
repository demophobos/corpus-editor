using Auth;
using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkContainer : DockContent
    {
        private DocumentProcess _documentProcess;

        private ReportProcess _reportProcess;
        public IndexModel Index { get; private set; }

        private ChunkExplorer _chunkExplorer;

        private MorphSelector _morphSelector;

        private InterpContainer _interpContainer;

        private ChunkModel _chunk;

        private SaveFileDialog _saveFileDialog;

        public ChunkContainer(IndexModel index, DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            _reportProcess = new ReportProcess(_documentProcess);

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
                var query = new ChunkQuery { IndexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                btnDeleteChunk.Enabled = 
                    btnEditChunk.Enabled = 
                    btnCopyTextToBuffer.Enabled = 
                    btnSaveAs.Enabled = 
                    btnShowHideMorphologyPane.Enabled = 
                    btnShowHideTranslationPane.Enabled = 
                    btnMorphServices.Enabled = _chunk != null;

                btnAddChunk.Enabled = _chunk == null;
            }
        }

        private void ChunkExplorer_EnablePublishing(object sender, bool e)
        {
            btnPublishChunk.Enabled = e;
        }

        private async void ChunkContainer_LoadAsync(object sender, EventArgs e)
        {
            var query = new ChunkQuery { IndexId = Index.Id };

            _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

            btnAddChunk.Enabled = _chunk == null;

            btnCopyTextToBuffer.Enabled = btnDeleteChunk.Enabled = btnEditChunk.Enabled = btnMorphServices.Enabled = btnSaveAs.Enabled = _chunk != null;

            if (_chunk != null)
            {
                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;

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

                var query = new ChunkQuery { IndexId = Index.Id };

                _chunk = await ChunkProcess.GetChunkByQuery(query).ConfigureAwait(true);

                _chunkExplorer = new ChunkExplorer(_chunk);

                _chunkExplorer.Show(dockPanel1, DockState.Document);

                _chunkExplorer.ElementSelected += ChunkExplorer_ElementSelected;

                _chunkExplorer.EnablePublishing += ChunkExplorer_EnablePublishing;
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
            }
        }

        private void btnShowHideMorphologyPane_Click(object sender, EventArgs e)
        {
            btnShowHideMorphologyPane.Checked = btnShowHideMorphologyPane.Tag.ToString() == "show";

            if (_morphSelector == null || _morphSelector.IsDisposed)
            {
                _morphSelector = new MorphSelector(Index);

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
            _chunkExplorer.CheckMorphStatus(e);

            btnPublishChunk.Enabled = true;
        }

        private void MorphSelector_ElementMorphAccepted(object sender, ElementModel e)
        {
            _chunkExplorer.CheckMorphStatus(e);

            btnPublishChunk.Enabled = true;
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

        private void btnMorphServices_Click(object sender, EventArgs e)
        {
            if (_documentProcess.Header.Lang == LangStringEnum.Latin)
            {
                _chunkExplorer.RunMorphLatinService();
            }
            if (_documentProcess.Header.Lang == LangStringEnum.Russian)
            {
                _chunkExplorer.RunMorphRussianService();
            }
        }

        private async void btnPublishChunk_ClickAsync(object sender, EventArgs e)
        {
            await _chunkExplorer.PublishChunkAsync();
        }

        private void btnCopyTextToBuffer_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_chunk.Value);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            _saveFileDialog = new SaveFileDialog
            {
                Title = $"Сохранение фрагмента {_documentProcess.Header.Code}_{Index.Name}",

                Filter = "Текст (*.txt) |*.txt | Json (*.json) |*.json | RusCorpora (*.xml) |*.xml",

                FileName = $"{_documentProcess.Header.Code}_{Index.Name}",

                OverwritePrompt = true
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
                    if (!File.Exists(_saveFileDialog.FileName))
                    {
                        using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                        {
                            sw.Write(_chunk.Value);
                        }
                    }
                }

                if (_saveFileDialog.FilterIndex == 2)
                {
                    if (!File.Exists(_saveFileDialog.FileName))
                    {
                        using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                        {
                            sw.Write(_chunk.ValueObj);
                        }
                    }
                }

                if (_saveFileDialog.FilterIndex == 3)
                {
                    if (!File.Exists(_saveFileDialog.FileName))
                    {
                        using (StreamWriter sw = File.CreateText(_saveFileDialog.FileName))
                        {
                            var data = await _reportProcess.CreateRusCorporaChunkReport(Index, _chunk, _interpContainer.Interpretations, _interpContainer.Originals).ConfigureAwait(true);

                            sw.Write(data);
                        }
                    }
                }
            }
        }
    }
}
