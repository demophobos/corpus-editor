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
        private List<ChunkValueItemModel> _words;

        public NoteViewer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataSource.Current is ElementByNoteView noteView)
            {
                var linker = new NoteLinker(_documentProcess, _chunk, noteView);

                if (linker.ShowDialog() == DialogResult.OK)
                {
                    await LoadData(_chunk).ConfigureAwait(true);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var linker = new NoteLinker(_documentProcess, _chunk);

            if (linker.ShowDialog() == DialogResult.OK)
            {
                await LoadData(_chunk).ConfigureAwait(true);
            }
        }

        public async Task LoadData(ChunkModel chunk)
        {
            _chunk = chunk;

            var items = JsonConvert.DeserializeObject<List<ChunkValueItemModel>>(_chunk.ValueObj);

            _words = items.Where(i => i.Type == (int)ElementTypeEnum.Word).ToList();

            btnAdd.Enabled = _chunk != null && _chunk.Status == ChunkStatusEnum.Published;

            var links = await NoteProcess.GetNoteLinks(new NoteLinkQuery { IndexId = _chunk.IndexId }).ConfigureAwait(true);

            var grouppedLinks = links.GroupBy(i => i.NoteId);

            var data = new List<ElementByNoteView>();

            foreach (var note in grouppedLinks)
            {

                var ids = note.Select(i => i.ItemId);

                var relatedWords = _words.Where(i => ids.Contains(i.Id)).ToList();

                var noteObject = _documentProcess.Notes.FirstOrDefault(j => j.Id == note.Key);

                var itemView = new ElementByNoteView
                {
                    Id = note.Key,
                    NoteValue = noteObject.Value,
                    Target = note.FirstOrDefault().Target,
                    Words = relatedWords,
                    Type = noteObject.Type
                };

                data.Add(itemView);
            }

            dataSource.DataSource = data;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataSource.Current is ElementByNoteView noteView &&
                DialogProcess.DeleteWarning(noteView) == DialogResult.Yes)
            {
                await NoteProcess.RemoveNoteLink(new NoteLinkQuery { NoteId = noteView.Id }).ConfigureAwait(true);

                await LoadData(_chunk).ConfigureAwait(true);
            }

        }

        private async void NoteViewer_Load(object sender, EventArgs e)
        {
            await _documentProcess.GetNotesByHeader().ConfigureAwait(true);
        }

        private void noteItemSource_CurrentChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = btnDelete.Enabled = dataSource.Current != null;
        }
    }
}
