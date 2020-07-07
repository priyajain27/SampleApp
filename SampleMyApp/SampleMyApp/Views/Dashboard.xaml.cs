using Plugin.FacebookClient;
using SampleMyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
         readonly DashboardViewModel ViewModel;
        
        
        public Dashboard()
        {
            InitializeComponent();
            BindingContext = ViewModel = new DashboardViewModel(Navigation);
           

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.SelectedItem = null;
        }

    }
}