using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UpcomingMovies.Model
{
    public class GenreModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
