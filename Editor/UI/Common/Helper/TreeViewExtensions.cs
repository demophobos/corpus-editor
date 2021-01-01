using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Common.Helper
{
    public static class TreeViewExtensions
    {
        public static List<string> GetExpansionState(this TreeNodeCollection nodes)
        {
            return nodes.Descendants()
                        .Where(n => n.IsExpanded)
                        .Select(n => n.FullPath)
                        .ToList();
        }

        public static void SetExpansionState(this TreeNodeCollection nodes, List<string> savedExpansionState)
        {
            foreach (var node in nodes.Descendants()
                                      .Where(n => savedExpansionState.Contains(n.FullPath)))
            {
                node.Expand();
            }
        }

        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

        public static List<TreeNode> Ancestors(this TreeNode node)
        {
            return AncestorsInternal(node).Reverse().ToList();
        }
        public static List<TreeNode> AncestorsAndSelf(this TreeNode node)
        {
            return AncestorsInternal(node, true).Reverse().ToList();
        }
        private static IEnumerable<TreeNode> AncestorsInternal(TreeNode node, bool self = false)
        {
            if (self)
                yield return node;
            while (node.Parent != null)
            {
                node = node.Parent;
                yield return node;
            }
        }
    }
}
