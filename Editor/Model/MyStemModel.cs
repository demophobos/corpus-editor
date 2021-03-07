using Newtonsoft.Json;
using System.Collections.Generic;

namespace Model
{
    public class Analysis
    {
        [JsonProperty("lex")]
        public string lex { get; set; }
        [JsonProperty("gr")]
        public string gr { get; set; }
    }

    public class MyStemModel
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("analysis")]
        public List<Analysis> analysis { get; set; }
    }
}
