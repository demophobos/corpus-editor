using Newtonsoft.Json;

namespace Model.Query
{
    public class ChunkQuery : BaseQuery
    {
        [JsonProperty("indexId", NullValueHandling = NullValueHandling.Ignore)]
        public string indexId { get; set; }
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string headerId { get; set; }
        [JsonProperty("indexName", NullValueHandling = NullValueHandling.Ignore)]
        public string indexName { get; set; }
    }
}
