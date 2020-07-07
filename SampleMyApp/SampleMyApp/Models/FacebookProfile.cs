using Newtonsoft.Json;
using SampleMyApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FacebookClientSample
{
    public class FacebookProfile :BaseViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Uri Picture { get; set; }
}
   
}
