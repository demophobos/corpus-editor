using Model;
using Model.Enum;
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
            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                var interps = await _documentProcess.GetInterpsBySource(_chunk.Id).ConfigureAwait(true);

                foreach (var interp in interps)
                {
                    var viewer = new InterpViewer(interp, EditionTypeEnum.Interpretation);

                    viewer.Show(dockPanel1, DockState.Document);
                }
            }
            else
            {
                var origs = await _documentProcess.GetInterpsByInterp(_chunk.Id).ConfigureAwait(true);

                var original = origs.FirstOrDefault();

                var viewer = new InterpViewer(original, EditionTypeEnum.Original);

                viewer.Show(dockPanel1, DockState.Document);
            }
        }
    }
}
