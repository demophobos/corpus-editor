using Newtonsoft.Json;

namespace Model.Query
{
    public class InterpQuery : BaseQuery
    {
        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; set; }

        [JsonProperty("interpId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpId { get; set; }
        [JsonProperty("sourceHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceHeaderId { get; set; }
        [JsonProperty("interpHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpHeaderId { get; set; }
    }
}
