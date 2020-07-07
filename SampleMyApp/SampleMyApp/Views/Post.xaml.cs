using SampleMyApp.ViewModels;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Post : ContentPage
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