﻿using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Morph
{
    public partial class MorphExplorer : DockContent
    {

        List<MorphModel> _morphItems;

        MorphProcess _morphProcess;

        DocumentProcess _documentProcess;

        public event EventHandler<string> StatusInfoShown;

        public MorphExplorer()
        {
            InitializeComponent();

            _morphProcess = new MorphProcess();
        }

        public MorphExplorer(DocumentProcess documentProcess)
        {
            InitializeComponent();

            _morphProcess = new MorphProcess();

            _documentProcess = documentProcess;
        }

        private async void MorphExplorer_LoadAsync(object sender, EventArgs e)
        {
            var pos = await TaxonomyProcess.GetPos().ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbPos, pos.ToArray());

            var cases = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Case).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbCase, cases.ToArray());

            var degrees = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Degree).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbDegree, degrees.ToArray());

            var genders = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Gender).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbGender, genders.ToArray());

            var moods = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Mood).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbMood, moods.ToArray());

            var numbers = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Number).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbNumber, numbers.ToArray());

            var persons = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Person).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbPerson, persons.ToArray());

            var tenses = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Tense).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbTense, tenses.ToArray());

            var voices = await TaxonomyProcess.GetPosAttributeValues(TaxonomyCategoryEnum.Voice).ConfigureAwait(true);

            ComboProcess.CreateNullableSelect(cmbVoice, voices.ToArray());

            var languages = await TaxonomyProcess.GetLanguages().ConfigureAwait(true);

            var selected = languages.FirstOrDefault(i => i.Code == _documentProcess.Header.Lang);

            ComboProcess.CreateSelect(cmbLang, languages.ToArray(), selected);

        }

        private async Task ApplyFilterAsync()
        {
            toolStrip1.Enabled = false;

            loader1.BringToFront();

            var query = new MorphQuery
            {
                Pos = cmbPos.SelectedIndex > 0 ? cmbPos.SelectedItem.ToString() : null,

                Case = cmbCase.SelectedIndex > 0 ? cmbCase.SelectedItem.ToString() : null,

                Degree = cmbDegree.SelectedIndex > 0 ? cmbDegree.SelectedItem.ToString() : null,

                Gender = cmbGender.SelectedIndex > 0 ? cmbGender.SelectedItem.ToString() : null,

                Mood = cmbMood.SelectedIndex > 0 ? cmbMood.SelectedItem.ToString() : null,

                Number = cmbNumber.SelectedIndex > 0 ? cmbNumber.SelectedItem.ToString() : null,

                Person = cmbPerson.SelectedIndex > 0 ? cmbPerson.SelectedItem.ToString() : null,

                Tense = cmbTense.SelectedIndex > 0 ? cmbTense.SelectedItem.ToString() : null,

                Voice = cmbVoice.SelectedIndex > 0 ? cmbVoice.SelectedItem.ToString() : null,

                Lemma = txtLemma.Text.Trim().Length > 0 ? txtLemma.Text.Trim() : null,

                Form = txtForm.Text.Trim().Length > 0 ? txtForm.Text.Trim() : null,

                Lang = cmbLang.SelectedIndex > 0 ? cmbLang.SelectedItem.ToString() : null
            };

            if (btnIsRule.Checked)
            {
                query.IsRule = true;
            }

            _morphItems = await _morphProcess.GetMorphItems(query);

            morphSource.DataSource = _morphItems;

            loader1.SendToBack();

            toolStrip1.Enabled = true;
        }

        private async void btnRunFilter_Click(object sender, EventArgs e)
        {
            await ApplyFilterAsync();
        }

        private void btnIsRule_Click(object sender, EventArgs e)
        {
            btnApplyRule.Enabled = btnUndoRule.Enabled = btnIsRule.Checked;
        }

        private void morphSource_CurrentChanged(object sender, EventArgs e)
        {
            btnShowUsage.Enabled = btnDelete.Enabled = btnEdit.Enabled = morphSource.Current != null;
        }

        private async void btnApplyRule_Click(object sender, EventArgs e)
        {
            loader1.BringToFront();

            var query = new ElementQuery();

            if (_documentProcess != null)
            {
                query.headerId = _documentProcess.Header.Id;
                query.type = (int)ElementTypeEnum.Word;
            }

            int count = 0;
            int ruleCount = 0;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var morph = row.DataBoundItem as MorphModel;

                if (morph != null)
                {
                    query.value = morph.Form.ToLower();

                    var result = await ElementProcess.GetElements(query).ConfigureAwait(true);

                    var elements = result.Where(i => string.IsNullOrEmpty(i.MorphId)).ToList();

                    foreach (var element in elements)
                    {
                        element.MorphId = morph.Id;

                        await ElementProcess.SaveModel(element).ConfigureAwait(true);

                        await ChunkProcess.ChangeChunkStatus(new List<string> { element.ChunkId }, ChunkStatusEnum.Changed).ConfigureAwait(true);

                        count += 1;
                    }
                }

                ruleCount += 1;

                loader1.SetStatus($"Обработано правил {ruleCount} из {dataGridView1.SelectedRows.Count}. Применено: {count}");
            }

            loader1.SendToBack();

            StatusInfoShown?.Invoke(this, $"Определение применено. Количество слов затронутых слов: {count}");
        }

        private async void btnUndoRule_Click(object sender, EventArgs e)
        {
            if (DialogProcess.UndoWarning() == DialogResult.Yes)
            {
                var query = new ElementQuery();

                if (_documentProcess != null)
                {
                    query.headerId = _documentProcess.Header.Id;
                    query.type = (int)ElementTypeEnum.Word;
                }

                int count = 0;
                int ruleCount = 0;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var morph = row.DataBoundItem as MorphModel;

                    query.morphId = morph.Id;

                    var elements = await ElementProcess.GetElements(query).ConfigureAwait(true);

                    foreach (var element in elements)
                    {
                        element.MorphId = null;

                        await ElementProcess.SaveModel(element).ConfigureAwait(true);

                        await ChunkProcess.ChangeChunkStatus(new List<string> { element.ChunkId }, ChunkStatusEnum.Changed).ConfigureAwait(true);

                        count += 1;

                        loader1.SetStatus(count.ToString());
                    }

                    ruleCount += 1;

                    loader1.SetStatus($"Обработано правил {ruleCount} из {dataGridView1.SelectedRows.Count}. Применено: {count}");
                }

                StatusInfoShown?.Invoke(this, $"Определение отменено. Количество слов затронутых слов: {count}");
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnApplyRule.Enabled = btnUndoRule.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var morph = new MorphModel();
            var editor = new MorphEditor(morph);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                txtForm.Text = morph.Form;
                btnRunFilter.PerformClick();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && DialogProcess.DeleteBulkWarning("Удаление") == DialogResult.Yes)
            {
                loader1.BringToFront();

                loader1.SetStatus("Удаление ...");

                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    if (item.DataBoundItem is MorphModel model)
                    {

                        var results = await ElementProcess.GetElements(new ElementQuery { morphId = model.Id }).ConfigureAwait(true);

                        if (results.Count == 0)
                        {
                            await _morphProcess.DeleteMorph(model).ConfigureAwait(true);


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
                            }
                        }
                    }
                }

                btnRunFilter.PerformClick();

                loader1.SendToBack();
            }
        }

        private async void btnShowUsage_Click(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                var elements = await ElementProcess.GetElements(new ElementQuery { morphId = morph.Id, headerId = _documentProcess.Header.Id }).ConfigureAwait(true);

                StatusInfoShown?.Invoke(this, $"Форма '{morph.Form}'. Количество использований: {elements.Count}");
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (morphSource.Current is MorphModel model)
            {
                MorphModel clone = model.Clone() as MorphModel;

                clone.Id = null;

                var editor = new MorphEditor(clone);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    txtForm.Text = clone.Form;
                    btnRunFilter.PerformClick();
                }
            }
        }
    }
}
