using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
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
    public partial class InterpContainer : DockContent
    {
        private IndexModel _index;

        private ChunkModel _chunk;

        private DocumentProcess _documentProcess;

        public InterpContainer(DocumentProcess documentProcess, IndexModel index, ChunkModel chunk)
        {
            _index = index;

            _chunk = chunk;

            _documentProcess = documentProcess;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new InterpSelector(_documentProcess, _index, _chunk);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await LoadData().ConfigureAwait(true);
            }
        }

        private async void InterpContainer_Load(object sender, EventArgs e)
        {
            await LoadData().ConfigureAwait(true);
        }

        private async Task LoadData()
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                var interps = await _documentProcess.GetInterpsByQuery(new InterpQuery { sourceId = _chunk.Id }).ConfigureAwait(true);

                foreach (var interp in interps)
                {
                    var viewer = new InterpViewer(_documentProcess, interp, EditionTypeEnum.Interpretation);

                    viewer.InterpDeleted += Viewer_InterpDeleted;

                    viewer.Show(dockPanel1, DockState.Document);
                }
            }
            else
            {
                var origs = await _documentProcess.GetInterpsByQuery(new InterpQuery { interpId = _chunk.Id }).ConfigureAwait(true);

                var original = origs.FirstOrDefault();

                if (original != null)
                {
                    var viewer = new InterpViewer(_documentProcess, original, EditionTypeEnum.Original);

                    viewer.InterpDeleted += Viewer_InterpDeleted;

                    viewer.Show(dockPanel1, DockState.Document);
                }
            }
        }

        private void Viewer_InterpDeleted(object sender, InterpModel interp)
        {
            var docs = dockPanel1.DocumentsToArray();

            var deleted = docs.FirstOrDefault(i => ((InterpViewer)i).Interp.Id == interp.Id) as InterpViewer;

            foreach (Control ctrl in deleted.Controls)
            {
                ctrl.Dispose();
            }

            deleted.Close();

            docs.ToList().Remove(deleted);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
