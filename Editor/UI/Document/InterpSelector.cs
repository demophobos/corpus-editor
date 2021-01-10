using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Process;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class InterpSelector : DockContent
    {
        private IndexModel _index;

        private ChunkViewModel _chunk;

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

            if (interps.Count() == 0)
            {
                txtChunk.Text = "Перевод не найден.";
                txtChunk.ForeColor = Color.Red;
                btnSelect.Enabled = false;
                cmbHeader.Enabled = false;
            }
            else
            {
                headerSource.DataSource = interps;
            }
        }

        private async void headerSource_CurrentChanged(object sender, EventArgs e)
        {
            if (headerSource.Current is HeaderModel header)
            {
                _chunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { headerId = header.Id, indexName = _index.Name }).ConfigureAwait(true);

                if (_chunk != null)
                {
                    txtChunk.Text = $"{_chunk.IndexName}. {_chunk.Value}";
                }
                else
                {
                    txtChunk.Text = "Перевод не найден.";
                    txtChunk.ForeColor = Color.Red;
                    btnSelect.Enabled = false;
                }

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

                interp.InterpHeaderId = _chunk.HeaderId;

                interp.SourceHeaderId = _inputChunk.HeaderId;
            }
            else
            {
                interp.SourceId = _chunk.Id;

                interp.InterpId = _inputChunk.Id;

                interp.InterpHeaderId = _inputChunk.HeaderId;

                interp.SourceHeaderId = _chunk.HeaderId;
            }

            var existing = await _documentProcess.GetInterpsByQuery(new InterpQuery { sourceId = interp.SourceId, interpId = interp.InterpId }).ConfigureAwait(true);

            if (existing.Count == 0)
            {
                await _documentProcess.SaveInterp(interp).ConfigureAwait(true);
            }
        }
    }
}
