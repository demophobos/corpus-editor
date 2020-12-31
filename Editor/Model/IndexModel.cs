using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IndexModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }
    }
}
