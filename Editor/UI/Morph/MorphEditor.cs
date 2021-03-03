using Model;
using Model.Enum;
using Process;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morph
{
    public partial class MorphEditor : Form
    {
        MorphProcess _morphProcess;

        private MorphModel _morphModel;

        public MorphEditor(MorphModel morphModel)
        {
            _morphProcess = new MorphProcess();

            _morphModel = (MorphModel)morphModel.Clone();

            InitializeComponent();
        }

        private async void MorphEditor_Load(object sender, EventArgs e)
        {
            loader1.BringToFront();

            await LoadData().ConfigureAwait(true);

            loader1.SendToBack();
        }

        private async Task LoadData()
        {
            var cmbs = table.Controls.OfType<ComboBox>();

            foreach (var cmb in cmbs)
            {
                cmb.DataSource = await TaxonomyProcess.GetPosAttributeValues(cmb.Tag.ToString()).ConfigureAwait(true);
            }

            morphSource.DataSource = _morphModel;

            Subscribe();
        }

        private void Subscribe()
        {
            var cmbs = table.Controls.OfType<ComboBox>();

            foreach (var cmb in cmbs)
            {
                cmb.SelectedValueChanged += Item_Changed;
            }
        }

        private void Item_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = cmbLang.SelectedValue != null && cmbPos.SelectedValue != null && txtForm.Text.Length > 0 && txtLemma.Text.Length > 0;
            morphSource.EndEdit();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var morph = morphSource.DataSource as MorphModel;

            var model = new MorphModel
            {
                Case = !string.IsNullOrEmpty(morph.Case) ? morph.Case : null,
                Degree = !string.IsNullOrEmpty(morph.Degree) ? morph.Degree : null,
                Dialect = !string.IsNullOrEmpty(morph.Dialect) ? morph.Dialect : null,
                Feature = !string.IsNullOrEmpty(morph.Feature) ? morph.Feature : null,
                Form = morph.Form,
                Gender = !string.IsNullOrEmpty(morph.Gender) ? morph.Gender : null,
                Lang = morph.Lang,
                Lemma = morph.Lemma,
                Mood = !string.IsNullOrEmpty(morph.Mood) ? morph.Mood : null,
                Number = !string.IsNullOrEmpty(morph.Number) ? morph.Number : null,
                Person = !string.IsNullOrEmpty(morph.Person) ? morph.Person : null,
                Pos = morph.Pos,
                Tense = !string.IsNullOrEmpty(morph.Tense) ? morph.Tense : null,
                Voice = !string.IsNullOrEmpty(morph.Voice) ? morph.Voice : null,
                Id = morph.Id
            };
            morph = await _morphProcess.SaveMorph(model);
        }
    }
}
