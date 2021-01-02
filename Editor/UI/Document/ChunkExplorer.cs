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
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkExplorer : DockContent
    {
        private ChunkModel _chunk;
        public ChunkExplorer(ChunkModel chunk)
        {
            _chunk = chunk;

            InitializeComponent();
        }

        private async void ChunkExplorer_Load(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();

            var elements = await ElementProcess.GetElements(_chunk.Id).ConfigureAwait(true);

            foreach (var element in elements)
            {
                if (element.Type == (int)ElementTypeEnum.NewLine)
                {
                    var lastLabel = flowLayoutPanel1.Controls.OfType<Label>().LastOrDefault();

                    flowLayoutPanel1.SetFlowBreak(lastLabel, true);
                }
                else if (element.Type == (int)ElementTypeEnum.Space)
                {
                    var next = elements.FirstOrDefault(i => i.Order == element.Order + 1);

                    if (next != null && next.Type == (int)ElementTypeEnum.Punctuation)
                    {
                        continue;
                    }
                }
                else
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Text = element.Value,
                        Tag = element,
                        Padding = new Padding(1, 1, 1, 1),
                        FlatStyle = FlatStyle.Flat
                    };

                    label.MouseMove += Label_MouseMove;

                    label.MouseLeave += Label_MouseLeave;

                    if (!string.IsNullOrWhiteSpace(element.Value) && element.Type != (int)ElementTypeEnum.Punctuation)
                    {
                        //var selectedAnalyses = _analyses.Where(i => i.ElementGuid == element.Guid).ToList();

                        //if (selectedAnalyses.Count > 0)
                        //{
                        //    if (selectedAnalyses.FirstOrDefault().Status == ElementAnalysisStatusEnum.Accepted)
                        //    {
                        //        label.ForeColor = Color.Black;
                        //    }
                        //    if (selectedAnalyses.FirstOrDefault().Status == ElementAnalysisStatusEnum.Proposed)
                        //    {
                        //        label.ForeColor = Color.Blue;
                        //    }
                        //}
                        //else
                        //{
                        //    label.ForeColor = Color.Red;
                        //}
                    }

                    flowLayoutPanel1.Controls.Add(label);

                    //var comments = _elementComments.Where(i => i.ElementGuid == element.Guid);

                    //foreach (var comment in comments)
                    //{
                    //    var commentLabel = new Label
                    //    {
                    //        AutoSize = true,
                    //        Text = comment.Type.Value == 0 ? $"{comment.CommentOrder}" : $"{comment.CommentOrder}*",
                    //        Tag = comment,
                    //        Padding = new Padding(1, 1, 1, 1),
                    //        FlatStyle = FlatStyle.Flat,
                    //        Font = new Font("Palatino Linotype", 9),
                    //        TextAlign = ContentAlignment.TopLeft
                    //    };

                    //    flowLayoutPanel1.Controls.Add(commentLabel);
                    //}

                    //if (!string.IsNullOrEmpty(_selectedElementGuid) && _selectedElementGuid == element.Guid)
                    //{
                    //    label.BackColor = SystemColors.ActiveCaption;
                    //}
                }
            }

        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            var el = ((Label)sender).Tag as ElementModel;

            if (el.Type == (int)ElementTypeEnum.Word)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }

            base.OnMouseMove(e);
        }
    }
}
