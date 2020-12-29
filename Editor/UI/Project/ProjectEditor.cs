using Process;
using System;
using System.Windows.Forms;

namespace Project
{
    public partial class ProjectEditor : Form
    {
        public ProjectEditor(Model.ProjectModel project)
        {
            InitializeComponent();

            projectSource.DataSource = project;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            projectSource.EndEdit();

            var project = projectSource.DataSource as Model.ProjectModel;

            await ProjectProcess.Save(project);

            DialogResult = DialogResult.OK;
        }
    }
}
