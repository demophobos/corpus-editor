using Model;
using Model.Property;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
