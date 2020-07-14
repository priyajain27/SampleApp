using SampleMyApp.Models;
using SampleMyApp.Utility;
using SampleMyApp.ViewModels;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Post : ToolBarItems
    {
        readonly PostViewModel ViewModel;

        public Post()
        {

            InitializeComponent();
            BindingContext = ViewModel = new PostViewModel(Navigation);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
       
    }
}