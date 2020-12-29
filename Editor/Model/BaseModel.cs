using Newtonsoft.Json;

namespace Model
{
    public class BaseModel
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}
