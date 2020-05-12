using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DeveloperSearch.Model
{
    public class DevelopersList
    {
        [JsonProperty("total_count")]
        public int Total_count { get; set; }

        [JsonProperty("incomplete_results")]
        public bool Incomplete_results { get; set; }

        [JsonProperty("items")]
        public List<DevelopersDetails> DevelopersDetails { get; set; }
    }
}
