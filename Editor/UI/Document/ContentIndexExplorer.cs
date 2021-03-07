﻿using Common.Process;
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
    public partial class ContentIndexExplorer : DockContent
    {
        public event EventHandler<IndexModel> IndexSelected;

        private DocumentProcess _documentProcess;

        private List<IndexModel> _bookmarkedIndeces = new List<IndexModel>();

        public ContentIndexExplorer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        private async void ContentExplorer_LoadAsync(object sender, EventArgs e)
        {
            await LoadDataAsync().ConfigureAwait(true);
        }

        private async Task LoadDataAsync()
        {
            loader1.BringToFront();

            loader1.SetStatus("Загрузка содержания...");

            treeView1.ContextMenuStrip = null;

            treeView1.BeginUpdate();

            treeView1.Nodes.Clear();

            _documentProcess.Indeces = await _documentProcess.GetIndecesByHeader().ConfigureAwait(true);

            _bookmarkedIndeces = _documentProcess.Indeces.Where(i => i.Bookmarked == true).ToList();

            ShowBookmarkTools();

            bookmarkedSource.DataSource = _bookmarkedIndeces;

            var roots = _documentProcess.Indeces.Where(i => string.IsNullOrEmpty(i.ParentId)).OrderBy(i => i.Order).ToList();

            foreach (var root in roots)
            {
                TreeNode rootNode = CreateNode(root);

                PopulateTree(rootNode, _documentProcess.Indeces);

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

        private async void btnCreateTopIndex_ClickAsync(object sender, EventArgs e)
        {
            var index = new IndexModel { Order = treeView1.Nodes.Count + 1, HeaderId = _documentProcess.Header.Id };

            var indexBuilder = new IndexBuilder(_documentProcess, index);

            if (indexBuilder.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync().ConfigureAwait(true);

                treeView1.SelectedNode = treeView1.Nodes.Find(index.Id, false).FirstOrDefault();
            }
        }

        private async void btnAddSubsection_ClickAsync(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel parentIndex)
            {
                var index = new IndexModel
                {
                    HeaderId = _documentProcess.Header.Id,
                    Order = treeView1.SelectedNode.Nodes.Count + 1,
                    ParentId = parentIndex.Id
                };

                var indexBuilder = new IndexBuilder(_documentProcess, index, parentIndex.Name);

                if (indexBuilder.ShowDialog() == DialogResult.OK)
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
                var indexNameEditor = new IndexNameEditor(_documentProcess, index);

                if (indexNameEditor.ShowDialog() == DialogResult.OK)
                {
                    var node = treeView1.Nodes.Find(index.Id, true).FirstOrDefault();

                    if (node != null)
                    {
                        node.Text = index.Name;

                        treeView1.SelectedNode = node;
                    }
                }
            }
        }

        private async void BtnRemoveSection_ClickAsync(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel index)
            {
                if (DialogProcess.DeleteWarning(index) == DialogResult.Yes)
                {
                    loader1.BringToFront();

                    loader1.SetStatus("Удаление...");

                    await Delete(index).ConfigureAwait(true);

                    await LoadDataAsync().ConfigureAwait(true);

                    loader1.SendToBack();
                }
            }
        }

        private async Task Delete(IndexModel index)
        {
            var children = _documentProcess.Indeces.Where(i => i.ParentId == index.Id);

            if (children.Count() > 0)
            {
                foreach (var child in children)
                {
                    await Delete(child).ConfigureAwait(true);
                }
            }

            await _documentProcess.DeleteIndex(index).ConfigureAwait(true);
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

        private void btnShowBookmarks_Click(object sender, EventArgs e)
        {
            if (bookmarkedSource.Position == bookmarkedSource.Count - 1)
            {
                bookmarkedSource.MoveFirst();
                bookmarkedSource.Position = 0;
            }
            else
            {
                bookmarkedSource.MoveNext();
            }
            ShowBookmarked();
        }

        private async void btnRemoveAllBookmarks_Click(object sender, EventArgs e)
        {
            loader1.BringToFront();

            loader1.SetStatus("Удаление закладок");

            foreach (var index in _bookmarkedIndeces)
            {

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
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is IndexModel)
            {
                treeView1.ContextMenuStrip = contextMenuStrip1;
            }
            else
            {
                treeView1.ContextMenuStrip = null;
            }
        }
    }
}

