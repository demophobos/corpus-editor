using Model;
using Model.Enum;
using Model.Query;
using Model.View;
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
    public partial class InterpViewer : DockContent
    {
        private InterpViewModel _interp;

        private EditionTypeEnum _typeToShow;

        public InterpViewer(InterpViewModel interp, EditionTypeEnum typeToShow)
        {
            _interp = interp;

            _typeToShow = typeToShow;

            InitializeComponent();
        }

        private async Task LoadData()
        {

            txtContainer.Controls.Clear();

            var query = new ElementQuery();

            if (_typeToShow == EditionTypeEnum.Original)
            {
                query.chunkId = _interp.SourceId;

                Text = $"{_interp.SourceIndexName} [{_interp.SourceHeaderCode}]";

                ToolTipText = _interp.SourceHeaderDesc;
            }
            else
            {
                query.chunkId = _interp.InterpId;

                Text = $"{_interp.InterpIndexName} [{_interp.InterpHeaderCode}]";

                ToolTipText = _interp.InterpHeaderDesc;
            }

            var elements = await ElementProcess.GetElements(query).ConfigureAwait(true);

            foreach (var element in elements)
            {
                if (element.Type == (int)ElementTypeEnum.NewLine)
                {
                    var lastLabel = txtContainer.Controls.OfType<Label>().LastOrDefault();

                    txtContainer.SetFlowBreak(lastLabel, true);
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
                        Margin = new Padding(0, 0, 0, 0),
                        FlatStyle = FlatStyle.Flat
                    };

                    txtContainer.Controls.Add(label);
                }
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void InterpViewer_Load(object sender, EventArgs e)
        {
            await LoadData().ConfigureAwait(true);

            loader1.SendToBack();
        }
    }
}
