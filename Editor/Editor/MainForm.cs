using Auth;
using Common.Process;
using Document;
using Microsoft.Win32;
using Model;
using Morph;
using Process;
using Project;
using System;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Editor
{
    public partial class MainForm : Form
    {
        private MorphExplorer _morphExplorer;

        private ProjectExplorer _projectExplorer;

        public MainForm()
        {
            SetAddRemoveProgramsIcon();

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

                var version = Assembly.GetExecutingAssembly().GetName().Version;

                Text = $"CLR Editor ({version}) [{AuthProcess.User.Email}]";

                btnShowMorphExplorer.Visible = true;

                LoadItems();
            }
        }

        private void LoadItems()
        {
            _projectExplorer = new ProjectExplorer();

            _projectExplorer.HeaderSelected += ProjectExplorer_HeaderSelected;

            _projectExplorer.HeaderDeleted += ProjectExplorer_HeaderDeleted;

            _projectExplorer.HeaderUpdated += ProjectExplorer_HeaderUpdated;

            _projectExplorer.ProjectDeleted += ProjectExplorer_ProjectDeleted;

            _projectExplorer.LoadData();

            _projectExplorer.Show(dockPanel1, DockState.DockLeft);
        }

        private void ProjectExplorer_HeaderUpdated(object sender, HeaderModel header)
        {
            var docs = dockPanel1.DocumentsToArray();

            var exsitingDocuments = docs.Where(i => i is DocumentContainer).ToList();

            if (exsitingDocuments.Count > 0)
            {
                if (exsitingDocuments.FirstOrDefault(i => ((DocumentContainer)i).DocumentProcess.Header.Id == header.Id) is DocumentContainer exsitingDocument)
                {
                    exsitingDocument.Text = header.Code;
                }
            }
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

        private void SetAddRemoveProgramsIcon()
        {
            if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    var iconSourcePath = Path.Combine(Application.StartupPath, "icon.ico");

                    if (!File.Exists(iconSourcePath)) return;

                    var myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    if (myUninstallKey == null) return;

                    var mySubKeyNames = myUninstallKey.GetSubKeyNames();

                    foreach (var subkeyName in mySubKeyNames)
                    {
                        var myKey = myUninstallKey.OpenSubKey(subkeyName, true);
                        var myValue = myKey.GetValue("DisplayName");

                        // we have two versions 
                        if (myValue != null && myValue.ToString() == "CLR Editor") // same as in 'Product name:' field
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                        }
                        else
                        if (myValue != null && myValue.ToString() == "CLR Editor") // same as in 'Product name:' field
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                        }
                    }
                }
                catch (Exception exc)
                {
                    System.Diagnostics.Trace.WriteLine("SetAddRemoveProgramsIcon failed: " + exc.Message);
                }
            }
        }
    }
}
