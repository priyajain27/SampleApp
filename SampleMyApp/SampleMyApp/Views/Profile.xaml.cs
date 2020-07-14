using SampleMyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {

        public Profile()
        {
            InitializeComponent();
            BindingContext  = new ProfileViewModel();

        }
    }
}