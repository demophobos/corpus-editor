using Newtonsoft.Json;

namespace Model.Query
{
    public class TaxonomyQuery : BaseQuery
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("categoryId", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryId { get; set; }
        [JsonProperty("categoryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryCode { get; set; }
    }
}
