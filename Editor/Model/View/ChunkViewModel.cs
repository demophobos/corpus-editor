using Newtonsoft.Json;

namespace Model.View
{
    public class ChunkViewModel : ChunkModel
    {
        [JsonProperty("indexName")]
        public string IndexName { get; set; }
        [JsonProperty("indexOrder")]
        public string IndexOrder { get; set; }
        [JsonProperty("headerDesc")]
        public string HeaderDesc { get; set; }
        [JsonProperty("projectDesc")]
        public string ProjectDesc { get; set; }
        [JsonProperty("headerEditionType")]
        public string HeaderEditionType { get; set; }
        [JsonProperty("projectId")]
        public string ProjectId { get; set; }
        [JsonProperty("projectCode")]
        public string ProjectCode { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }
        [JsonProperty("headerCode")]
        public string HeaderCode { get; set; }
        [JsonProperty("headerLang")]
        public string HeaderLang { get; set; }
    }
}
