using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SampleMyApp.ViewModels
{
    class LocationManagerViewModel
    {
        Xamarin.Forms.Maps.Map map;

        public ICommand CurrentLocationCommand { get; set; }
       
        public LocationManagerViewModel(Xamarin.Forms.Maps.Map map)
        {
            this.map = map;
            CurrentLocationCommand = new Command(async () => await CurrentLocation());


        }
        async Task CurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));

                }
                
                    Pin pin = new Pin
                    {
                        BindingContext = location,
                        Position = new Position(location.Latitude, location.Longitude),
                    };

                    map.Pins.Add(pin);
                
            }
            catch (Exception ex)
            {
               // await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }
        /* currently not in use*/
        public static readonly BindableProperty GetActualLocationCommandProperty =
            BindableProperty.Create(nameof(CurrentLocationCommand), typeof(ICommand), typeof(LocationManagerViewModel), null, BindingMode.TwoWay);
    }
}
