using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class NoteLinkQuery: BaseQuery
    {
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderId { get; set; }
        [JsonProperty("indexId", NullValueHandling = NullValueHandling.Ignore)]
        public string IndexId { get; set; }
        [JsonProperty("noteId", NullValueHandling = NullValueHandling.Ignore)]
        public string NoteId { get; set; }
    }
}
