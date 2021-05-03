using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
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
    public partial class NoteViewer : DockContent
    {
        private readonly DocumentProcess _documentProcess;
        private ChunkModel _chunk;

        public NoteViewer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataSource.Current is ElementByNoteView noteView)
            {
                var linker = new NoteLinker(_documentProcess, _chunk, noteView);

                if (linker.ShowDialog() == DialogResult.OK)
                {
                    LoadData(_chunk);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var linker = new NoteLinker(_documentProcess, _chunk);

            if (linker.ShowDialog() == DialogResult.OK)
            {
                LoadData(_chunk);
            }
        }

        public void LoadData(ChunkModel chunk)
        {
            _chunk = chunk;

            btnAdd.Enabled = _chunk != null && _chunk.Status == ChunkStatusEnum.Published;

            dataSource.DataSource = _documentProcess.GetNotesByIndex(_chunk);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataSource.Current is ElementByNoteView noteView &&
                DialogProcess.DeleteWarning(noteView) == DialogResult.Yes)
            {
                await NoteProcess.RemoveNoteLink(new NoteLinkQuery { NoteId = noteView.Id }).ConfigureAwait(true);

                await _documentProcess.GetNoteLinksByHeader().ConfigureAwait(true);

                LoadData(_chunk);
            }

        }

        private void NoteViewer_Load(object sender, EventArgs e)
        {
            
        }

        private void noteItemSource_CurrentChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = btnDelete.Enabled = dataSource.Current != null;
        }
    }
}
