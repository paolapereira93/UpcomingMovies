using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using UpcomingMovies.Service;

namespace UpcomingMovies.Model
{
    public class MovieListModel
    {
        [JsonProperty("results")]
        public List<MovieModel> Movies { get; set; }
    }
}
