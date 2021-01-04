﻿using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Morph;
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
    public partial class ElementMorphSelector : DockContent
    {
        MorphProcess _morphProcess;

        ElementModel _element;

        public event EventHandler<ElementModel> ElementMorphAccepted;

        public event EventHandler<ElementModel> ElementMorphRejected;

        public ElementMorphSelector()
        {
            _morphProcess = new MorphProcess();

            InitializeComponent();
        }

        public async Task LoadDataAsync(ElementModel element)
        {
            Enabled = true;

            Text = $"Морфология: {element.Value}";

            _element = element;

            btnAcceptDefinition.Enabled = string.IsNullOrEmpty(element.MorphId);

            btnCancelDefinition.Enabled = !string.IsNullOrEmpty(element.MorphId);

            var query = new MorphQuery { Form = element.Value.ToLower() };

            morphSource.DataSource = await _morphProcess.GetMorphItems(query).ConfigureAwait(true);
        }

        private async void btnAcceptDefinition_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                _element.MorphId = morph.Id;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await LoadDataAsync(_element);

                ElementMorphAccepted.Invoke(this, _element);
            }
        }

        private async void btnUndoAccept_Click(object sender, EventArgs e)
        {
            _element.MorphId = null;

            _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

            await LoadDataAsync(_element);

            ElementMorphRejected.Invoke(this, _element);
        }

        private async void btnMorpheusLat_Click(object sender, EventArgs e)
        {
            if (_element != null)
            {

                var results = await _morphProcess.GetMorpheusAnalysis(_element.Value).ConfigureAwait(true);

                foreach (var result in results)
                {
                    var model = new MorphModel
                    {
                        Case = !string.IsNullOrEmpty(result.Case) ? result.Case : null,
                        Degree = !string.IsNullOrEmpty(result.Degree) ? result.Degree : null,
                        Dialect = !string.IsNullOrEmpty(result.Dialect) ? result.Dialect : null,
                        Feature = !string.IsNullOrEmpty(result.Feature) ? result.Feature : null,
                        Form = result.ExpandedForm,
                        Gender = !string.IsNullOrEmpty(result.Gender) ? result.Gender : null,
                        Lang = LangStringEnum.Latin,
                        Lemma = result.Lemma,
                        Mood = !string.IsNullOrEmpty(result.Mood) ? result.Mood : null,
                        Number = !string.IsNullOrEmpty(result.Number) ? result.Number : null,
                        Person = !string.IsNullOrEmpty(result.Person) ? result.Person : null,
                        Pos = result.Pos,
                        Tense = !string.IsNullOrEmpty(result.Tense) ? result.Tense : null,
                        Voice = !string.IsNullOrEmpty(result.Voice) ? result.Voice : null
                    };

                    model = await _morphProcess.SaveMorph(model).ConfigureAwait(true);

                    if (model != null)
                    {
                        morphSource.List.Add(model);
                    }
                    morphSource.ResetBindings(false);

                }

                lblStatus.Text = $"Morpheus: найдено новых определений для '{_element.Value}': {results.Count}";
            }
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
                var editor = new MorphEditor(model);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    morphSource.ResetCurrentItem();
                }
            }
        }

        private void morphSource_CurrentChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = btnDelete.Enabled = morphSource.Current != null;

            btnCancelDefinition.Enabled = morphSource.Current != null && morphSource.Current is MorphModel model && model.Id == _element.MorphId;
        }

        private void morphSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            btnAcceptDefinitionForAllCases.Enabled = btnCancelDefinitionForAllCases.Enabled = morphSource.List.Count == 1;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["morphId"].Value.ToString() == _element.MorphId)
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Underline);
                }
                else
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
                }
            }
        }

        private async void btnAcceptDefinitionForAllCases_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                var result = await ElementProcess.GetElements(new ElementQuery { value = _element.Value }).ConfigureAwait(true);

                var elements = result.Where(i => string.IsNullOrEmpty(i.MorphId)).ToList();

                foreach (var element in elements)
                {
                    element.MorphId = morph.Id;

                    var savedElement = await ElementProcess.SaveModel(element).ConfigureAwait(true);

                    if (savedElement.Id == _element.Id)
                    {
                        _element = savedElement;
                    }

                    ElementMorphAccepted.Invoke(this, savedElement);
                }

                await LoadDataAsync(_element).ConfigureAwait(true);

                lblStatus.Text = $"Определение применено для {elements.Count} элементов";
            }
        }

        private async void btnCancelDefinitionForAllCases_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                var elements = await ElementProcess.GetElements(new ElementQuery { morphId = morph.Id }).ConfigureAwait(true);

                foreach (var element in elements)
                {
                    element.MorphId = null;

                    var savedElement = await ElementProcess.SaveModel(element).ConfigureAwait(true);

                    if (savedElement.Id == _element.Id)
                    {
                        _element = savedElement;
                    }

                    ElementMorphRejected.Invoke(this, savedElement);
                }

                await LoadDataAsync(_element).ConfigureAwait(true);

                lblStatus.Text = $"Определение отменено для {elements.Count} элементов";

            }
        }
    }
}
