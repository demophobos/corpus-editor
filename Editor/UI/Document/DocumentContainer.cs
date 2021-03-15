﻿using Common.Process;
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

            _contentIndexExplorer.IndexSelected += ContentExplorer_IndexSelected;

            _contentIndexExplorer.Show(dockPanel1, DockState.DockRight);

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

        private void mnuCloseAllWindows_Click(object sender, EventArgs e)
        {
            foreach (IDockContent document in dockPanel1.DocumentsToArray())
            {
                document.DockHandler.DockPanel = null;
                document.DockHandler.Close();
            }
            _chunkContainers = new List<ChunkContainer>();
        }

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
        private async void mnuChunkReportChunkWithoutVersion_Click(object sender, EventArgs e)
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
        #endregion 
        #endregion
    }
}
