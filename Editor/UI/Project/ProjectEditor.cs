using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Project
{
    public partial class ProjectEditor : Form
    {
        private ProjectModel _project;
        public ProjectEditor(ProjectModel project)
        {
            _project = project;

            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            projectSource.EndEdit();

            var project = projectSource.DataSource as ProjectModel;

            if (authWorkSource.Current != null && authWorkSource.Current is TaxonomyModel authWork) {

                project.Desc = authWork.Desc;

                project.Status = ProjectStatusStringEnum.Edited;

                await ProjectProcess.Save(project);

                DialogResult = DialogResult.OK;
            }
        }

        private async void ProjectEditor_Load(object sender, EventArgs e)
        {
            var exsistingProjects = await ProjectProcess.GetProjects().ConfigureAwait(true);

            var authWordks = await TaxonomyProcess.GetAuthWorks().ConfigureAwait(true);

            authWorkSource.DataSource = authWordks.Where(i => !exsistingProjects.Select(j => j.Code).ToList().Contains(i.Code)).ToList();

            projectSource.DataSource = _project;
        }
    }
}
