using Common.Process;
using Model;
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

            _indeces = await _documentProcess.GetIndecesByHeader();

            var roots = _indeces.Where(i => string.IsNullOrEmpty(i.ParentId)).ToList();

            foreach (var root in roots)
            {

                var rootNode = new TreeNode
                {
                    Name = root.Id.ToString(),
                    Text = root.Name,
                    Tag = root
                };

                PopulateTree(rootNode, _indeces);

                treeView1.Nodes.Add(rootNode);
            }

            treeView1.EndUpdate();

            loader1.SendToBack();
        }

        private void PopulateTree(TreeNode root, List<IndexModel> indices)
        {
            var children = indices.Where(t => t.ParentId == ((IndexModel)root.Tag).Id);

            foreach (var child in children)
            {
                var n = new TreeNode()
                {
                    Name = child.Id,
                    Text = child.Name,
                    Tag = child
                };

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
    }
}

