using Common.Process;
using Model;
using Process;
using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Project
{
    public partial class ProjectExplorer : DockContent
    {
        public event EventHandler<HeaderModel> HeaderDeleted;
        public event EventHandler<HeaderModel> HeaderSelected;
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

            var projects = await ProjectProcess.GetProjects();

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
            mnuCreateHeader.Visible = btnEdit.Enabled = btnDelete.Enabled = treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Model.ProjectModel;

            mnuDeleteHeader.Visible = mnuEditHeader.Visible = treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Model.HeaderModel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new ProjectEditor(new Model.ProjectModel { });

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Model.ProjectModel project)
            {
                var dialog = new ProjectEditor(project);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    treeView1.SelectedNode = CreateNode(project);
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
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void mnuCreateHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Model.ProjectModel project)
            {
                var editor = new HeaderEditor(new HeaderModel { ProjectId = project.Id });

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void mnuEditHeader_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Model.HeaderModel header)
            {
                var editor = new HeaderEditor(header);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
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
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is HeaderModel header)
            {
                HeaderSelected.Invoke(this, header);
            }
        }
    }
}
