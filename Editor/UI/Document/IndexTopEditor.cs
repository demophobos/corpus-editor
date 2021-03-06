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
    public partial class IndexTopEditor : Form
    {
        private DocumentProcess _documentProcess;

        private IndexModel _index;

        public IndexTopEditor(DocumentProcess documentProcess, IndexModel index)
        {
            _documentProcess = documentProcess;

            _index = index;

            InitializeComponent();
        }

        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            endValue.Enabled = chkRange.Checked;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var indexText = startValue.Value.ToString();

                if (endValue.Enabled && endValue.Value > startValue.Value)
                {
                    int startOrder = _index.Order;

                    int start = int.Parse(startValue.Value.ToString());

                    int end = int.Parse(endValue.Value.ToString());

                    foreach (int item in Common.Helper.CommonHelper.Sequence(start, end))
                    {
                        var inx = new IndexModel
                        {
                            HeaderId = _index.HeaderId,

                            Order = startOrder
                        };

                        inx.Name = item.ToString();

                        await _documentProcess.SaveIndex(inx).ConfigureAwait(true);

                        startOrder += 1;
                    }
                }
                else
                {
                    _index.Name = indexText;

                    await _documentProcess.SaveIndex(_index).ConfigureAwait(true);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void startValue_ValueChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = startValue.Value > 0;
        }
    }
}
