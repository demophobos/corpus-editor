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
    public partial class InterpSelector : DockContent
    {
        private IndexModel _index;

        private ChunkModel _chunk;

        private ChunkModel _inputChunk;

        private DocumentProcess _documentProcess;

        public InterpSelector(DocumentProcess documentProcess, IndexModel index, ChunkModel inputChunk)
        {
            _index = index;

            _inputChunk = inputChunk;

            _documentProcess = documentProcess;

            InitializeComponent();
        }

        private async Task LoadFilterData()
        {
            var list = await HeaderProcess.GetHeaders(_documentProcess.Header.ProjectId).ConfigureAwait(true);

            var interps = list.Where(i => i.EditionType != _documentProcess.Header.EditionType);

            headerSource.DataSource = interps;
        }

        private async void headerSource_CurrentChanged(object sender, EventArgs e)
        {
            if (headerSource.Current is HeaderModel header)
            {
                var list = await _documentProcess.GetIndecesByHeader(header.Id).ConfigureAwait(true);

                indexSource.DataSource = list;

                cmbIndex.Text = _index.Name;
            }
        }

        private async void indexSource_CurrentChanged(object sender, EventArgs e)
        {
            if (indexSource.Current is IndexModel index)
            {
                _chunk = await ChunkProcess.GetChunkByIndex(index.Id).ConfigureAwait(true);

                txtChunk.Text = _chunk.Value;
            }
        }

        private async void InterpSelector_Load(object sender, EventArgs e)
        {
            await LoadFilterData().ConfigureAwait(true);
        }

        private void txtChunk_TextChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = txtChunk.Text.Length > 0;
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            var interp = new InterpModel();

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                interp.InterpId = _chunk.Id;

                interp.SourceId = _inputChunk.Id;
            }
            else
            {
                interp.SourceId = _chunk.Id;

                interp.InterpId = _inputChunk.Id;
            }

            await _documentProcess.SaveInterp(interp).ConfigureAwait(true);

        }
    }
}
