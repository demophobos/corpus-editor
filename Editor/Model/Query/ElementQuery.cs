using Newtonsoft.Json;

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

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public int? type { get; set; }

        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string headerId { get; set; }
    }
}
