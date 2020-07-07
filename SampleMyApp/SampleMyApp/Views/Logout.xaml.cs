using Plugin.FacebookClient;
using Plugin.GoogleClient;
using SampleMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Logout : ContentPage
    {
        
        public Logout()
        {
            InitializeComponent();

            OnLogout();

        }
       
        async void OnLogout()
        {
            
            CrossFacebookClient.Current.Logout();
            Application.Current.Properties["IsUserLoggedIn"] = false;
            Application.Current.Properties.Remove("Picture");
            Application.Current.Properties.Remove("Name");
            await Navigation.PushModalAsync(new Login());

        }
    }
}