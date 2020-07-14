using SampleMyApp.Utility;
using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationManager : ToolBarItems
    {
        LocationManagerViewModel ViewModel;
        public LocationManager()
        {
            InitializeComponent();
            BindingContext = ViewModel = new LocationManagerViewModel(map);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.CurrentLocationCommand.Execute(null);

        }

    }
}



