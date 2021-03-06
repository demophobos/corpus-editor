using Model;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document
{
    public partial class IndexNameEditor : Form
    {
        private DocumentProcess _documentProcess;

        IndexModel _index;
        public IndexNameEditor(DocumentProcess documentProcess, IndexModel index)
        {
            _documentProcess = documentProcess;

            _index = index;

            InitializeComponent();

            txtName.Text = _index.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtName.Text.Trim().Length > 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _index.Name = txtName.Text;

            await _documentProcess.SaveIndex(_index).ConfigureAwait(true);

            DialogResult = DialogResult.OK;
        }
    }
}
