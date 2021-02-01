using Auth;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Editor
{
    static class Program
    {
        private static MainForm form;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new MainForm();
            Application.Run(form);
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (e.InnerException.Message == "Unauthorized")
            {
                var loginForm = new LoginForm();

                loginForm.ShowDialog();
            }
            else
            {
                var s = "UnhandledExceptionHandler caught : " + e.Message + Environment.NewLine;
                s += "Runtime terminating:  " + args.IsTerminating + Environment.NewLine;
                s += "Stack Trace:" + e.StackTrace;
                MessageBox.Show(s, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.Message == "Unauthorized")
            {
                var loginForm = new LoginForm();

                loginForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(e.Exception.ToString(), @"Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
