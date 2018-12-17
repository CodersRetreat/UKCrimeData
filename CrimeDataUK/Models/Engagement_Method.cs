using System;
using Newtonsoft.Json;

namespace CrimeDataUK.Models
{
    public partial class EngagementMethod
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
