using SampleMyApp.Models;
using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace SampleMyApp.Views
{
    public partial class MasterDetailPage : ContentPage
    {

        public List<NavigationMenuItem> MenuList
        {
            get;
            set;
        }

        public MasterDetailPage()
        {
            InitializeComponent();
            MenuList = new List<NavigationMenuItem>()
            // Adding menu items to menuList and you can define title ,page and icon  
            {

                new NavigationMenuItem()
                {
                    Title = "Dashboard",
                    TargetType = typeof(Dashboard)

                },
                new NavigationMenuItem()
                {
                    Title = "Profile",
                    TargetType = typeof(Profile)


                },
               new NavigationMenuItem()
                {
                    Title = "Current Location",
                    TargetType = typeof(LocationManager)


                },
             new NavigationMenuItem()
                {
                    Title = "Logout",
                    TargetType = typeof(Logout)


                }

            };

            navigationDrawerList.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page  
            navigationDrawerList.SelectedItem = MenuList[0];

           
        }


    }
}