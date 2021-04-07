using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ExportResultViewer : DockContent
    {
        private string _result;
        public ExportResultViewer()
        {
            InitializeComponent();
        }

        internal void StartExport()
        {
            loader1.BringToFront();

            loader1.SetStatus("Выполняет экспорт данных ...");
        }

        internal void EndExport()
        {
            loader1.SendToBack();
        }

        internal void SetResult(string title, string result)
        {
            Text = title;

            _result = result;

            var path = Path.GetTempPath();

            var fileName = Guid.NewGuid().ToString() + ".xml";

            var fullFileName = Path.Combine(path, fileName);

            File.WriteAllText(fullFileName, result);

            webBrowser1.Navigate(fullFileName); 
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = "RusCorpora XML | *.xml",

                Title = "Сохранение файла в формате RusCorpora XML",

                FileName = Text
            };

            sfd.ShowDialog();

            if (!string.IsNullOrEmpty(sfd.FileName))
            {
                File.WriteAllText(sfd.FileName, _result);
            }
        }
    }
}
