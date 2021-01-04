using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Query
{
    public class IndexQuery : BaseQuery
    {
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string headerId { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string parentId { get; set; }
    }
}
