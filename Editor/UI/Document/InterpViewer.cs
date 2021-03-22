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
            txtChunkValue.Clear();

            ChunkModel chunk;

            if (_typeToShow == EditionTypeEnum.Original)
            {

                chunk = await ChunkProcess.GetChunk(Interp.SourceId).ConfigureAwait(true);

                Text = $"{Interp.SourceIndexName} [{Interp.SourceHeaderCode}]";

                ToolTipText = Interp.SourceHeaderDesc;
            }
            else
            {

                chunk = await ChunkProcess.GetChunk(Interp.InterpId).ConfigureAwait(true);

                Text = $"{Interp.InterpIndexName} [{Interp.InterpHeaderCode}]";

                ToolTipText = Interp.InterpHeaderDesc;
            }

            if (chunk != null)
            {
                txtChunkValue.Text = chunk.Value;
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
