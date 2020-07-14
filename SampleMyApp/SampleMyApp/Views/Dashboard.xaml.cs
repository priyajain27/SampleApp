using Plugin.FacebookClient;
using SampleMyApp.Utility;
using SampleMyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ToolBarItems
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