using Newtonsoft.Json.Linq;
using Plugin.FacebookClient;
using Plugin.GoogleClient;
using SampleMyApp.Models;
using SampleMyApp.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    public class LoginViewModel 
    {
        string[] permisions = new string[] { "email", "public_profile" , "user_posts" };
        IGoogleClientManager _googleService = CrossGoogleClient.Current;


        public SocialNetworkAuthData Profile { get; set; }
        public Command OnLoginCommand { get; set; }
		public Command OnLoadDataCommand { get; set; }
		public Command OnLogoutCommand { get; set; }
        public bool IsLoggedIn { get; set; } = false;
        public ObservableCollection<AuthNetwork> AuthenticationNetworks { get; set; } = new ObservableCollection<AuthNetwork>()
        {
            new AuthNetwork()
            {
                Name = "Facebook",
                Icon = "ic_fb",
                Foreground = "#FFFFFF",
                Background = "#4768AD"
            },

              new AuthNetwork()
            {
                Name = "Google",
                Icon = "google_icon",
                Foreground = "#000000",
                Background ="#F8F8F8"
            }
        };

        public LoginViewModel()
        {

			Profile = new SocialNetworkAuthData();

            // OnLoginCommand = new Command(async()=> await LoginAsync());
            OnLoginCommand = new Command<AuthNetwork>(async (data) => await LoginAsync(data));

            OnLoadDataCommand = new Command(async () => await LoadData());
           

	
        }
        async Task LoginAsync(AuthNetwork authNetwork)
        {
            switch (authNetwork.Name)
            {
                case "Facebook":
                    await LoginFacebookAsync(authNetwork);

                    break;

                case "Google":
                   // await LoginGoogleAsync(authNetwork);
                    break;
            }
        }
        async Task LoginFacebookAsync(AuthNetwork authNetwork)
        {
            FacebookResponse<bool> response = await CrossFacebookClient.Current.LoginAsync(permisions);
            switch(response.Status)
            {
                case FacebookActionStatus.Completed:
					IsLoggedIn = true;
					OnLoadDataCommand.Execute(null);

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
            Profile = new SocialNetworkAuthData()
            {
                FullName = data["name"].ToString(),
                Picture = $"{data["picture"]["data"]["url"]}",
                Email = data["email"].ToString()
            };
            OnLoginSuccess(Profile);
             var login = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Login");
                          {
                              if (login != null)
                              {

                                   App.Current.MainPage.Navigation.InsertPageBefore(new Dashboard(), login);
                                  await App.Current.MainPage.Navigation.PopAsync();
                                 // App.Current.MainPage.Navigation.RemovePage(login);

                              }
                          }
           // await App.Current.MainPage.Navigation.PushModalAsync(new Dashboard());

        }

       /* async Task LoginGoogleAsync(AuthNetwork authNetwork)
        {
            try
            {
                /* if (!string.IsNullOrEmpty(_googleService.ActiveToken))
                 {
                     //Always require user authentication
                     _googleService.Logout();
                 }
              //  GoogleResponse<GoogleUser> response = await CrossGoogleClient.Current.LoginAsync();

               EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;
               userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
                {
                    switch (e.Status)
                    {
                        case GoogleActionStatus.Completed:
#if DEBUG
                            var googleUserString = JsonConvert.SerializeObject(e.Data);
                         //   Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
#endif

                            var socialLoginData = new SocialNetworkAuthData
                            {
                                Id = e.Data.Id,
                               // Logo = authNetwork.Icon,
                                Foreground = authNetwork.Foreground,
                                Background = authNetwork.Background,
                                Picture = e.Data.Picture.AbsoluteUri,
                               // Name = response.Data.Name,
                            };

                            await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                            break;
                        case GoogleActionStatus.Canceled:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Canceled", "Ok");
                            break;
                        case GoogleActionStatus.Error:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Error", "Ok");
                            break;
                        case GoogleActionStatus.Unauthorized:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Unauthorized", "Ok");
                            break;
                    }
                    _googleService.OnLogin -= userLoginDelegate;

                };

                _googleService.OnLogin += userLoginDelegate;

                await _googleService.LoginAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }*/




        public void OnLoginSuccess(SocialNetworkAuthData socialLoginData)
        {
            Application.Current.Properties["IsUserLoggedIn"] = IsLoggedIn;
            Application.Current.Properties["Picture"] = socialLoginData.Picture;
            Application.Current.Properties["Name"] = socialLoginData.FullName;
            Application.Current.Properties["Email"] = socialLoginData.Email;

        }
    }
   
}
