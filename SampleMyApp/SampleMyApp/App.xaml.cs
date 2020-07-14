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
            RequestManager = new WebRequestManager();
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Login());

            }
            else
            {
                MainPage = new NavigationPage(new Dashboard());

            }

        }
      


        protected  override void OnStart()
        {
            //fetch and save data locally
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
