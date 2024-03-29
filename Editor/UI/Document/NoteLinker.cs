﻿using Common.Process;
using Model;
using Model.Enum;
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

namespace Document
{
    public partial class NoteLinker : Form
    {
        private ChunkModel _chunk;

        private List<ChunkValueItemModel> _words;

        private DocumentProcess _documentProcess;

        private List<ChunkValueItemModel> _selectedWords;

        private NoteModel _selectedNote;

        private ElementByNoteView _noteView;

        public NoteLinker(DocumentProcess documentProcess, ChunkModel chunk)
        {
            _chunk = chunk;

            _documentProcess = documentProcess;

            InitializeComponent();

            ComboProcess.CreateSelect(cmbTarget, TaxonomyProcess.GetNoteTargets().ToArray());
        }

        public NoteLinker(DocumentProcess documentProcess, ChunkModel chunk, ElementByNoteView noteView)
            : this(documentProcess, chunk)
        {
            _noteView = noteView;
        }

        private void cmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = cmbTarget.SelectedItem is TaxonomyModel target && target.Id == NoteTargetEnum.Chunk.Id;
        }

        private void NoteLinker_Load(object sender, EventArgs e)
        {
            if (_chunk != null)
            {

                var items = JsonConvert.DeserializeObject<List<ChunkValueItemModel>>(_chunk.ValueObj);

                _words = items.Where(i => i.Type == (int)ElementTypeEnum.Word).ToList();

                ((ListBox)listWords).DataSource = _words;
                ((ListBox)listWords).DisplayMember = "Value";
                ((ListBox)listWords).ValueMember = "Id";

                if (_noteView != null) //Note edit case
                {
                    foreach (ChunkValueItemModel item in _words)
                    {
                        if (_noteView.Words.Select(i => i.Id).Contains(item.Id))
                        {
                            listWords.SetItemChecked(listWords.Items.IndexOf(item), true);
                        }
                    }

                    _selectedNote = _documentProcess.Notes.FirstOrDefault(i => i.Id == _noteView.Id);

                    lblNote.Text = _selectedNote.Value;

                    cmbTarget.SelectedItem = NoteTargetEnum.GetById(_noteView.Target);
                }
            }
        }

        private void listWords_SelectedValueChanged(object sender, EventArgs e)
        {
            EnabledSave();

            _selectedWords = new List<ChunkValueItemModel>();

            foreach (var selected in listWords.CheckedItems)
            {
                _selectedWords.Add(selected as ChunkValueItemModel);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var noteExplorer = new NoteExplorer(_documentProcess);

            noteExplorer.NoteSelected += NoteExplorer_NoteSelected;

            noteExplorer.ShowDialog();
        }

        private void NoteExplorer_NoteSelected(object sender, NoteModel note)
        {
            lblNote.Text = note.Value;

            _selectedNote = note;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedNote != null)
            {
                if (_selectedWords.Count > 0 && cmbTarget.SelectedItem is TaxonomyModel target && target.Id == NoteTargetEnum.Words.Id)
                {
                    
                    await NoteProcess.RemoveNoteLink(new Model.Query.NoteLinkQuery { NoteId = _selectedNote.Id }).ConfigureAwait(true);

                    foreach (var word in _selectedWords)
                    {
                        var noteItem = new NoteLinkModel
                        {
                            HeaderId = _chunk.HeaderId,
                            IndexId = _chunk.IndexId,
                            ItemId = word.Id,
                            NoteId = _selectedNote.Id,
                            Target = NoteTargetEnum.Words.Id
                        };

                        await NoteProcess.SaveNoteLink(noteItem).ConfigureAwait(true);
                    }
                }
                else
                { //Link to the chunk 

                    await NoteProcess.RemoveNoteLink(new Model.Query.NoteLinkQuery { NoteId = _selectedNote.Id }).ConfigureAwait(true);

                    var noteItem = new NoteLinkModel
                    {
                        HeaderId = _chunk.HeaderId,
                        IndexId = _chunk.IndexId,
                        ItemId = _chunk.Id,
                        NoteId = _selectedNote.Id,
                        Target = NoteTargetEnum.Chunk.Id
                    };

                    await NoteProcess.SaveNoteLink(noteItem).ConfigureAwait(true);
                }
            }

            await _documentProcess.GetNoteLinksByHeader().ConfigureAwait(true);

            DialogResult = DialogResult.OK;
        }

        private void lblNote_TextChanged(object sender, EventArgs e)
        {
            EnabledSave();
        }

        private void EnabledSave()
        {
            btnSave.Enabled = (_selectedNote != null && 
                listWords.CheckedItems.Count > 0 &&
                cmbTarget.SelectedItem is TaxonomyModel target && target.Id == NoteTargetEnum.Words.Id) 
                || 
                (_selectedNote != null && 
                cmbTarget.SelectedItem is TaxonomyModel target1 
                && target1.Id == NoteTargetEnum.Chunk.Id);
        }
    }
}
