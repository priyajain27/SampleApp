using SampleMyApp.Models;
using SampleMyApp.ViewModels;
using SampleMyApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public List<PostData> PostList { get; set; }
        public IList<WidgetsData> WidgetsData { get; set; }

        public object SelectedItem { get; set; }

        public Command<SelectedItemChangedEventArgs> OnItemSelectedCommand { get; set; }

        public ICommand ProfileImageCommand { get; set; }
        public ICommand FetchPostDataCommand { get; set; }


        public string Name
         {
             get
             {
                 if (Application.Current.Properties.ContainsKey("Name"))
                 {
                     return Application.Current.Properties["Name"].ToString();
                 }
                 else
                 {
                     return String.Empty;
                 }
             }
         }
         public string Picture
         {
             get
             {
                 if (Application.Current.Properties.ContainsKey("Picture"))
                 {
                     return Application.Current.Properties["Picture"].ToString();
                 }
                 else
                 {
                     return String.Empty;
                 }
             }
         }
       
        public DashboardViewModel(INavigation navigation )
        {
            this.Navigation = navigation;
            SelectedItem = null;

            ProfileImageCommand = new Command(async () => await ProfileDetails()); //toolbar profile image redirection

            WidgetsData = new List<WidgetsData>(); // cardview like navigational widgets on Dashboard
            
            Task.Run(async () => { await FetchPostData(); }).Wait(); //load post data

            GenerateWidgetModel();

            OnItemSelectedCommand = new Command<SelectedItemChangedEventArgs>(NavigateToView);//cardview navigation handling


        }
        public async Task ProfileDetails()
        {
            await Navigation.PushAsync(new Profile());

        }
    async void NavigateToView(SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is WidgetsData item))
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
            }

        }


        private void GenerateWidgetModel()
        {
            string[] arrNames = {
               "Post", "Add Post","Settings"
            };
            for (var i = 0; i < arrNames.Length; i++)
            {
                var widgetData = new WidgetsData()
                {

                    Name = arrNames[i],
                    PostCount = PostList.Count,
                    IsBadgeVisible = i == 0 ? true : false

                };
                WidgetsData.Add(widgetData);

            }

        }
       

        public async Task FetchPostData()
        {
           PostList = await App.RequestManager.GetPostAsync();
        }
    }
}