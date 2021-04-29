using Common.Process;
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

namespace Document
{
    public partial class NoteEditor : Form
    {
        private NoteModel _noteModel;
        public NoteEditor(NoteModel noteModel)
        {
            _noteModel = noteModel;

            InitializeComponent();

            var types = TaxonomyProcess.GetNoteTypes();

            ComboProcess.CreateSelect(cmbType, types.ToArray(), types.FirstOrDefault(i=>i.Id == noteModel.Type));

            txtValue.Text = noteModel.Value;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbType.SelectedItem is TaxonomyModel type){

                _noteModel.Type = type.Id;

                _noteModel.Value = txtValue.Text;

                await NoteProcess.SaveNote(_noteModel).ConfigureAwait(true);

                DialogResult = DialogResult.OK;
            }
            
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtValue.Text.Length > 0 && cmbType.SelectedIndex != -1;
        }
    }
}
