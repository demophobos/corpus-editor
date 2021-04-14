using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Project
{
    public partial class ProjectExplorer : DockContent
    {
        public event EventHandler<ProjectModel> ProjectDeleted;
        public event EventHandler<ProjectModel> ProjectUpdated;
        public event EventHandler<ProjectModel> ProjectViewProperty;
        public event EventHandler<HeaderModel> HeaderDeleted;
        public event EventHandler<HeaderModel> HeaderSelected;
        public event EventHandler<HeaderModel> HeaderViewProperty;
        public event EventHandler<HeaderModel> HeaderUpdated;
        public event EventHandler<HeaderModel> HeaderAdded;

        public ProjectExplorer()
        {
            InitializeComponent();
        }

        public async Task LoadData()
        {

            treeView1.BeginUpdate();

            loader1.BringToFront();

            var query = new ProjectQuery();

            var projects = await ProjectProcess.GetProjects(query).ConfigureAwait(true);

            //var notDeletedProjects = projects.Where(i => i.Status != ProjectStatusStringEnum.Deleted);

            treeView1.Nodes.Clear();

            foreach (var project in projects.OrderBy(i=>i.Code))
            {
                TreeNode projectNode = CreateNode(project);

                var headers = await HeaderProcess.GetHeaders(project.Id).ConfigureAwait(true);

                foreach (var header in headers.OrderBy(i => i.EditionType))
                {
                    TreeNode headerNode = CreateNode(header);

                    projectNode.Nodes.Add(headerNode);
                }

                treeView1.Nodes.Add(projectNode);
            }

            treeView1.EndUpdate();

            treeView1.ExpandAll();

            loader1.SendToBack();
        }

        private static TreeNode CreateNode(ProjectModel project)
        {
            return new TreeNode
            {
                Name = project.Id,
                Text = $"{project.Code} [{project.Desc}]",
                ImageIndex = 0,
                SelectedImageIndex = 0,
                Tag = project
            };
        }

        private static TreeNode CreateNode(HeaderModel header)
        {
            return new TreeNode
            {
                Name = header.Id,
                Text = $"{header.Code} [{header.Lang}]",
                ImageIndex = 1,
                SelectedImageIndex = 1,
                Tag = header
            };
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                btnDelete.Enabled = true;

                btnAddOriginal.Visible = CheckOriginal();

                btnAddTranslation.Visible = CheckTranslations();

                ProjectViewProperty?.Invoke(this, project);
            }
            else
            {
                btnAddOriginal.Visible = btnAddTranslation.Visible = btnDelete.Enabled = false;
            }

            mnuDeleteHeader.Visible = mnuEditHeader.Visible = treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel;

            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {

                HeaderViewProperty?.Invoke(this, header);
            }
        }

        private bool CheckTranslations()
        {
            return treeView1.SelectedNode.Nodes.Count >= 1;
        }

        private bool CheckOriginal()
        {
            foreach (TreeNode treeNode in treeView1.SelectedNode.Nodes)
            {
                if (treeNode.Tag is HeaderModel header && header.EditionType == EditionTypeStringEnum.Original)
                {
                    return false;
                };
            }
            return true;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new ProjectEditor(new ProjectModel());

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await LoadData().ConfigureAwait(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                var dialog = new ProjectEditor(project);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    treeView1.SelectedNode = CreateNode(project);

                    ProjectUpdated?.Invoke(this, project);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project && DialogProcess.DeleteWarning(project) == DialogResult.Yes)
            {
                loader1.BringToFront();

                var headers = await HeaderProcess.GetHeaders(project.Id).ConfigureAwait(true);

                foreach (var header in headers)
                {
                    await RemoveProjectItemsByHeader(header);
                }

                await ProjectProcess.RemoveProject(project);

                var node = treeView1.Nodes.Find(treeView1.SelectedNode.Name, true).FirstOrDefault();

                if (node != null)
                {
                    treeView1.BeginUpdate();

                    treeView1.Nodes.Remove(node);

                    treeView1.EndUpdate();

                    btnAddTranslation.Visible = btnDelete.Enabled = treeView1.Nodes.Count != 0;

                    ProjectDeleted?.Invoke(this, project);
                }

                loader1.SendToBack();
            }
        }

        private async void btnAddTranslation_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                var header = new HeaderModel { ProjectId = project.Id, EditionType = EditionTypeStringEnum.Interpretation };

                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadData().ConfigureAwait(true);

                    HeaderAdded?.Invoke(this, header);
                }
            }
        }

        private async void btnAddOriginal_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                var header = new HeaderModel { ProjectId = project.Id, EditionType = EditionTypeStringEnum.Original };

                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadData().ConfigureAwait(true);

                    HeaderAdded?.Invoke(this, header);
                }
            }
        }

        private async void mnuEditHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {
                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadData().ConfigureAwait(true);

                    HeaderUpdated?.Invoke(this, header);
                }
            }
        }

        private async void mnuDeleteHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header && DialogProcess.DeleteWarning(header) == DialogResult.Yes)
            {
                loader1.BringToFront();

                await RemoveProjectItemsByHeader(header);

                var node = treeView1.Nodes.Find(treeView1.SelectedNode.Name, true).FirstOrDefault();

                if (node != null)
                {
                    treeView1.BeginUpdate();

                    treeView1.Nodes.Remove(node);

                    treeView1.EndUpdate();

                    HeaderDeleted?.Invoke(this, header);
                }

                loader1.SendToBack();
            }
        }

        private static async Task RemoveProjectItemsByHeader(HeaderModel header)
        {
            var documentProcess = new DocumentProcess(header);

            await documentProcess.DeleteInterpsByQuery(new InterpViewQuery { InterpHeaderId = documentProcess.Header.Id }).ConfigureAwait(true);

            await documentProcess.DeleteInterpsByQuery(new InterpViewQuery { SourceHeaderId = documentProcess.Header.Id }).ConfigureAwait(true);

            await documentProcess.DeleteElementsByQuery(new ElementQuery { headerId = documentProcess.Header.Id }).ConfigureAwait(true);

            await documentProcess.DeleteChunksByQuery(new ChunkQuery { HeaderId = documentProcess.Header.Id }).ConfigureAwait(true);

            await documentProcess.DeleteIndecesByQuery(new IndexQuery { HeaderId = documentProcess.Header.Id }).ConfigureAwait(true);

            await documentProcess.DeleteHeader(header);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {
                HeaderSelected?.Invoke(this, header);
            }
        }
    }
}
