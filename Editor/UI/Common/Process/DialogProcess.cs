using System.Globalization;
using System.Windows.Forms;

namespace Common.Process
{
    public class DialogProcess
    {
        public static DialogResult DeleteWarning(object type)
        {
            return MessageBox.Show(string.Format(CultureInfo.InvariantCulture,
                @"Are you sure you want to delete '{0}'?", type.ToString()),
                @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        }

        public static DialogResult DeleteBulkWarning(string message)
        {
            return MessageBox.Show(string.Format(CultureInfo.InvariantCulture,
                @"Are you sure you want to delete '{0}'?", message),
                @"Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        }

        public static void InfoMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
