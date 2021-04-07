using Model;
using Model.Enum;
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
    public partial class ChunkExportSelector : Form
    {
        private DocumentProcess _documentProcess;

        private bool _includeChildren = false;

        private bool _indexExport = false; // == Text

        public IndexModel Index { get; private set; }

        public ExportTypeEnum ExportTypeEnum { get; private set; }

        public ChunkExportSelector(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        private void rbtnText_CheckedChanged(object sender, EventArgs e)
        {
            _indexExport = rbtnIndex.Checked == true ? rbtnIndex.Checked : false;

            txtIndeces.Enabled = chkChildren.Enabled = rbtnIndex.Checked;

            if (rbtnText.Checked)
            {
                btnExport.Enabled = true;
            }

            if (rbtnIndex.Checked)
            {
                btnExport.Enabled = Index != null;
            }
        }

        private void ChunkExportSelector_Load(object sender, EventArgs e)
        {
            txtIndeces.AutoCompleteCustomSource.AddRange(_documentProcess.Indeces.Select(i => i.Name).ToArray());
        }

        private void chkChildren_CheckedChanged(object sender, EventArgs e)
        {
            _includeChildren = chkChildren.Checked;
        }

        private void txtIndeces_TextChanged(object sender, EventArgs e)
        {
            Index = _documentProcess.Indeces.FirstOrDefault(i => i.Name == txtIndeces.Text);

            btnExport.Enabled = Index != null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (rbtnText.Checked)
            {
                ExportTypeEnum = ExportTypeEnum.Text;
            }
            if (rbtnIndex.Checked && Index != null && chkChildren.Checked)
            {
                ExportTypeEnum = ExportTypeEnum.IndexWithChildren;
            }
            if (rbtnIndex.Checked && Index != null && !chkChildren.Checked)
            {
                ExportTypeEnum = ExportTypeEnum.Index;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
