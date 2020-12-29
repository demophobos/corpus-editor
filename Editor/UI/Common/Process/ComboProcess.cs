using System.Windows.Forms;

namespace Common.Process
{
    public class ComboProcess
    {
        public static void CreateNullableSelect(ToolStripComboBox cmb, object[] objects)
        {
            cmb.Items.Clear();

            cmb.Items.Add("");

            cmb.Items.AddRange(objects);
        }

        public static void CreateNullableSelect(ToolStripComboBox cmb, object[] objects, string emptyText = "", object selected = null)
        {
            cmb.Items.Clear();

            cmb.Items.Add(emptyText);

            cmb.Items.AddRange(objects);

            if (selected != null && cmb.Items.Contains(selected))
            {
                cmb.SelectedItem = selected;
            }
            else
            {
                if (cmb.Items.Count > 0)
                {
                    cmb.SelectedIndex = 0;
                }
            }
        }

        public static void CreateSelect(ToolStripComboBox cmb, object[] objects, object selected = null)
        {
            cmb.Items.Clear();

            cmb.Items.AddRange(objects);

            if (selected != null && cmb.Items.Contains(selected))
            {
                cmb.SelectedItem = selected;
            }
            else
            {
                if (cmb.Items.Count > 0)
                {
                    cmb.SelectedIndex = 0;
                }
            }
        }
    }
}
