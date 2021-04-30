using API;
using Model;
using Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class NoteProcess
    {
        public static async Task<NoteModel> SaveNote(NoteModel note)
        {
            return await NoteAPI.Save(note);
        }

        public static async Task<List<NoteModel>> GetNotes(NoteQuery query)
        {
            return await NoteAPI.GetNotes(query);
        }

        public static async Task<List<NoteLinkModel>> GetNoteLinks(NoteLinkQuery query)
        {
            return await NoteLinkAPI.GetNoteLinks(query);
        }

        public static async Task<NoteModel> DeleteNote(NoteModel note)
        {
            return await NoteAPI.Remove(note).ConfigureAwait(true);
        }

        public static async Task<NoteLinkModel> SaveNoteLink(NoteLinkModel noteItem)
        {
            return await NoteLinkAPI.Save(noteItem).ConfigureAwait(true);
        }

        public static async Task<NoteLinkModel> RemoveNoteLink(NoteLinkQuery query)
        {
            return await NoteLinkAPI.RemoveByQuery(query);
        }
    }
}
