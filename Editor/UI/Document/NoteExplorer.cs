using Common.Process;
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
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class NoteExplorer : DockContent
    {
        private DocumentProcess _documentProcess;
        public event EventHandler<NoteModel> NoteSelected;
        public NoteExplorer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();

            ComboProcess.CreateSelect(cmbType, TaxonomyProcess.GetNoteTypes().ToArray());

            typeSource.DataSource = TaxonomyProcess.GetNoteTypes();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var note = new NoteModel { HeaderId = _documentProcess.Header.Id };

            var editor = new NoteEditor(note);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                await LoadData().ConfigureAwait(true);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (noteSource.Current is NoteModel note)
            {
                var editor = new NoteEditor(note);

                if (editor.ShowDialog() == DialogResult.OK)
                {
                    await LoadData().ConfigureAwait(true);
                }
            }
        }

        private void noteSource_CurrentChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = noteSource.Current != null;

            if (noteSource.Current is NoteModel note)
            {
                NoteSelected?.Invoke(this, note);
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (noteSource.Current is NoteModel note && DialogProcess.DeleteWarning(note) == DialogResult.OK)
            {
                await NoteProcess.DeleteNote(note);

                await LoadData().ConfigureAwait(true);
            }
        }

        private async void NoteExplorer_Load(object sender, EventArgs e)
        {
            await LoadData().ConfigureAwait(true);
        }

        private async Task LoadData()
        {
            await _documentProcess.GetNotesByHeader().ConfigureAwait(true);

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (_documentProcess.Notes != null)
            {
                var filtered = _documentProcess.Notes;

                if (cmbType.SelectedItem is TaxonomyModel type)
                {
                    filtered = filtered.Where(i => i.Type == type.Id).ToList();
                }

                if (txtValue.Text.Length > 0)
                {
                    filtered = filtered.Where(i => i.Value.Contains(txtValue.Text)).ToList();
                }

                noteSource.DataSource = filtered;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
