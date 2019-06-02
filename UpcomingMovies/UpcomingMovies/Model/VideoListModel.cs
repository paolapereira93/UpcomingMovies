using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Model
{
    public class VideoListModel
    {
        [JsonProperty("results")]
        public List<VideoModel> Videos { get; set; }
    }
}
