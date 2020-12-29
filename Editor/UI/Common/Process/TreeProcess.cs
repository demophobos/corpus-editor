using System.Windows.Forms;

namespace Common.Process
{
    public class TreeProcess
    {
        public static TreeNode CreateNode(string text, string name, string imageKey, object tag)
        {
            return new TreeNode()
            {
                Text = text,
                Tag = tag,
                Name = name,
                ImageKey = imageKey,
                SelectedImageKey = imageKey
            };
        }

        public static TreeNode CreateNode(string text, string name, object tag)
        {
            return new TreeNode()
            {
                Text = text,
                Tag = tag,
                Name = name
            };
        }
    }
}
