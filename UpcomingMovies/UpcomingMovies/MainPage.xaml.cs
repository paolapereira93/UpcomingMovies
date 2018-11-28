using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Model;
using UpcomingMovies.Service;
using UpcomingMovies.ViewModel;
using UpcomingMovies.Views.Movie;
using Xamarin.Forms;

namespace UpcomingMovies
{
    public partial class MainPage : ContentPage
    {
        private MovieService movieService = new MovieService();
        private HomeViewModel viewModel = new HomeViewModel();

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this.viewModel;
        }

        private async void InfiniteScrollListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var m = (MovieModel) e.Item;
            int id = m.Id;
            
            var movie = await movieService.GetMovieDetails(id);
            await Navigation.PushAsync(new Detail(movie));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MovieList.BeginRefresh();
            viewModel.Load();
            this.MovieList.ItemsSource = viewModel.Items;
            this.MovieList.EndRefresh();
        }
    }
}
