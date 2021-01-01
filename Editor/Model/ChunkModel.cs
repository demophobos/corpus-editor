using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChunkModel: BaseModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("indexId")]
        public string IndexId { get; set; }
    }
}
