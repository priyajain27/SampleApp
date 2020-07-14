using SampleMyApp.Models;
using SampleMyApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class PostViewModel:BaseViewModel
    {
        public INavigation Navigation { get; set; }
      //  public ICommand DeleteCommand => new Command<PostData>(DeletePost);  
       
        public ObservableCollection<PostData> PostList { get; set; }
       
        public Command<SelectedItemChangedEventArgs> OnPostSelectedCommand { get; set; }
       
      /*  void DeletePost(PostData postData)
        {
            if (PostList.Contains(postData))
            {
                PostList.Remove(postData);
            }
            //App.Database.DeletePostAsync(postData);
            App.RequestManager.DeletePostAsync(postData);

        }*/
       
        public PostViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            Task.Run(async () => { await FetchPostData(); }).Wait();
           OnPostSelectedCommand = new Command<SelectedItemChangedEventArgs>(PostListItemClick);

        }
        public async Task FetchPostData()
         {
            IList<PostData> list = await App.RequestManager.GetPostAsync();

            PostList = new ObservableCollection<PostData>(list);



        }
        async void PostListItemClick(SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is PostData item))
                return;
            await Navigation.PushAsync(new PostDetails(new PostDetailsViewModel(item)));

          
        }
     
    }
}
