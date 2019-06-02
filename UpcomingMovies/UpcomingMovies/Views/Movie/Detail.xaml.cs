using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Model;
using UpcomingMovies.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMovies.Views.Movie
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
        private MovieModel modelView = new MovieModel();

        public Detail (MovieModel movie)
		{
            InitializeComponent();
            this.modelView = movie;
            this.BindingContext = this.modelView;
        }

	}
}