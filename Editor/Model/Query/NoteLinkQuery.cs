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
        [JsonProperty("indexId", NullValueHandling = NullValueHandling.Ignore)]
        public string IndexId { get; set; }
    }
}
