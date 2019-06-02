using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Model;

namespace UpcomingMovies.Service
{
    public class MovieService
    {
        private HttpClient httpClient = new HttpClient();
        private readonly string ApiKey = "1f54bd990f1cdfb230adb312546d765d";


        public async Task<List<MovieModel>> GetUpcomingMovies(int page = 1, string search = "")
        {
            try
            {
                string url = string.Format("https://api.themoviedb.org/3/movie/upcoming?api_key={0}&language=en-US&page={1}", ApiKey, page);
                if (!string.IsNullOrWhiteSpace(search))
                {
                    url = string.Format("https://api.themoviedb.org/3/search/movie?api_key={0}&language=en-US&year={1}&page={2}&include_adult=false&query={3}", ApiKey, DateTime.Now.Year, page, search);
                }
                var response = await httpClient.GetStringAsync(url);
                var movies = JsonConvert.DeserializeObject<MovieListModel>(response);
                return movies.Movies;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MovieModel> GetMovieDetails(int movieId)
        {
            try
            {
                string url = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-US", movieId, ApiKey);
                var response = await httpClient.GetStringAsync(url);
                var movie = JsonConvert.DeserializeObject<MovieModel>(response);

                url = string.Format("https://api.themoviedb.org/3/movie/{0}/videos?api_key={1}&language=en-US", movieId, ApiKey);
                response = await httpClient.GetStringAsync(url);
                movie.Videos = JsonConvert.DeserializeObject<VideoListModel>(response);

                return movie;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
