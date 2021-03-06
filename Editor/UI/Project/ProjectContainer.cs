using Common.Control;
using Common.Process;
using Model;
using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Project
{
    public partial class ProjectContainer : DockContent
    {
        private ProjectExplorer _projectExplorer;

        private PropertyViewer _propertyViewer;

        public event EventHandler<HeaderModel> HeaderSelected;

        public event EventHandler<HeaderModel> HeaderDeleted;

        public event EventHandler<ProjectModel> ProjectDeleted;

        public ProjectContainer()
        {
            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        public void LoadItems()
        {
            _projectExplorer = new ProjectExplorer();

            _projectExplorer.HeaderSelected += _projectExplorer_HeaderSelected;

            _projectExplorer.HeaderDeleted += _projectExplorer_HeaderDeleted;

            _projectExplorer.HeaderUpdated += _projectExplorer_HeaderUpdated;

            _projectExplorer.ProjectUpdated += _projectExplorer_ProjectUpdated;

            _projectExplorer.ProjectDeleted += _projectExplorer_ProjectDeleted;

            _projectExplorer.HeaderViewProperty += _projectExplorer_HeaderViewProperty;

            _projectExplorer.ProjectViewProperty += _projectExplorer_ProjectViewProperty;

            _projectExplorer.LoadData();

            _projectExplorer.Show(dockPanel1, DockState.Document);

            _propertyViewer = new PropertyViewer();

            _propertyViewer.Show(dockPanel1, DockState.DockBottomAutoHide);
        }

        private void _projectExplorer_ProjectUpdated(object sender, ProjectModel e)
        {
            _propertyViewer.LoadData(e);
        }

        private void _projectExplorer_HeaderUpdated(object sender, HeaderModel e)
        {
            _propertyViewer.LoadData(e);
        }

        private void _projectExplorer_ProjectViewProperty(object sender, ProjectModel e)
        {
            _propertyViewer.LoadData(e);
        }

        private void _projectExplorer_HeaderViewProperty(object sender, HeaderModel e)
        {
            _propertyViewer.LoadData(e);
        }

        private void _projectExplorer_ProjectDeleted(object sender, ProjectModel e)
        {
            ProjectDeleted.Invoke(this, e);
        }

        private void _projectExplorer_HeaderDeleted(object sender, HeaderModel e)
        {
            HeaderDeleted.Invoke(this, e);
        }

        private void _projectExplorer_HeaderSelected(object sender, HeaderModel e)
        {
            HeaderSelected.Invoke(this, e);
        }
    }
}
