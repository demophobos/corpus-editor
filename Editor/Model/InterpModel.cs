using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InterpModel : BaseModel
    {
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }
        [JsonProperty("interpId")]
        public string InterpId { get; set; }
    }
}
