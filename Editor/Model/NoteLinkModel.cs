using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoteLinkModel: BaseModel
    {
        [JsonProperty("indexId")]
        public string IndexId { get; set; }
        [JsonProperty("itemId")]
        public string ItemId { get; set; }
        [JsonProperty("target")]
        public string Target { get; set; }
        [JsonProperty("noteId")]
        public string NoteId { get; set; }
    }
}
