using Newtonsoft.Json;

namespace Model
{
    public class ElementModel : BaseModel
    {
        [JsonProperty("chunkId")]
        public string ChunkId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("morphId", NullValueHandling = NullValueHandling.Include)]
        public string MorphId { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }
    }
}
