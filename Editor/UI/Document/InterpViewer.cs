using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Process;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class InterpViewer : DockContent
    {
        public InterpViewModel Interp { get; private set; }

        private EditionTypeEnum _typeToShow;

        private DocumentProcess _documentProcess;

        public event EventHandler<InterpModel> InterpDeleted;

        public InterpViewer(DocumentProcess documentProcess, InterpViewModel interp, EditionTypeEnum typeToShow)
        {
            _documentProcess = documentProcess;

            Interp = interp;

            _typeToShow = typeToShow;

            InitializeComponent();
        }

        private async Task LoadData()
        {

            txtContainer.Controls.Clear();

            var query = new ElementQuery();

            if (_typeToShow == EditionTypeEnum.Original)
            {
                query.chunkId = Interp.SourceId;

                Text = $"{Interp.SourceIndexName} [{Interp.SourceHeaderCode}]";

                ToolTipText = Interp.SourceHeaderDesc;
            }
            else
            {
                query.chunkId = Interp.InterpId;

                Text = $"{Interp.InterpIndexName} [{Interp.InterpHeaderCode}]";

                ToolTipText = Interp.InterpHeaderDesc;
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogProcess.DeleteWarning(Interp) == DialogResult.Yes)
            {
                await _documentProcess.DeleteInterp(Interp).ConfigureAwait(true);

                InterpDeleted.Invoke(this, Interp);
            }
        }

        private async void InterpViewer_Load(object sender, EventArgs e)
        {
            loader1.BringToFront();


            if (_typeToShow == EditionTypeEnum.Original)
            {
                loader1.SetStatus("Загрузка оригинала ...");
            }
            else
            {
                loader1.SetStatus("Загрузка переводов ...");
            }

            await LoadData().ConfigureAwait(true);

            loader1.SendToBack();
        }
    }
}
