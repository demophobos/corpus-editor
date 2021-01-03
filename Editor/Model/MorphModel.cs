using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MorphModel: BaseModel
    {
        [JsonProperty("lemma")]
        public string Lemma { get; set; }
        [JsonProperty("form")]
        public string Form { get; set; }
        [JsonProperty("pos")]
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
        [JsonProperty("lang")]
        public string Lang { get; set; }
    }
}
