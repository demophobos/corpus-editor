using Common.Process;
using Process;
using Project;
using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Editor
{
    public partial class MainForm : Form
    {
        private ProjectExplorer _projectExplorer;

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
            }

            _projectExplorer.LoadData();

            _projectExplorer.Show(dockPanel1, DockState.DockLeft);
        }
    }
}
