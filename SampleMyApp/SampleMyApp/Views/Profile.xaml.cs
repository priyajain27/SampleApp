using SampleMyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        readonly ProfileViewModel ViewModel;

        public Profile()
        {
            InitializeComponent();
            BindingContext = ViewModel = new ProfileViewModel();

        }
    }
}