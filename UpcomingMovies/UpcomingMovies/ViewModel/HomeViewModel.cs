using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using UpcomingMovies.Model;
using UpcomingMovies.Service;
using System.Windows.Input;
using Xamarin.Forms;

namespace UpcomingMovies.ViewModel
{
    public class HomeViewModel
    {
        public ObservableCollection<MovieModel> Items { get; set; }
        public ICommand LoadCommand { get; set; }
        private int page = 1;
        

        public HomeViewModel()
        {
            Items = new ObservableCollection<MovieModel>();
            this.LoadCommand = new Command(this.Load);
            this.Load();
        }

        public async void Load()
        {
            MovieService service = new MovieService();
            foreach (var m in await service.GetUpcomingMovies(page, Search))
            {
                Items.Add(m);
            }
            page++;
        }


        private string search;
        public string Search
        {
            get
            {
                return this.search;
            }
            set
            {
                this.page = 1;
                this.search = value;
                this.Items = new ObservableCollection<MovieModel>();
            }
        }

    }
}
