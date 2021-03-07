using Newtonsoft.Json;

namespace Model
{
    public class TaxonomyModel : BaseModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("desc")]
        public string Desc { get; set; }
        [JsonProperty("parentId")]
        public string ParentId { get; set; }

        public override string ToString()
        {
            return Code;
        }

        [JsonIgnore]
        public string Name
        {
            get
            {
                return $"{Code}";
            }
        }

        [JsonIgnore]
        public string CombinedName
        {
            get
            {
                return $"{Code} [{Desc}]";
            }
        }
    }
}
