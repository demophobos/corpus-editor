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

        private ContentIndexExplorer _contentIndexExplorer;

        private List<ChunkContainer> _chunkContainers;

        private ChunkContainer _chunkContainer;

        private ChunkListViewer _chunkListViewer;

        public DocumentContainer(HeaderModel header)
        {
            DocumentProcess = new DocumentProcess(header);

            Text = header.Code;

            InitializeComponent();

            dockPanel1.Theme = UIProcess.DockPanelTheme;
        }

        private void DocumentContainer_Load(object sender, EventArgs e)
        {
            _contentIndexExplorer = new ContentIndexExplorer(DocumentProcess);

            _contentIndexExplorer.IndexSelected += ContentIndexExplorer_IndexSelected;

            _contentIndexExplorer.IndexDeleted += ContentIndexExplorer_IndexDeleted;

            _contentIndexExplorer.StatusInfoShown += ContentIndexExplorer_StatusInfoShown;

            _contentIndexExplorer.Show(dockPanel1, DockState.DockRight);

            _chunkContainers = new List<ChunkContainer>();

            _chunkListViewer = new ChunkListViewer(DocumentProcess);
        }

        private void ContentIndexExplorer_StatusInfoShown(object sender, string e)
        {
            lblStatus.Text = e;
        }

        private void ContentIndexExplorer_IndexDeleted(object sender, IndexModel index)
        {
            var document = dockPanel1.DocumentsToArray()
                .FirstOrDefault(i => i is ChunkContainer chunkContainer && chunkContainer.Index.Id == index.Id);

            if (document != null)
            {
                document.DockHandler.DockPanel = null;

                document.DockHandler.Close();

                _chunkContainers.Remove(document as ChunkContainer);
            }
        }

        private void ContentIndexExplorer_IndexSelected(object sender, IndexModel index)
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

                    _chunkContainer.ChunkBulkMorphChanged += ChunkContainer_ChunkBulkMorphChanged;

                    _chunkContainer.StatusInfoShown += ChunkContainer_StatusInfoShown;

                    _chunkContainer.Show(dockPanel1, DockState.Document);
                }
                else
                {
                    existingControl.Activate();
                }
            }
        }

        private void ChunkContainer_StatusInfoShown(object sender, string e)
        {
            lblStatus.Text = e;
        }

        private void ChunkContainer_ChunkBulkMorphChanged(object sender, Tuple<List<ChunkModel>, ElementModel, ChunkEditAction> e)
        {
            _chunkListViewer.LoadData(e.Item1, e.Item2, e.Item3);

            if (_chunkListViewer.IsHidden)
            {
                _chunkListViewer.Show(_contentIndexExplorer.Pane, DockAlignment.Bottom, 0.5);
            }
        }

        private void ChunkContainer_FormClosed(object sender, FormClosedEventArgs e)
        {
            var ctrl = (ChunkContainer)sender;

            _chunkContainers.Remove(ctrl);

            ctrl.Dispose();
        }

        #region Menu Close
        private void mnuCloseAllWindows_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.DockPanel = null;

                document.DockHandler.Close();
            }

            _chunkContainers = new List<ChunkContainer>();
        }

        private void mnuCloseAllWindowsExceptActive_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray().Where(i => !i.DockHandler.IsActivated))
            {
                document.DockHandler.DockPanel = null;

                document.DockHandler.Close();

                if (document is ChunkContainer chunkContainer)
                {
                    _chunkContainers.Remove(chunkContainer);
                }
            }
        }
        #endregion

        #region Menu Report

        #region Menu Text Report
        private async void mnuTextReportText_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.Text).ConfigureAwait(true);
        }

        private async void mnuTextReportParallelText_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ParallelText).ConfigureAwait(true);
        }

        private void mnuTextReportTextCommented_Click(object sender, EventArgs e)
        {

        }

        private void mnuTextReportParallelTextCommented_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Menu Chunk Report
        private async void mnuChunkReportIndexWithEmptyText_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.IndexWithEmptyText).ConfigureAwait(true);
        }

        private async void mnuChunkReportChunkWithoutParallelText_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkWithoutParallelText).ConfigureAwait(true);
        }

        private async void mnuChunkReportChunkWithUndefinedWord_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkWithUndefinedWord).ConfigureAwait(true);
        }

        private async void mnuChunkReportUnpublished_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ChunkUnpublished).ConfigureAwait(true);
        }

        #endregion

        #region Menu Word Report
        private void mnuWordReportUndefinedWord_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Menu Stat Report
        private async void mnuStatReportReadinessStatistics_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.ReadinessStatistics).ConfigureAwait(true);
        }

        private async void mnuStatPosReport_Click(object sender, EventArgs e)
        {
            var reportViewer = new ReportBrowser(DocumentProcess);

            reportViewer.Show(dockPanel1, DockState.Document);

            await reportViewer.GetReport(ReportTypeEnum.PosStatistics).ConfigureAwait(true);
        }




        #endregion

        #endregion
    }
}
