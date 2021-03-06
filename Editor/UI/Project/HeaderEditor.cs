using Model;
using Model.Enum;
using Process;
using System;
using System.Windows.Forms;

namespace Project
{
    public partial class HeaderEditor : Form
    {
        private HeaderModel _header;

        public HeaderEditor(HeaderModel header)
        {
            _header = header;

            InitializeComponent();
        }

        private async void HeaderEditor_Load(object sender, EventArgs e)
        {
            langSource.DataSource = await TaxonomyProcess.GetLanguages().ConfigureAwait(true);

            editionTypeSource.DataSource = await TaxonomyProcess.GetEditionTypes().ConfigureAwait(true);

            var project = await ProjectProcess.GetProject(_header.ProjectId).ConfigureAwait(true);

            if (project != null)
            {
                Text = $"{project.Code} [{_header.EditionType}]";
            }

            headerSource.DataSource = _header;

            cmbLang.SelectedIndexChanged += ItemChanged;

            txtEditionCode.TextChanged += ItemChanged;

            txtTitle.TextChanged += ItemChanged;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await HeaderProcess.SaveHeader(_header);

            DialogResult = DialogResult.OK;
        }

        private void ItemChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtTitle.Text.Length > 0 && txtEditionCode.Text.Length > 0 && cmbLang.SelectedItem != null;
        }
    }
}
