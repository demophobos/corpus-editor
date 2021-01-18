using System.Windows.Forms;

namespace Common.Process
{
    public class DialogProcess
    {
        public static DialogResult DeleteWarning(object type)
        {
            return MessageBox.Show($"Вы действительно хотите удалить {type}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult BulkApplyWarning(int count)
        {
            return MessageBox.Show($"Применить определение к {count} случаям?", "Определение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult BulkUndoWarning(int count)
        {
            return MessageBox.Show($"Отменить определение для {count} случаев?", "Определение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        public static DialogResult UndoWarning()
        {
            return MessageBox.Show($"Отменить определение?", "Определение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult RuleRemovingWarning()
        {
            return MessageBox.Show($"Удалить правило?", "Правило", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult DeleteBulkWarning(string message)
        {
            return MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static void InfoMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
