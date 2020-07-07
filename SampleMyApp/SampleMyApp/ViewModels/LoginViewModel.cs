using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using SampleMyApp.Views;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class LoginViewModel 
    {
        string[] permisions = new string[] { "email", "public_profile" , "user_posts" };

		
        public NetworkAuthData Profile { get; set; }
        public Command OnLoginCommand { get; set; }
		public Command OnLoadDataCommand { get; set; }
		public Command OnLogoutCommand { get; set; }
        public bool IsLoggedIn { get; set; }
        public LoginViewModel()
        {

			Profile = new NetworkAuthData();

            OnLoginCommand = new Command(async()=> await LoginAsync());
			OnLoadDataCommand = new Command(async () => await LoadData());
            //not in use
			/*OnLogoutCommand = new Command( () =>
			{
				if (CrossFacebookClient.Current.IsLoggedIn)
				{
					CrossFacebookClient.Current.Logout();
                    IsLoggedIn = false;
				}
			});*/

	
        }

        async Task LoginAsync()
        {
            FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(permisions);
            switch(response.Status)
            {
                case FacebookActionStatus.Completed:
					IsLoggedIn = true;
					OnLoadDataCommand.Execute(null);
                    await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());

                    break;
                case FacebookActionStatus.Canceled:
                
                    break;
                case FacebookActionStatus.Unauthorized:
                    await App.Current.MainPage.DisplayAlert("Unauthorized", response.Message, "Ok");
                    break;
                case FacebookActionStatus.Error:
                    await App.Current.MainPage.DisplayAlert("Error", response.Message,"Ok");
                    break;
            }

        }

		

        public async Task LoadData()
        {

            var jsonData = await CrossFacebookClient.Current.RequestUserDataAsync
            (
                  new string[] { "id", "name", "email", "picture", "cover", "friends" }, new string[] { }
            );
           
            var data = JObject.Parse(jsonData.Data);
            Profile = new NetworkAuthData()
            {
                FullName = data["name"].ToString(),
                Picture = $"{data["picture"]["data"]["url"]}",
                Email = data["email"].ToString()
            };
            OnLoginSuccess(Profile);

            }

      public void OnLoginSuccess(NetworkAuthData socialLoginData)
        {
            Application.Current.Properties["IsUserLoggedIn"] = IsLoggedIn;
            Application.Current.Properties["Picture"] = socialLoginData.Picture;
            Application.Current.Properties["Name"] = socialLoginData.FullName;
        }
    }
   
}
