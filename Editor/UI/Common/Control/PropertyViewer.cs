using Model;
using Model.Property;
using Process;
using WeifenLuo.WinFormsUI.Docking;

namespace Common.Control
{
    public partial class PropertyViewer : DockContent
    {
        public PropertyViewer()
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
