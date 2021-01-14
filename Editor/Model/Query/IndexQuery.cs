using Newtonsoft.Json;

namespace Model.Query
{
    public class IndexQuery : BaseQuery
    {
        [JsonProperty("headerId", NullValueHandling = NullValueHandling.Ignore)]
        public string HeaderId { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
