using Newtonsoft.Json;

namespace Model.Query
{
    public class InterpViewQuery : BaseQuery
    {
        [JsonProperty("sourceId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceId { get; set; }
        [JsonProperty("interpId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpId { get; set; }
        [JsonProperty("sourceHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceHeaderId { get; set; }
        [JsonProperty("interpHeaderId", NullValueHandling = NullValueHandling.Ignore)]
        public string InterpHeaderId { get; set; }
        [JsonProperty("returnedType", NullValueHandling = NullValueHandling.Ignore)]
        public int ReturnedType { get; set; }
    }
}
