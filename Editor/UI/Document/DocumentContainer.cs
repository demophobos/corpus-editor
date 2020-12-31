using Common.Process;
using Model;
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

namespace Document
{
    public partial class DocumentContainer : DockContent
    {
        public DocumentProcess DocumentProcess { get; private set; }

        private ContentExplorer _contentExplorer;
        public DocumentContainer(HeaderModel header)
        {
            DocumentProcess = new DocumentProcess(header);

            Text = header.Code;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void DocumentContainer_Load(object sender, EventArgs e)
        {
            _contentExplorer = new ContentExplorer(DocumentProcess);

            _contentExplorer.Show(dockPanel1, DockState.DockRight);
        }
    }
}
