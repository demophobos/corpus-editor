using Newtonsoft.Json;

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
