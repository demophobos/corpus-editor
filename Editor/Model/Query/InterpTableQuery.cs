using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class InterpTableQuery : BaseQuery
    {
        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; set; }
        [JsonProperty("interpId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpId { get; set; }
        [JsonProperty("sourceHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceHeaderId { get; set; }
        [JsonProperty("interpHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpHeaderId { get; set; }
        [JsonProperty("returnedType", NullValueHandling = NullValueHandling.Ignore)]
        public int ReturnedType { get; set; }
    }
}
