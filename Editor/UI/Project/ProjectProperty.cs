using WeifenLuo.WinFormsUI.Docking;

namespace Project
{
    public partial class ProjectProperty : DockContent
    {
        public ProjectProperty()
        {
            InitializeComponent();
        }

        public void LoadData(object obj)
        {
            propertyGrid1.SelectedObject = obj;
        }
    }
}
