using Common.Process;
using Model;
using Model.Query;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Morph
{
    public partial class MorphExplorer : DockContent

    {
        List<MorphModel> _morphItems;

        MorphProcess _morphProcess;

        public MorphExplorer()
        {
            InitializeComponent();

            _morphProcess = new MorphProcess();
        }

        private void MorphExplorer_LoadAsync(object sender, EventArgs e)
        {
            ComboProcess.CreateNullableSelect(cmbPos, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Pos).ToArray());

            ComboProcess.CreateNullableSelect(cmbCase, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Case).ToArray());

            ComboProcess.CreateNullableSelect(cmbDegree, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Degree).ToArray());

            ComboProcess.CreateNullableSelect(cmbGender, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Gender).ToArray());

            ComboProcess.CreateNullableSelect(cmbMood, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Mood).ToArray());

            ComboProcess.CreateNullableSelect(cmbNumber, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Number).ToArray());

            ComboProcess.CreateNullableSelect(cmbPerson, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Person).ToArray());

            ComboProcess.CreateNullableSelect(cmbTense, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Tense).ToArray());

            ComboProcess.CreateNullableSelect(cmbVoice, TaxonomyProcess.GetMorphCategoryItems(Model.Enum.MorphCategoryEnum.Voice).ToArray());

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

                Form = txtForm.Text.Trim().Length > 0 ? txtForm.Text.Trim() : null
            };

            _morphItems = await _morphProcess.GetMorphItems(query);

            morphSource.DataSource = _morphItems;

            lblResult.Text = _morphItems.Count.ToString();

            loader1.SendToBack();

            toolStrip1.Enabled = true;
        }

        private async void btnRunFilter_Click(object sender, EventArgs e)
        {
            await ApplyFilterAsync();
        }
    }
}
