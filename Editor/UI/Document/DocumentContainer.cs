using Common.Process;
using Model;
using Model.Enum;
using Process;
using Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class DocumentContainer : DockContent
    {
        public DocumentProcess DocumentProcess { get; private set; }

        private ContentContainer _contentContainer;

        private List<ChunkContainer> _chunkContainers;

        private ChunkContainer _chunkContainer;

        public DocumentContainer(HeaderModel header)
        {
            DocumentProcess = new DocumentProcess(header);

            Text = header.Code;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void DocumentContainer_Load(object sender, EventArgs e)
        {
            _contentContainer = new ContentContainer(DocumentProcess);

            _contentContainer.IndexSelected += ContentExplorer_IndexSelected;

            _contentContainer.Show(dockPanel1, DockState.DockRight);

            _chunkContainers = new List<ChunkContainer>();
        }

        private void ContentExplorer_IndexSelected(object sender, IndexModel index)
        {
            if (DocumentProcess.Header.Id == index.HeaderId)
            {
                if (!(_chunkContainers.FirstOrDefault(p => p.Tag.ToString() == index.Id) is ChunkContainer existingControl))
                {
                    _chunkContainer = new ChunkContainer(index, DocumentProcess)
                    {
                        Tag = index.Id
                    };

                    _chunkContainers.Add(_chunkContainer);

                    _chunkContainer.FormClosed += ChunkContainer_FormClosed;

                    _chunkContainer.Show(dockPanel1, DockState.Document);
                }
                else
                {
                    existingControl.Activate();
                }
            }
        }

        private void ChunkContainer_FormClosed(object sender, FormClosedEventArgs e)
        {
            var ctrl = (ChunkContainer)sender;

            _chunkContainers.Remove(ctrl);

            ctrl.Dispose();
        }

        private void btnCloseAllChunks_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }
            _chunkContainers = new List<ChunkContainer>();
        }

        private async void btnReportChunkWithoutVersion_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkWithoutVersion).ConfigureAwait(true);
        }

        private async void btnReportChunkWithUndefinedWord_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkWithUndefinedWord).ConfigureAwait(true);
        }

        private async void btnReportChunkUnpublished_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkUnpublished).ConfigureAwait(true);
        }

        private async void btnReportReadinessStatistics_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ReadinessStatistics).ConfigureAwait(true);
        }

        private void btnReportFullText_Click(object sender, EventArgs e)
        {

        }
    }
}
