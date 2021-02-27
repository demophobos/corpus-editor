using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
