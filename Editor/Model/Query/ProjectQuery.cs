using Newtonsoft.Json;

namespace Model.Query
{
    public class ProjectQuery : BaseQuery
    {
        [JsonProperty("creatorId", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatorId { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    }
}
