﻿using Newtonsoft.Json;
using System;

namespace Model
{
    public class ChunkModel : BaseModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("valueObj", NullValueHandling = NullValueHandling.Ignore)]
        public string ValueObj { get; set; }
        [JsonProperty("indexId")]
        public string IndexId { get; set; }
        [JsonProperty("headerId")]
        public string HeaderId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
