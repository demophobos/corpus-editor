using Newtonsoft.Json;

namespace Model
{
    public class ChunkModel : BaseModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("indexId")]
        public string IndexId { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }

        public override string ToString()
        {
            return Value.Substring(0, 150);
        }
    }
}
