using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Morph;
using Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class MorphSelector : DockContent
    {
        MorphProcess _morphProcess;

        ElementModel _element;

        IndexModel _index;

        ChunkModel _chunk;

        public event EventHandler<ElementModel> ElementMorphAccepted;

        public event EventHandler<ElementModel> ElementMorphRejected;

        public event EventHandler<Tuple<List<ChunkModel>, ElementModel, ChunkEditAction>> ChunkBulkMorphChanged;

        public event EventHandler<string> StatusInfoShown;
        public MorphSelector(IndexModel index)
        {
            _index = index;

            _morphProcess = new MorphProcess();

            InitializeComponent();
        }

        public async Task LoadDataAsync(ElementModel element, ChunkModel chunk)
        {
            _chunk = chunk;

            Enabled = true;

            _element = element;

            var query = new MorphQuery { Form = element.Value.ToLower() };

            morphSource.DataSource = await _morphProcess.GetMorphItems(query).ConfigureAwait(true);
        }

        private async Task LoadDataAsync(ElementModel element)
        {
            Enabled = true;

            _element = element;

            var query = new MorphQuery { Form = element.Value.ToLower() };

            morphSource.DataSource = await _morphProcess.GetMorphItems(query).ConfigureAwait(true);
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model && DialogProcess.DeleteWarning(model) == DialogResult.Yes)
            {
                mnuTools.Enabled = false;

                loader1.BringToFront();

                loader1.SetStatus("Обновление элементов ...");

                var results = await ElementProcess.GetElements(new ElementQuery { morphId = model.Id }).ConfigureAwait(true);

                if (results.Count == 0)
                {
                    await _morphProcess.DeleteMorph(model).ConfigureAwait(true);

                    await LoadDataAsync(_element).ConfigureAwait(true);
                }
                else
                {
                    if (DialogProcess.DeleteBulkWarning($"'{model.Form}' используется в определениях элементов: {results.Count}") == DialogResult.Yes)
                    {

                        foreach (var element in results)
                        {
                            element.MorphId = null;
                            await ElementProcess.SaveModel(element).ConfigureAwait(true);
                        }

                        await _morphProcess.DeleteMorph(model).ConfigureAwait(true);

                        await LoadDataAsync(_element).ConfigureAwait(true);
                    }
                }

                mnuTools.Enabled = true;

                loader1.SendToBack();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var editor = new MorphEditor(new MorphModel { Form = _element.Value });

            if (editor.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync(_element).ConfigureAwait(true);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
                var editor = new MorphEditor(model);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync(_element).ConfigureAwait(true);
                }
            }
        }

        private void morphSource_CurrentChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = btnClone.Enabled = btnDelete.Enabled = btnCopyForm.Enabled = morphSource.Current != null;

            btnCancelDefinition.Enabled = morphSource.Current != null && morphSource.Current is MorphModel model && model.Id == _element.MorphId;

            btnAcceptDefinition.Enabled = morphSource.Current != null && morphSource.Current is MorphModel && _element.MorphId == null;

            btnCreateRule.Enabled = morphSource.List.Count == 1 && morphSource.Current != null && morphSource.Current is MorphModel model1 && model1.IsRule == false;

            btnRemoveRule.Enabled = morphSource.List.Count == 1 && morphSource.Current != null && morphSource.Current is MorphModel model2 && model2.IsRule == true;

            btnAcceptForAllCases.Enabled = btnCancelAllCases.Enabled = morphSource.List.Count == 1 && morphSource.Current != null;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["morphId"].Value != null && row.Cells["morphId"].Value.ToString() == _element.MorphId)
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Underline);
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                    row.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
                }
            }
        }

        private async void btnCreateRule_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                morph.IsRule = true;

                await _morphProcess.SaveMorph(morph).ConfigureAwait(true);

                morphSource.ResetCurrentItem();

                btnCreateRule.Enabled = false;

                btnRemoveRule.Enabled = true;

                StatusInfoShown?.Invoke(this, $"Правило создано");
            }
        }

        private async void btnRemoveRule_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph && DialogProcess.RuleRemovingWarning() == DialogResult.Yes)
            {
                morph.IsRule = false;

                await _morphProcess.SaveMorph(morph).ConfigureAwait(true);

                morphSource.ResetCurrentItem();

                btnRemoveRule.Enabled = false;

                btnCreateRule.Enabled = true;

                StatusInfoShown?.Invoke(this, $"Правило удалено");
            }
        }

        private async void btnAcceptDefinition_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                _element.MorphId = morph.Id;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await ChunkProcess.ChangeChunkStatus(_chunk, ChunkStatusEnum.Changed).ConfigureAwait(true);

                await LoadDataAsync(_element).ConfigureAwait(true);

                StatusInfoShown?.Invoke(this, $"Определение применено");

                ElementMorphAccepted.Invoke(this, _element);
            }
        }

        private async void btnUndoAccept_Click(object sender, EventArgs e)
        {
            if (DialogProcess.UndoWarning() == DialogResult.Yes)
            {
                _element.MorphId = null;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await ChunkProcess.ChangeChunkStatus(_chunk, ChunkStatusEnum.Changed).ConfigureAwait(true);

                await LoadDataAsync(_element).ConfigureAwait(true);

                StatusInfoShown?.Invoke(this, $"Определение отменено");

                ElementMorphRejected.Invoke(this, _element);
            }
        }

        private void btnCopyForm_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel model)
            {
                Clipboard.SetText(model.Form);

                StatusInfoShown?.Invoke(this, $"'{model.Form}' скопирована в буфер обмена");
            }
        }

        private async void btnAcceptForAllCases_Click(object sender, EventArgs e)
        {
            var chunksToUpdate = new List<string>();

            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                mnuTools.Enabled = false;

                loader1.BringToFront();

                loader1.SetStatus("Обновление элементов ...");

                var elements = await ElementProcess.GetElements(new ElementQuery { type = (int)ElementTypeEnum.Word, value = morph.Form, headerId = _index.HeaderId }).ConfigureAwait(true);

                var applicableElements = elements.Where(i => i.MorphId == null).ToList();

                foreach (var element in applicableElements)
                {
                    element.MorphId = morph.Id;

                    var elem = await ElementProcess.SaveModel(element).ConfigureAwait(true);

                    if (_element.Id == elem.Id)
                    {
                        _element = elem;

                        await LoadDataAsync(_element).ConfigureAwait(true);
                    }

                    if (!chunksToUpdate.Contains(element.ChunkId))
                    {
                        chunksToUpdate.Add(element.ChunkId);
                    }
                }

                var changedChunks = await ChunkProcess.ChangeChunkStatus(chunksToUpdate, ChunkStatusEnum.Changed).ConfigureAwait(true);

                ElementMorphAccepted.Invoke(this, _element);

                StatusInfoShown?.Invoke(this, $"Определение применено к {applicableElements.Count}");

                loader1.SendToBack();

                mnuTools.Enabled = true;

                ShowAffectedCases(changedChunks, ChunkEditAction.MorphDefinitionAccepted);
            }
        }

        private async void btnCancelAllCases_Click(object sender, EventArgs e)
        {
            var chunksToUpdate = new List<string>();

            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                mnuTools.Enabled = false;

                loader1.BringToFront();

                loader1.SetStatus("Обновление элементов ...");

                var elements = await ElementProcess.GetElements(new ElementQuery { type = (int)ElementTypeEnum.Word, value = morph.Form, headerId = _index.HeaderId }).ConfigureAwait(true);

                var applicableElements = elements.Where(i => i.MorphId != null).ToList();

                if (DialogProcess.BulkUndoWarning(applicableElements.Count) == DialogResult.Yes)
                {

                    foreach (var element in applicableElements)
                    {
                        element.MorphId = null;

                        var elem = await ElementProcess.SaveModel(element).ConfigureAwait(true);

                        if (_element.Id == elem.Id)
                        {
                            _element = elem;

                            await LoadDataAsync(_element).ConfigureAwait(true);
                        }

                        if (!chunksToUpdate.Contains(element.ChunkId))
                        {
                            chunksToUpdate.Add(element.ChunkId);
                        }
                    }

                    var changedChunks = await ChunkProcess.ChangeChunkStatus(chunksToUpdate, ChunkStatusEnum.Changed).ConfigureAwait(true);

                    ElementMorphRejected.Invoke(this, _element);

                    StatusInfoShown?.Invoke(this, $"Определение отменено для {applicableElements.Count}");

                    ShowAffectedCases(changedChunks, ChunkEditAction.MorphDefinitionRejected);
                }

                loader1.SendToBack();

                mnuTools.Enabled = true;
            }
        }

        private void ShowAffectedCases(List<ChunkModel> changedChunks, ChunkEditAction chunkEditAction)
        {
            if (changedChunks.Count > 0)
            {
                ChunkBulkMorphChanged?.Invoke(this, new Tuple<List<ChunkModel>, ElementModel, ChunkEditAction>(changedChunks, _element, chunkEditAction));
            }
        }

        private void morphSource_DataSourceChanged(object sender, EventArgs e)
        {
            btnAcceptDefinition.Enabled = morphSource.List.Count > 0 && string.IsNullOrEmpty(_element.MorphId);

            btnCancelDefinition.Enabled = !string.IsNullOrEmpty(_element.MorphId);
        }

        private async void btnClone_Click(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
                MorphModel clone = model.Clone() as MorphModel;

                clone.Id = null;

                var editor = new MorphEditor(clone);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync(_element).ConfigureAwait(true);
                }
            }
        }
    }
}
