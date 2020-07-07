using SampleMyApp.Services;
using SampleMyApp.Utility;
using SampleMyApp.Views;
using Xamarin.Forms;


namespace SampleMyApp
{
    public partial class App : Application
    {
        public static WebRequestManager RequestManager { get;  set; }
        public static bool IsUserLoggedIn
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
                {
                    return (bool)Application.Current.Properties["IsUserLoggedIn"];
                }
                else {
                    return false;
                }
            }
        }
        public App()
        {
            InitializeComponent();
            RequestManager = new WebRequestManager(new RestService());
            MainPage = new MainPage();
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Login());

            }
            else
            {
                MainPage = new MainPage();

            }

        }

       

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
