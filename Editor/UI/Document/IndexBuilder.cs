using Model;
using Process;
using System;
using System.Windows.Forms;

namespace Document
{
    public partial class IndexBuilder : Form
    {
        private DocumentProcess _documentProcess;

        private IndexModel _index;

        private string _prefix;

        public IndexBuilder(DocumentProcess documentProcess, IndexModel index)
        {
            _documentProcess = documentProcess;

            _index = index;

            InitializeComponent();
        }

        public IndexBuilder(DocumentProcess documentProcess, IndexModel index, string prefix)
        {
            _documentProcess = documentProcess;

            _index = index;

            _prefix = prefix;

            InitializeComponent();

            if (!string.IsNullOrEmpty(prefix))
            {
                Text = prefix;
            }
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
                            Order = startOrder,
                            ParentId = _index.ParentId
                        };

                        CreateIndexName(item.ToString(), inx);

                        await _documentProcess.SaveIndex(inx).ConfigureAwait(true);

                        startOrder += 1;
                    }
                }
                else
                {
                    CreateIndexName(indexText, _index);

                    await _documentProcess.SaveIndex(_index).ConfigureAwait(true);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateIndexName(string item, IndexModel inx)
        {
            if (!string.IsNullOrEmpty(_prefix))
            {
                inx.Name = $"{_prefix}.{item}";
            }
            else
            {
                inx.Name = item.ToString();
            }
        }

        private void startValue_ValueChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = startValue.Value > 0;
        }
    }
}
