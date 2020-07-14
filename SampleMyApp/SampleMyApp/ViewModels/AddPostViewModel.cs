using SampleMyApp.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
   public class AddPostViewModel:BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public PostData PostData { get; set; }
        public ICommand OnAddPost { get; set; }
        public AddPostViewModel(INavigation navigation)
        {
            Navigation = navigation;
            PostData = new PostData
            {
                userId = 1
            };
            OnAddPost = new Command(async () => await AddPostData()); 

        }
        public async Task AddPostData() {
            await App.RequestManager.SavePostAsync(PostData,true);
            await Navigation.PopAsync();

        }
   }
   }
