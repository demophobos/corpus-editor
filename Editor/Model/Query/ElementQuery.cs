using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class ElementQuery : BaseQuery
    {
        [JsonProperty("chunkId", NullValueHandling = NullValueHandling.Ignore)]
        public string chunkId { get; set; }

        [JsonProperty("morphId", NullValueHandling = NullValueHandling.Ignore)]
        public string morphId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string value { get; set; }
    }
}
