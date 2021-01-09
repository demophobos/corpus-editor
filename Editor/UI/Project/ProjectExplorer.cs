using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Linq;
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

        public async void LoadData()
        {

            treeView1.BeginUpdate();

            loader1.BringToFront();

            var query = new ProjectQuery();

            var projects = await ProjectProcess.GetProjects(query).ConfigureAwait(true);

            var notDeletedProjects = projects.Where(i => i.Status != ProjectStatusStringEnum.Deleted);

            treeView1.Nodes.Clear();

            foreach (var project in projects)
            {
                TreeNode projectNode = CreateNode(project);

                var headers = await HeaderProcess.GetHeaders(project.Id);

                foreach (var header in headers)
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
            int imageIndex = project.Status == ProjectStatusStringEnum.Published ? 0 : 2;

            return new TreeNode
            {
                Name = project.Id,
                Text = $"{project.Code} [{project.Desc}]",
                ImageIndex = imageIndex,
                SelectedImageIndex = imageIndex,
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
                mnuCreateHeader.Visible = btnEdit.Enabled = true;

                btnPublish.Visible = project.Status != ProjectStatusStringEnum.Published;

                btnUnpublish.Visible = project.Status == ProjectStatusStringEnum.Published;

                ProjectViewProperty?.Invoke(this, project);
            }
            else
            {
                mnuCreateHeader.Visible = btnEdit.Enabled = btnPublish.Visible = btnUnpublish.Visible = false;
            }

            mnuDeleteHeader.Visible = mnuEditHeader.Visible = treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel;

            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {

                HeaderViewProperty?.Invoke(this, header);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new ProjectEditor(new ProjectModel());

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData();
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
                await ProjectProcess.RemoveProject(project).ConfigureAwait(true);

                var node = treeView1.Nodes.Find(treeView1.SelectedNode.Name, true).FirstOrDefault();

                if (node != null)
                {
                    treeView1.BeginUpdate();

                    treeView1.Nodes.Remove(node);

                    treeView1.EndUpdate();

                    mnuCreateHeader.Visible = btnEdit.Enabled = btnDelete.Enabled = treeView1.Nodes.Count != 0;

                    ProjectDeleted?.Invoke(this, project);
                }
            }
        }

        private void mnuCreateHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                var header = new HeaderModel { ProjectId = project.Id };

                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadData();

                    HeaderAdded?.Invoke(this, header);
                }
            }
        }

        private void mnuEditHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {
                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadData();

                    HeaderUpdated?.Invoke(this, header);
                }
            }
        }

        private async void mnuDeleteHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header && DialogProcess.DeleteWarning(header) == DialogResult.Yes)
            {
                await HeaderProcess.RemoveHeader(header).ConfigureAwait(true);

                var node = treeView1.Nodes.Find(treeView1.SelectedNode.Name, true).FirstOrDefault();

                if (node != null)
                {
                    treeView1.BeginUpdate();

                    treeView1.Nodes.Remove(node);

                    treeView1.EndUpdate();

                    HeaderDeleted?.Invoke(this, header);
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {
                HeaderSelected?.Invoke(this, header);
            }
        }

        private async void btnPublish_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                project.Status = ProjectStatusStringEnum.Published;

                var savedProject = await ProjectProcess.Save(project).ConfigureAwait(true);

                var headers = await HeaderProcess.GetHeaders(project.Id).ConfigureAwait(true);

                if (savedProject.Status == ProjectStatusStringEnum.Published)
                {
                    treeView1.SelectedNode.ImageIndex = treeView1.SelectedNode.SelectedImageIndex = 0;

                    btnUnpublish.Visible = true;

                    btnPublish.Visible = false;

                    foreach (var header in headers)
                    {
                        header.Status = savedProject.Status;
                        await HeaderProcess.SaveHeader(header).ConfigureAwait(true);
                    }
                }

                ProjectUpdated?.Invoke(this, project);
            }
        }

        private async void btnUnpublish_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is ProjectModel project)
            {
                project.Status = ProjectStatusStringEnum.Edited;

                var savedProject = await ProjectProcess.Save(project).ConfigureAwait(true);

                var headers = await HeaderProcess.GetHeaders(project.Id).ConfigureAwait(true);

                if (savedProject.Status == ProjectStatusStringEnum.Edited)
                {
                    treeView1.SelectedNode.ImageIndex = treeView1.SelectedNode.SelectedImageIndex = 2;

                    btnUnpublish.Visible = false;

                    btnPublish.Visible = true;

                    foreach (var header in headers)
                    {
                        header.Status = savedProject.Status;
                        await HeaderProcess.SaveHeader(header).ConfigureAwait(true);
                    }
                }

                ProjectUpdated?.Invoke(this, project);
            }
        }
    }
}
