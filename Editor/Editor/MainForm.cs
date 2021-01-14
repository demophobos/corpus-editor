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

        private MorphExplorer _morphExplorer;

        private ProjectContainer _projectContainer;

        public MainForm()
        {
            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                foreach (IDockContent document in dockPanel1.DocumentsToArray())
                {
                    document.DockHandler.DockPanel = null;
                    document.DockHandler.Close();
                }

                Text = $"Editor [{AuthProcess.User.Email }]";

                btnShowMorphExplorer.Visible = true;

                LoadItems();
            }
        }

        private void LoadItems()
        {
            if (_projectContainer == null || _projectContainer.IsDisposed)
            {
                _projectContainer = new ProjectContainer();

                _projectContainer.HeaderDeleted += ProjectExplorer_HeaderDeleted;

                _projectContainer.ProjectDeleted += ProjectExplorer_ProjectDeleted;

                _projectContainer.HeaderSelected += ProjectExplorer_HeaderSelected;
            }

            _projectContainer.LoadItems();

            _projectContainer.Show(dockPanel1, DockState.DockLeftAutoHide);
        }

        public bool Login()
        {
            var loginForm = new LoginForm();

            return loginForm.ShowDialog() == DialogResult.OK;
        }

        private void btnShowMorphExplorer_Click(object sender, EventArgs e)
        {
            _morphExplorer = new MorphExplorer();

            _morphExplorer.Show(dockPanel1, DockState.Document);
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

            if (deleted != null)
            {
                foreach (Control ctrl in deleted.Controls)
                {
                    ctrl.Dispose();
                }

                deleted.Close();

                docs.ToList().Remove(deleted);
            }
        }

        private void ProjectExplorer_HeaderSelected(object sender, HeaderModel header)
        {
            var docs = dockPanel1.DocumentsToArray();

            var exsitingDocuments = docs.Where(i => i is DocumentContainer).ToList();

            if (exsitingDocuments.Count > 0)
            {
                if (exsitingDocuments.FirstOrDefault(i => ((DocumentContainer)i).DocumentProcess.Header.Id == header.Id) is DocumentContainer exsitingDocument)
                {
                    exsitingDocument.Show();
                }
                else
                {
                    OpenDocument(header);
                }

            }
            else
            {
                OpenDocument(header);
            }
        }

        private void OpenDocument(HeaderModel header)
        {
            var documentForm = new DocumentContainer(header);

            documentForm.Show(dockPanel1, DockState.Document);
        }
    }
}
