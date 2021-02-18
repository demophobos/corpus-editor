using Common.Process;
using Model;
using Model.Query;
using Model.View;
using Process;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ContentExplorer : DockContent
    {
        public event EventHandler<IndexModel> IndexSelected;

        public event EventHandler<IndexModel> IndexPreviewSelected;

        private DocumentProcess _documentProcess;

        private List<IndexModel> _indeces;

        private List<IndexModel> _bookmarkedIndeces = new List<IndexModel>();

        public ContentExplorer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        private async void ContentExplorer_LoadAsync(object sender, EventArgs e)
        {
            treeView1.ContextMenuStrip = contextMenuStrip1;

            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            loader1.BringToFront();

            treeView1.BeginUpdate();

            treeView1.Nodes.Clear();

            _indeces = await _documentProcess.GetIndecesByHeader().ConfigureAwait(true);

            _bookmarkedIndeces = _indeces.Where(i => i.Bookmarked == true).ToList();

            ShowBookmarkTools();

            bookmarkedSource.DataSource = _bookmarkedIndeces;

            var roots = _indeces.Where(i => string.IsNullOrEmpty(i.ParentId)).OrderBy(i => i.Order).ToList();

            foreach (var root in roots)
            {
                TreeNode rootNode = CreateNode(root);

                PopulateTree(rootNode, _indeces);

                treeView1.Nodes.Add(rootNode);
            }

            treeView1.EndUpdate();

            loader1.SendToBack();
        }

        private void ShowBookmarkTools()
        {
            var count = _bookmarkedIndeces.Count();

            btnShowBookmarks.Text = count.ToString();

            btnShowBookmarks.Enabled = btnRemoveAllBookmarks.Enabled = count > 0;
        }

        private static TreeNode CreateNode(IndexModel index)
        {
            return new TreeNode
            {
                Name = index.Id.ToString(),
                Text = index.Name,
                Tag = index,
                ImageIndex = index.Bookmarked ? 1 : 0,
                SelectedImageIndex = index.Bookmarked ? 1 : 0
            };
        }

        private void PopulateTree(TreeNode root, List<IndexModel> indices)
        {
            var children = indices.Where(t => t.ParentId == ((IndexModel)root.Tag).Id).OrderBy(i => i.Order);

            foreach (var child in children)
            {
                var n = CreateNode(child);

                PopulateTree(n, indices);

                root.Nodes.Add(n);
            }
        }

        private async void btnAddFirstLevelSection_ClickAsync(object sender, EventArgs e)
        {
            IndexEditor indexEditor;

            var index = new IndexModel { Order = treeView1.Nodes.Count + 1, HeaderId = _documentProcess.Header.Id };

            indexEditor = new IndexEditor(_documentProcess, index);

            if (indexEditor.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync().ConfigureAwait(true);

                treeView1.SelectedNode = treeView1.Nodes.Find(index.Id, false).FirstOrDefault();
            }
        }

        private async void btnAddSubsection_ClickAsync(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel parentIndex)
            {
                IndexEditor indexEditor;

                var index = new IndexModel
                {
                    HeaderId = _documentProcess.Header.Id,
                    Order = treeView1.SelectedNode.Nodes.Count + 1,
                    ParentId = parentIndex.Id
                };

                indexEditor = new IndexEditor(_documentProcess, index, parentIndex.Name);

                if (indexEditor.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync().ConfigureAwait(true);
                }

                var pn = treeView1.Nodes.Find(index.ParentId, true).FirstOrDefault();

                if (pn.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = pn.Nodes[pn.Nodes.Count - 1];
                }
            }
        }

        private void btnEditSection_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel index)
            {
                var indexEditor = new IndexEditor(_documentProcess, index);

                if (indexEditor.ShowDialog() == DialogResult.OK)
                {
                    var node = treeView1.Nodes.Find(index.Id, true).FirstOrDefault();

                    if (node != null)
                    {
                        treeView1.SelectedNode = node;
                    }
                }
            }
        }

        private async void BtnRemoveSection_ClickAsync(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is IndexModel index)
            {
                if (DialogProcess.DeleteWarning(index) == DialogResult.Yes)
                {
                    await Delete(index);

                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                }
            }
        }

        private async Task Delete(IndexModel index)
        {
            var children = _indeces.Where(i => i.ParentId == index.Id);

            if (children.Count() > 0)
            {
                foreach (var child in children)
                {
                    await _documentProcess.DeleteIndex(index).ConfigureAwait(true);

                    await Delete(child).ConfigureAwait(true);
                }
            }

            await _documentProcess.DeleteIndex(index).ConfigureAwait(true);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnAddSubsection.Visible = e.Node != null;

            if (e.Action == TreeViewAction.ByKeyboard &&
                (e.Action != TreeViewAction.Collapse ||
                e.Action != TreeViewAction.Expand) &&
                e.Node.Tag is IndexModel index)
            {
                IndexPreviewSelected.Invoke(this, index);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is IndexModel index)
            {
                IndexPreviewSelected.Invoke(this, index);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is IndexModel index)
            {
                IndexSelected.Invoke(this, index);
            }
        }

        private void btnOpenEditor_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel index)
            {
                IndexSelected.Invoke(this, index);
            }
        }

        private async void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var chunks = await _documentProcess.LoadJsonChunks(fileDialog.FileName).ConfigureAwait(true);

                MessageBox.Show($"Импортировано фрагментов: {chunks.Count}");
            }
        }

        private async void btnUpdateHeaderId_Click(object sender, EventArgs e)
        {
            loader1.BringToFront();

            int count = 0;

            var chunks = await ChunkProcess.GetChunksByQuery(new ChunkQuery { headerId = _documentProcess.Header.Id }).ConfigureAwait(true);

            foreach (var chunkView in chunks)
            {
                var chunk = new ChunkModel { HeaderId = _documentProcess.Header.Id, Id = chunkView.Id, IndexId = chunkView.IndexId, Value = chunkView.Value };

                await ChunkProcess.SaveChunkAndElements(chunk).ConfigureAwait(true);

                count += 1;

                loader1.SetStatus(count.ToString());
            }

            var interps = await _documentProcess.GetInterpsByQuery(new Model.Query.InterpQuery { interpHeaderId = _documentProcess.Header.Id }).ConfigureAwait(true);

            foreach (var interpView in interps)
            {
                var interp = new InterpModel
                {
                    InterpHeaderId = interpView.InterpHeaderId,
                    Id = interpView.Id,
                    SourceHeaderId = interpView.SourceHeaderId,
                    InterpId = interpView.InterpId,
                    SourceId = interpView.SourceId
                };

                await _documentProcess.SaveInterp(interp).ConfigureAwait(true);

                count += 1;

                loader1.SetStatus(count.ToString());
            }

            var sources = await _documentProcess.GetInterpsByQuery(new Model.Query.InterpQuery { sourceHeaderId = _documentProcess.Header.Id }).ConfigureAwait(true);

            foreach (var interpView in sources)
            {
                var interp = new InterpModel
                {
                    InterpHeaderId = interpView.InterpHeaderId,
                    Id = interpView.Id,
                    SourceHeaderId = interpView.SourceHeaderId,
                    InterpId = interpView.InterpId,
                    SourceId = interpView.SourceId
                };

                await _documentProcess.SaveInterp(interp).ConfigureAwait(true);

                count += 1;

                loader1.SetStatus(count.ToString());
            }

            loader1.SendToBack();
        }

        private async void btnUpdateChunkValueObj_Click(object sender, EventArgs e)
        {
            var updatedChunks = new List<ChunkViewModel>();

            loader1.BringToFront();

            loader1.SetStatus("Обновление фрагментов");

            btnUpdateChunkValueObj.Enabled = btnAddFirstLevelSection.Enabled = false;

            var chunks = await ChunkProcess.GetChunksByQuery(new ChunkQuery { headerId = _documentProcess.Header.Id });

            int updatedCount = 0;

            int count = 0;

            foreach (var chunkView in chunks)
            {
                var chunk = new ChunkModel { Id = chunkView.Id, HeaderId = chunkView.HeaderId, IndexId = chunkView.IndexId, Value = chunkView.Value, ValueObj = chunkView.ValueObj };

                var elements = await ElementProcess.GetElements(new ElementQuery { chunkId = chunk.Id }).ConfigureAwait(true);

                var newValueObj = await ChunkProcess.CreateChunkValueObjs(elements).ConfigureAwait(true);

                var published = await ChunkProcess.PublishChunkValueObj(chunk, newValueObj).ConfigureAwait(true);

                if (published != null)
                {
                    updatedCount += 1;
                    updatedChunks.Add(chunkView);
                }

                count += 1;

                loader1.SetStatus($"Обновлено фрагментов: {updatedCount} из {chunks.Count}. Обработано: {count}");
            }

            MessageBox.Show($"Обновлено фрагментов: {updatedCount} из {chunks.Count}: {string.Join(", ", updatedChunks.Select(i => i.IndexName))}");

            loader1.SendToBack();

            btnUpdateChunkValueObj.Enabled = btnAddFirstLevelSection.Enabled = true;
        }

        private void btnShowBookmarks_Click(object sender, EventArgs e)
        {
            if (bookmarkedSource.Position == bookmarkedSource.Count - 1)
            {
                bookmarkedSource.MoveFirst();
                bookmarkedSource.Position = 0;
            }
            else {
                bookmarkedSource.MoveNext();
            }
            ShowBookmarked();
        }

        private async void btnRemoveAllBookmarks_Click(object sender, EventArgs e)
        {
            loader1.BringToFront();

            loader1.SetStatus("Удаление закладок");

            foreach (var index in _bookmarkedIndeces) {

                index.Bookmarked = false;

                await _documentProcess.SaveIndex(index).ConfigureAwait(true);
            }

            await LoadDataAsync();
        }

        private async void btnSetBookmark_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel index)
            {
                index.Bookmarked = true;

                await _documentProcess.SaveIndex(index).ConfigureAwait(true);

                treeView1.SelectedNode.ImageIndex = treeView1.SelectedNode.SelectedImageIndex = 1;

                _bookmarkedIndeces.Add(index);

                bookmarkedSource.DataSource = _bookmarkedIndeces;

                bookmarkedSource.ResetBindings(false);

                ShowBookmarkTools();
            }
        }

        private async void btnRemoveBookmark_ClickAsync(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel index)
            {
                index.Bookmarked = false;

                await _documentProcess.SaveIndex(index).ConfigureAwait(true);

                treeView1.SelectedNode.ImageIndex = treeView1.SelectedNode.SelectedImageIndex = 0;

                _bookmarkedIndeces.Remove(index);

                bookmarkedSource.DataSource = _bookmarkedIndeces;

                bookmarkedSource.ResetBindings(false);

                ShowBookmarkTools();
            }
        }

        private void bookmarkedSource_PositionChanged(object sender, EventArgs e)
        {
            ShowBookmarked();
        }

        private void ShowBookmarked()
        {
            if (bookmarkedSource.Current != null && bookmarkedSource.Current is IndexModel index)
            {
                var found = treeView1.Nodes.Find(index.Id, true).FirstOrDefault();

                if (found != null)
                {
                    treeView1.SelectedNode = found;

                    IndexPreviewSelected.Invoke(this, index);
                }
            }
        }
    }
}

