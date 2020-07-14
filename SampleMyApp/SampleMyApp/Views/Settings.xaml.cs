
using SampleMyApp.Utility;
using SampleMyApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ToolBarItems
    {
        //  ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        readonly SettingsViewModel ViewModel;

        public Settings()
        {
            InitializeComponent();
            BindingContext = ViewModel = new SettingsViewModel();

        }
        
    }
}