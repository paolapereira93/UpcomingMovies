using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace UpcomingMovies.Model
{
    public class MovieModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        public string ShortOverview {
            get
            {
                if(Overview.Length > 200)
                {
                    return Overview.Substring(0, 200) + "...";
                }
                return Overview;
            }
        }
        private string _releaseDate;
        [JsonProperty("release_date")]
        public string ReleaseDate {
            get { return this._releaseDate; }
            set
            {
                DateTime date = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                this._releaseDate = date.ToString("MM/dd/yyyy");
            }
        }
        
        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        public string RuntimeMin { get { return Runtime + " min"; } }

        private string _posterPath;
        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get { return _posterPath; }
            set { _posterPath = "https://image.tmdb.org/t/p/w185" + value; }
        }
        
        [JsonProperty("genres")]
        public List<GenreModel> Genres { get; set; }

        public string FormatedGenres
        {
            get {
                if (Genres == null)
                    return "";
                return String.Join(", ", Genres.ConvertAll(x => x.Name)); }
        }
        
        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("vote_avarage")]
        public double VoteAvarage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        public VideoListModel Videos { get; set; }
        public HtmlWebViewSource Youtube {
            get
            {
                HtmlWebViewSource vs = new HtmlWebViewSource();
                vs.Html = string.Format(@"<!doctype html>
                            <html>
                            <head>
                            </head>
                            <body>
                            <iframe style=""position:absolute;"" width=""100%"" height=""100%"" src=""https://www.youtube.com/embed/{0}"" frameborder=""0"" allow=""accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"" allowfullscreen>
                            </iframe>
                            </body>
                            </html>", Trailer);
                return vs;
            }
        }

        public string Trailer {
            get
            {
                foreach(var v in Videos.Videos)
                {
                    if(v.Type.Equals("Trailer") && v.Site.Equals("YouTube"))
                    {
                        return v.Key;
                    }
                }
                return "";
            }
        }
    }
}
