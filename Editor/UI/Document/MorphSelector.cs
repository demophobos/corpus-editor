using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Morph;
using Process;
using System;
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

        public event EventHandler<ElementModel> ElementMorphAccepted;

        public event EventHandler<ElementModel> ElementMorphRejected;

        public MorphSelector(IndexModel index)
        {
            _index = index;

            _morphProcess = new MorphProcess();

            InitializeComponent();
        }

        public async Task LoadDataAsync(ElementModel element)
        {
            Enabled = true;

            Text = $"Морфология: {element.Value}";

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

                        await LoadDataAsync(_element);
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
                await LoadDataAsync(_element);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
                var editor = new MorphEditor(model);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync(_element);
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

                lblStatus.Text = $"Правило создано";
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

                lblStatus.Text = $"Правило удалено";
            }
        }

        private async void btnAcceptDefinition_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                _element.MorphId = morph.Id;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await LoadDataAsync(_element).ConfigureAwait(true);

                lblStatus.Text = $"Определение применено";

                ElementMorphAccepted.Invoke(this, _element);
            }
        }

        private async void btnUndoAccept_Click(object sender, EventArgs e)
        {
            if (DialogProcess.UndoWarning() == DialogResult.Yes)
            {
                _element.MorphId = null;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await LoadDataAsync(_element).ConfigureAwait(true);

                lblStatus.Text = $"Определение отменено";

                ElementMorphRejected.Invoke(this, _element);
            }
        }

        private void btnCopyForm_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel model)
            {
                Clipboard.SetText(model.Form);
                lblStatus.Text = $"'{model.Form}' скопирована в буфер обмена";
            }
        }

        private async void btnAcceptForAllCases_Click(object sender, EventArgs e)
        {
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

                        await LoadDataAsync(_element);
                    }
                }

                ElementMorphAccepted.Invoke(this, _element);

                lblStatus.Text = $"Определение применено для {applicableElements.Count}";

                loader1.SendToBack();

                mnuTools.Enabled = true;
            }
        }

        private async void btnCancelAllCases_Click(object sender, EventArgs e)
        {
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

                            await LoadDataAsync(_element);
                        }
                    }

                    ElementMorphRejected.Invoke(this, _element);

                    lblStatus.Text = $"Определение отменено для {applicableElements.Count}";

                }

                loader1.SendToBack();

                mnuTools.Enabled = true;
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
                    await LoadDataAsync(_element);
                }
            }
        }
    }
}
