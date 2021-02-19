using Newtonsoft.Json;

namespace Model.Query
{
    public class ChunkQuery : BaseQuery
    {
        [JsonProperty("indexId", NullValueHandling = NullValueHandling.Ignore)]
        public string IndexId { get; set; }
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderId { get; set; }
        [JsonProperty("indexName", NullValueHandling = NullValueHandling.Ignore)]
        public string IndexName { get; set; }
    }
}
