using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleMyApp.Models;
using SampleMyApp.Views;

namespace SampleMyApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.MasterDetailPage
    {
       // readonly Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        MasterDetailPage masterPage;
        public MainPage()
        {
            InitializeComponent();
            
            masterPage = new MasterDetailPage();
            Master = masterPage;
            Detail = new NavigationPage(new Dashboard());

            masterPage.navigationDrawerList.ItemSelected += OnItemSelected;

        }
       
        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.navigationDrawerList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
