using Plugin.FacebookClient;
using SampleMyApp.Models;
using SampleMyApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public List<PostData> PostList { get; set; }
        public IList<WidgetData> WidgetData { get; set; }

        public object SelectedItem { get; set; }
        public ICommand OnLogoutClick { get; set; }

        public Command<SelectedItemChangedEventArgs> OnItemSelectedCommand { get; set; }

        public DashboardViewModel(INavigation navigation )
        {
            this.Navigation = navigation;
            SelectedItem = null;

           // ProfileImageCommand = new Command(async () => await ProfileDetails()); //toolbar profile image redirection
            OnLogoutClick = new Command(OnLogout);
            WidgetData = new List<WidgetData>(); // cardview like navigational widgets on Dashboard

            Task.Run(async () => { await FetchPostData(); }).Wait(); //load post data

            GenerateWidgetModel();

            OnItemSelectedCommand = new Command<SelectedItemChangedEventArgs>(NavigateToView);//cardview navigation handling


        }
        public async void OnLogout()
        {
            if (CrossFacebookClient.Current.IsLoggedIn)
            {
                CrossFacebookClient.Current.Logout();
            }

            Application.Current.Properties["IsUserLoggedIn"] = false;
            Application.Current.Properties.Remove("Picture");
            Application.Current.Properties.Remove("Name");
            PopUntilDestination(typeof(Dashboard));  //pop until first page on Navigational stack
            var dashboard = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Dashboard");
            {
                if (dashboard != null)
                {

                    App.Current.MainPage.Navigation.InsertPageBefore(new Login(), dashboard);
                    await Navigation.PopAsync();

                }
            }


        }
        
        async void NavigateToView(SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is WidgetData item))
                return;
            
            switch (item?.Name)
            {
                case "Post":
                    await Navigation.PushAsync(new Post());
                    break;

                case "Settings":
                    await Navigation.PushAsync(new Settings());
                    break;
                case "Add Post":
                    await Navigation.PushAsync(new AddPost());
                    break;
                case "Location":
                    await Navigation.PushAsync(new LocationManager());
                    break;
                case "Profile":
                    await Navigation.PushAsync(new Profile());
                    break;
            }

        }


        private void GenerateWidgetModel()
        {
            string[] arrWidget = {
               "Post", "Add Post","Profile","Settings","Location"
            };
            for (var i = 0; i < arrWidget.Length; i++)
            {
                var widgetData = new WidgetData()
                {

                    Name = arrWidget[i],
                    PostCount = PostList.Count,
                    IsBadgeVisible = i == 0 ? true : false

                };
                WidgetData.Add(widgetData);

            }

        }
       

        public async Task FetchPostData()
        {

            PostList = await App.RequestManager.GetPostAsync();
            

        }
       
        void PopUntilDestination(Type DestinationPage)
        {
            int LeastFoundIndex = 0;
            int PagesToRemove = 0;

            for (int index = Navigation.NavigationStack.Count - 2; index > 0; index--)
            {
                if (Navigation.NavigationStack[index].GetType().Equals(DestinationPage))
                {
                    break;
                }
                else
                {
                    LeastFoundIndex = index;
                    PagesToRemove++;
                }
            }

            for (int index = 0; index < PagesToRemove; index++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[LeastFoundIndex]);
            }

            Navigation.PopAsync();
        }
        
    }
}