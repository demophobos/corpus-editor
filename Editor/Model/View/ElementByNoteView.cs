using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public class ElementByNoteView
    {
        public ElementByNoteView()
        {
            Words = new List<ChunkValueItemModel>();
        }
        public string Id { get; set; }
        public string NoteValue { get; set; }
        public string ElementNames
        {
            get
            {
                if (Target == NoteTargetEnum.Chunk.Id)
                {
                    return NoteTargetEnum.Chunk.Code;
                }
                else
                {
                    return string.Join(" ", Words.Select(i => i.Value).ToArray());
                }
            }
        }

        public string Target { get; set; }
        public string Type { get; set; }
        public string TypeName { get {
                return NoteTypeEnum.GetById(Type).Code;
            } }
        public List<ChunkValueItemModel> Words { get; set; }

    }
}
