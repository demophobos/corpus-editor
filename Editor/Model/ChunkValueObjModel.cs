using Newtonsoft.Json;

namespace Model
{
    public class ChunkValueItemModel : BaseModel
    {

        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("morphId", NullValueHandling = NullValueHandling.Ignore)]
        public string MorphId { get; set; }
        [JsonProperty("lemma", NullValueHandling = NullValueHandling.Ignore)]
        public string Lemma { get; set; }
        [JsonProperty("form", NullValueHandling = NullValueHandling.Ignore)]
        public string Form { get; set; }
        [JsonProperty("pos", NullValueHandling = NullValueHandling.Ignore)]
        public string Pos { get; set; }
        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }
        [JsonProperty("case", NullValueHandling = NullValueHandling.Ignore)]
        public string Case { get; set; }
        [JsonProperty("dialect", NullValueHandling = NullValueHandling.Ignore)]
        public string Dialect { get; set; }
        [JsonProperty("feature", NullValueHandling = NullValueHandling.Ignore)]
        public string Feature { get; set; }
        [JsonProperty("person", NullValueHandling = NullValueHandling.Ignore)]
        public string Person { get; set; }
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
        [JsonProperty("tense", NullValueHandling = NullValueHandling.Ignore)]
        public string Tense { get; set; }
        [JsonProperty("mood", NullValueHandling = NullValueHandling.Ignore)]
        public string Mood { get; set; }
        [JsonProperty("voice", NullValueHandling = NullValueHandling.Ignore)]
        public string Voice { get; set; }
        [JsonProperty("degree", NullValueHandling = NullValueHandling.Ignore)]
        public string Degree { get; set; }
        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public string Lang { get; set; }
    }
}
