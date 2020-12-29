using Model;
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
            langSource.DataSource = TaxonomyProcess.GetLanguages();

            editionTypeSource.DataSource = TaxonomyProcess.GetEditionTypesString();

            var project = await ProjectProcess.GetProject(_header.ProjectId);

            if (project != null)
            {
                lblCode.Text = $"{project.Code} [{project.Desc}]";
            }

            headerSource.DataSource = _header;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await HeaderProcess.SaveHeader(_header);

            DialogResult = DialogResult.OK;
        }
    }
}
