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
    public partial class ContentContainer : DockContent
    {
        DocumentProcess _documentProcess;

        public event EventHandler<IndexModel> IndexSelected;

        private ContentExplorer _contentExplorer;

        private ContentStatusExplorer _contentStatusExplorer;
        public ContentContainer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void ContentContainer_Load(object sender, EventArgs e)
        {
            _contentExplorer = new ContentExplorer(_documentProcess);

            _contentExplorer.Show(dockPanel1, DockState.Document);

            _contentExplorer.IndexSelected += _contentExplorer_IndexSelected;

            _contentStatusExplorer = new ContentStatusExplorer(_documentProcess);

            _contentStatusExplorer.ChunkSelected += _contentStatusExplorer_ChunkSelected;

            _contentStatusExplorer.Show(dockPanel1, DockState.Document);

            _contentExplorer.Activate();

        }

        private void _contentStatusExplorer_ChunkSelected(object sender, ChunkStatusModel e)
        {
            var index = _documentProcess.Indeces.FirstOrDefault(i => i.Id == e.IndexId);
            if (index != null) {
                IndexSelected?.Invoke(sender, index);
            }
            
        }

        private void _contentExplorer_IndexSelected(object sender, IndexModel e)
        {
            IndexSelected?.Invoke(this, e);
        }
    }
}
