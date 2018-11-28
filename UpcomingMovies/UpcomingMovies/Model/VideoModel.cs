using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Model
{
    public class VideoModel
    {
        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
