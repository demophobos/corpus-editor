using Common.Process;
using Document;
using Process;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Editor
{
    public partial class MainForm : Form
    {
        private ProjectExplorer _projectExplorer;

        private List<DocumentContainer> _openedDocuments = new List<DocumentContainer>();

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

                LoadItems();
            }
        }
        private bool Login()
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
            }

            _projectExplorer.LoadData();

            _projectExplorer.Show(dockPanel1, DockState.DockLeft);
        }

        private void ProjectExplorer_HeaderDeleted(object sender, Model.HeaderModel e)
        {
            throw new NotImplementedException();
        }

        private void ProjectExplorer_HeaderUpdated(object sender, Model.HeaderModel e)
        {
            throw new NotImplementedException();
        }

        private void ProjectExplorer_HeaderAdded(object sender, Model.HeaderModel e)
        {
            throw new NotImplementedException();
        }

        private void ProjectExplorer_HeaderSelected(object sender, Model.HeaderModel header)
        {
            var exsitingDocument = _openedDocuments.FirstOrDefault(i => i.DocumentProcess.Header.Id == header.Id);

            if (exsitingDocument != null)
            {
                exsitingDocument.Show();
            }
            else
            {
                var documentForm = new DocumentContainer(header);

                documentForm.Show(dockPanel1, DockState.Document);

                _openedDocuments.Add(documentForm);
            }
        }
    }
}
