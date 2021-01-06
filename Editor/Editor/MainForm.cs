using Common.Process;
using Document;
using Model;
using Morph;
using Process;
using Project;
using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Editor
{
    public partial class MainForm : Form
    {
        private ProjectExplorer _projectExplorer;

        private MorphExplorer _morphExplorer;

        public MainForm()
        {
            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                Text = $"Editor [{AuthProcess.User.Email }]";

                btnShowMorphExplorer.Visible = true;

                LoadItems();
            }
        }
        public bool Login()
        {
            var loginForm = new LoginForm();

            return loginForm.ShowDialog() == DialogResult.OK;
        }

        private void LoadItems()
        {
            if (_projectExplorer == null || _projectExplorer.IsDisposed)
            {
                _projectExplorer = new ProjectExplorer();

                _projectExplorer.HeaderSelected += ProjectExplorer_HeaderSelected;

                _projectExplorer.HeaderAdded += ProjectExplorer_HeaderAdded;

                _projectExplorer.HeaderUpdated += ProjectExplorer_HeaderUpdated;

                _projectExplorer.HeaderDeleted += ProjectExplorer_HeaderDeleted;

                _projectExplorer.ProjectDeleted += ProjectExplorer_ProjectDeleted;
            }

            _projectExplorer.LoadData();

            _projectExplorer.Show(dockPanel1, DockState.DockLeftAutoHide);
        }

        private void ProjectExplorer_ProjectDeleted(object sender, ProjectModel project)
        {
            var docs = dockPanel1.DocumentsToArray();

            var deletedDocuments = docs.Where(i => ((DocumentContainer)i).DocumentProcess.Header.ProjectId == project.Id).Select(i => i as DocumentContainer);

            foreach (var deleted in deletedDocuments)
            {
                foreach (Control ctrl in deleted.Controls)
                {
                    ctrl.Dispose();
                }

                deleted.Close();

                docs.ToList().Remove(deleted);
            }
        }

        private void ProjectExplorer_HeaderDeleted(object sender, HeaderModel header)
        {
            var docs = dockPanel1.DocumentsToArray();

            var deleted = docs.FirstOrDefault(i => ((DocumentContainer)i).DocumentProcess.Header.Id == header.Id) as DocumentContainer;

            foreach (Control ctrl in deleted.Controls)
            {
                ctrl.Dispose();
            }

            deleted.Close();

            docs.ToList().Remove(deleted);
        }

        private void ProjectExplorer_HeaderUpdated(object sender, HeaderModel e)
        {
            //throw new NotImplementedException();
        }

        private void ProjectExplorer_HeaderAdded(object sender, HeaderModel e)
        {
            //throw new NotImplementedException();
        }

        private void ProjectExplorer_HeaderSelected(object sender, HeaderModel header)
        {
            var docs = dockPanel1.DocumentsToArray();

            var exsitingDocument = docs.FirstOrDefault(i => ((DocumentContainer)i).DocumentProcess.Header.Id == header.Id) as DocumentContainer;

            if (exsitingDocument != null)
            {
                exsitingDocument.Show();
            }
            else
            {
                var documentForm = new DocumentContainer(header);

                documentForm.Show(dockPanel1, DockState.Document);

                //_openedDocuments.Add(documentForm);
            }
        }

        private void btnShowMorphExplorer_Click(object sender, EventArgs e)
        {
            _morphExplorer = new MorphExplorer();

            _morphExplorer.Show(dockPanel1, DockState.Document);
        }
    }
}
