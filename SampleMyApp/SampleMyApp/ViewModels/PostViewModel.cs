using SampleMyApp.Models;
using SampleMyApp.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class PostViewModel:BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public List<PostData> PostList { get; set; }
        public Command<SelectedItemChangedEventArgs> OnItemSelectedCommand { get; set; }

        public PostViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            Task.Run(async () => { await FetchPostData(); }).Wait();
            OnItemSelectedCommand = new Command<SelectedItemChangedEventArgs>(ListViewItemClick);

        }
        public async Task FetchPostData()
         {
             PostList = await App.RequestManager.GetPostAsync();

        }
        async void ListViewItemClick(SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is PostData item))
                return;
            await Navigation.PushAsync(new PostDetails(new PostDetailsViewModel(item)));

          
        }
      
    }
}
