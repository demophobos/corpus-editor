using Newtonsoft.Json;

namespace Model
{
    public class IndexModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public string ParentId { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }
        [JsonProperty("bookmarked", NullValueHandling = NullValueHandling.Ignore)]
        public bool Bookmarked { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
