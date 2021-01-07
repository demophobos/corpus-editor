using Newtonsoft.Json;

namespace Model.Query
{
    public class IndexQuery : BaseQuery
    {
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string headerId { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string parentId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
    }
}
