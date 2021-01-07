using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class InterpQuery : BaseQuery
    {
        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string sourceId { get; set; }

        [JsonProperty("interpId", NullValueHandling = NullValueHandling.Ignore)]
        public string interpId { get; set; }
    }
}
