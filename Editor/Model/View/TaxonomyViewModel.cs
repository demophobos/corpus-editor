using Newtonsoft.Json;

namespace Model.View
{
    public class TaxonomyViewModel : TaxonomyModel
    {
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }
        [JsonProperty("categoryCode")]
        public string CategoryCode { get; set; }
        [JsonProperty("categoryDesc")]
        public string CategoryDesc { get; set; }
    }
}
