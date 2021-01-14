using Newtonsoft.Json;
using System;

namespace Model
{
    public class ProjectModel : BaseModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("desc")]
        public string Desc { get; set; }
        [JsonProperty("creatorId")]
        public string CreatorId { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}
