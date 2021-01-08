using Common.Process;
using Model;
using Process;
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

        private ContentExplorer _contentExplorer;

        private List<ChunkContainer> _chunkContainers;

        private ChunkContainer _chunkContainer;

        private ChunkViewer _chunkViewer;

        private IndexModel _selectedIndex;
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

            _contentExplorer.IndexSelected += ContentExplorer_IndexSelected;

            _contentExplorer.IndexPreviewSelected += ContentExplorer_IndexPreviewSelected;

            _chunkContainers = new List<ChunkContainer>();

            _chunkViewer = new ChunkViewer(DocumentProcess);

            _chunkViewer.Show(_contentExplorer.Pane, DockAlignment.Bottom, 0.25);
        }

        private void ContentExplorer_IndexPreviewSelected(object sender, IndexModel index)
        {
            _selectedIndex = index;

            _chunkViewer.LoadData(_selectedIndex);
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

                    _chunkContainer.ChunkAdded += ChunkContainer_ChunkAdded;

                    _chunkContainer.ChunkDeleted += ChunkContainer_ChunkDeleted;

                    _chunkContainer.ChunkUpdated += ChunkContainer_ChunkUpdated;
                }
                else
                {
                    existingControl.Activate();
                }
            }
        }

        private void ChunkContainer_ChunkUpdated(object sender, ChunkModel chunk)
        {
            if (_selectedIndex != null && chunk.IndexId == _selectedIndex.Id)
            {
                _chunkViewer.LoadData(_selectedIndex);
            }
        }

        private void ChunkContainer_ChunkDeleted(object sender, ChunkModel chunk)
        {
            if (_selectedIndex != null && chunk.IndexId == _selectedIndex.Id)
            {
                _chunkViewer.LoadData(_selectedIndex);
            }
        }

        private void ChunkContainer_ChunkAdded(object sender, ChunkModel chunk)
        {
            if (_selectedIndex != null && chunk.IndexId == _selectedIndex.Id)
            {
                _chunkViewer.LoadData(_selectedIndex);
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
    }
}
