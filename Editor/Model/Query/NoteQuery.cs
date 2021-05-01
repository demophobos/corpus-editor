using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class NoteQuery : BaseQuery
    {
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderId { get; set; }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}
