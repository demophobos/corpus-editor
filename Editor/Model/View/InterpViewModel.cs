using Newtonsoft.Json;

namespace Model.View
{
    public class InterpViewModel : InterpModel
    {
        [JsonProperty("sourceValue")]
        public string SourceValue { get; set; }
        [JsonProperty("sourceValueObj")]
        public string SourceValueObj { get; set; }
        [JsonProperty("sourceIndexName")]
        public string SourceIndexName { get; set; }
        [JsonProperty("sourceIndexOrder")]
        public string SourceIndexOrder { get; set; }
        [JsonProperty("sourceHeaderDesc")]
        public string SourceHeaderDesc { get; set; }
        [JsonProperty("sourceProjectDesc")]
        public string SourceProjectDesc { get; set; }
        [JsonProperty("sourceIndexId")]
        public string SourceIndexId { get; set; }
        [JsonProperty("sourceHeaderEditionType")]
        public string SourceHeaderEditionType { get; set; }
        [JsonProperty("sourceProjectId")]
        public string SourceProjectId { get; set; }
        [JsonProperty("sourceProjectCode")]
        public string SourceProjectCode { get; set; }
        [JsonProperty("sourceHeaderCode")]
        public string SourceHeaderCode { get; set; }
        [JsonProperty("sourceHeaderLang")]
        public string SourceHeaderLang { get; set; }
        [JsonProperty("interpValue")]
        public string InterpValue { get; set; }
        [JsonProperty("interpValueObj")]
        public string InterpValueObj { get; set; }
        [JsonProperty("interpIndexName")]
        public string InterpIndexName { get; set; }
        [JsonProperty("interpIndexOrder")]
        public string InterpIndexOrder { get; set; }
        [JsonProperty("interpHeaderDesc")]
        public string InterpHeaderDesc { get; set; }
        [JsonProperty("interpProjectDesc")]
        public string InterpProjectDesc { get; set; }
        [JsonProperty("interpIndexId")]
        public string InterpIndexId { get; set; }
        [JsonProperty("interpHeaderEditionType")]
        public string InterpHeaderEditionType { get; set; }
        [JsonProperty("interpProjectId")]
        public string InterpProjectId { get; set; }
        [JsonProperty("interpProjectCode")]
        public string InterpProjectCode { get; set; }
        [JsonProperty("interpHeaderCode")]
        public string InterpHeaderCode { get; set; }
        [JsonProperty("interpHeaderLang")]
        public string InterpHeaderLang { get; set; }
    }
}
