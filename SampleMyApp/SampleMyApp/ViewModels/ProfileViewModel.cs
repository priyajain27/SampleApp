using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class ProfileViewModel
    {
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
        public string Logo
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Logo"))
                {
                    return Application.Current.Properties["Logo"].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
        }

    }
}
