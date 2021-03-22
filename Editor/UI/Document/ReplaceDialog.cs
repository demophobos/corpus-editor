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
    public partial class ReplaceDialog : Form
    {
        public string Output { get; private set; }

        public string Input;
        public ReplaceDialog()
        {
            InitializeComponent();
        }

        private void TxtInputOutput_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = Input.Length > 0 && txtInput.Text.Length > 0 && txtOutput.Text.Length > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Output = Input.Replace(txtInput.Text, txtOutput.Text);

            DialogResult = DialogResult.OK;
        }
    }
}
