using System;
using System.Windows.Forms;

namespace Editor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            var s = "UnhandledExceptionHandler caught : " + e.Message + Environment.NewLine;
            s += "Runtime terminating:  " + args.IsTerminating + Environment.NewLine;
            s += "Stack Trace:" + e.StackTrace;
            MessageBox.Show(s, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
