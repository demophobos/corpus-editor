using Model;
using Model.Property;
using Process;
using WeifenLuo.WinFormsUI.Docking;

namespace Project
{
    public partial class ProjectProperty : DockContent
    {
        public ProjectProperty()
        {
            InitializeComponent();
        }

        public void LoadData(object selectedObject)
        {
            switch (selectedObject)
            {
                case ProjectModel projecModel:
                    propertyGrid1.SelectedObject = new ProjectPropertyModel(projecModel, AuthProcess.User);
                    break;
                case HeaderModel headerModel:
                    propertyGrid1.SelectedObject = new HeaderPropertyModel(headerModel);
                    break;
            }
        }
    }
}
