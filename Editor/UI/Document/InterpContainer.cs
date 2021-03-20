using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Process;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<InterpViewModel> Interpretations { get; private set; }

        public List<InterpViewModel> Originals { get; private set; }

        public InterpContainer(DocumentProcess documentProcess, IndexModel index)
        {
            _index = index;

            _documentProcess = documentProcess;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;

            Text = _documentProcess.Header.EditionType == EditionTypeStringEnum.Original ? "Переводы" : "Оригинал";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new InterpSelector(_documentProcess, _index, _chunk);

            var yesResult = dialog.ShowDialog() == DialogResult.Yes;

            if (yesResult)
            {
                await LoadData(_chunk).ConfigureAwait(true);
            }
        }

        public async Task LoadData(ChunkModel chunk)
        {
            _chunk = chunk;

            btnAdd.Enabled = true;

            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {

                Interpretations = await _documentProcess.GetInterpsByQueryView(new InterpViewQuery { SourceId = _chunk.Id }).ConfigureAwait(true);

                foreach (var interp in Interpretations)
                {
                    var viewer = new InterpViewer(_documentProcess, interp, EditionTypeEnum.Interpretation);

                    viewer.InterpDeleted += Viewer_InterpDeleted;

                    viewer.Show(dockPanel1, DockState.Document);
                }
            }
            else
            {

                Originals = await _documentProcess.GetInterpsByQueryView(new InterpViewQuery { InterpId = _chunk.Id }).ConfigureAwait(true);

                var original = Originals.FirstOrDefault();

                if (original != null)
                {
                    var viewer = new InterpViewer(_documentProcess, original, EditionTypeEnum.Original);

                    viewer.InterpDeleted += Viewer_InterpDeleted;

                    viewer.Show(dockPanel1, DockState.Document);

                    toolStrip2.Visible = false;
                }
                else
                {
                    toolStrip2.Visible = true;
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

            toolStrip2.Visible = true;
        }

        internal async Task CreateLinkAndLoadOriginal(ChunkModel chunk)
        {
            var headers = await HeaderProcess.GetHeaders(_documentProcess.Header.ProjectId).ConfigureAwait(true);

            var originalHeader = headers.FirstOrDefault(i => i.EditionType == EditionTypeStringEnum.Original);

            var originalChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { HeaderId = originalHeader.Id, IndexName = _index.Name }).ConfigureAwait(true);

            if (originalChunk != null)
            {
                var interp = new InterpModel
                {
                    SourceId = originalChunk.Id,

                    InterpId = chunk.Id,

                    InterpHeaderId = chunk.HeaderId,

                    SourceHeaderId = originalChunk.HeaderId
                };

                await _documentProcess.SaveInterp(interp).ConfigureAwait(true);
            }

            await LoadData(chunk).ConfigureAwait(true);
        }
    }
}
