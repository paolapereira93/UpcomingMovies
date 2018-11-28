using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections;

namespace UpcomingMovies.Component
{
    public class InfiniteScrollListView : ListView
    {
        public static readonly BindableProperty LoadCommandProperty = BindableProperty.Create<InfiniteScrollListView, ICommand>(bp => bp.LoadCommand, default(ICommand));

        public InfiniteScrollListView()
        {
            this.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var items = this.ItemsSource as IList;
                if(items != null && e.Item == items[items.Count - 1])
                {
                    if(this.LoadCommand != null && this.LoadCommand.CanExecute(null))
                    {
                        this.LoadCommand.Execute(null);
                    }
                }
            };
        }

        public ICommand LoadCommand
        {
            get { return (ICommand)this.GetValue(LoadCommandProperty); }
            set { this.SetValue(LoadCommandProperty, value); }
        }
    }
}
