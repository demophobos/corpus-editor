using Newtonsoft.Json;

namespace Model.Query
{
    public class InterpQuery : BaseQuery
    {
        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string sourceId { get; set; }

        [JsonProperty("interpId", NullValueHandling = NullValueHandling.Ignore)]
        public string interpId { get; set; }
        [JsonProperty("sourceHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string sourceHeaderId { get; set; }
        [JsonProperty("interpHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string interpHeaderId { get; set; }
    }
}
