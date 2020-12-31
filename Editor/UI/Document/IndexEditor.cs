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
    public partial class IndexEditor : Form
    {
        private DocumentProcess _documentProcess;

        private IndexModel _index;

        public IndexEditor(DocumentProcess documentProcess, IndexModel index, string prefix = null)
        {
            _documentProcess = documentProcess;

            _index = index;

            InitializeComponent();

            txtName.Text = index.Name;

            txtPrefix.Visible = prefix != null;

            txtPrefix.Text = prefix;
        }

        IEnumerable<int> Sequence(int n1, int n2)
        {
            while (n1 <= n2)
            {
                yield return n1++;
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                var indexText = txtName.Text.Trim();

                if (indexText.Contains("~"))
                {
                    var arr = indexText.Split('~');

                    int startOrder = _index.Order;

                    if (int.TryParse(arr[0], out int start) && int.TryParse(arr[1], out int end) && end > start)
                    {
                        foreach (int item in Sequence(start, end))
                        {
                            var inx = new IndexModel
                            {
                                HeaderId = _index.HeaderId,
                                Order = startOrder,
                                ParentId = _index.ParentId
                            };

                            if (!string.IsNullOrEmpty(txtPrefix.Text))
                            {
                                inx.Name = $"{txtPrefix.Text}.{item}";
                            }
                            else
                            {
                                inx.Name = item.ToString();
                            }

                            await _documentProcess.SaveIndex(inx).ConfigureAwait(true);

                            startOrder += 1;
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtPrefix.Text))
                    {
                        _index.Name = $"{txtPrefix.Text}.{indexText}";
                    }
                    else
                    {
                        _index.Name = indexText;
                    }

                    await _documentProcess.SaveIndex(_index).ConfigureAwait(true);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
