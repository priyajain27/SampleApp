using System;
using Xamarin.Forms;

namespace SampleMyApp.Utility
{
    public class ToolBarItems : ContentPage
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
        public ToolBarItems()
        {
            Init();
        }

        private void Init()
        {
            this.ToolbarItems.Add(new ToolbarItem() { Text = Name, Priority = 0, Order = ToolbarItemOrder.Primary });
            this.ToolbarItems.Add(new ToolbarItem() { IconImageSource = Picture, Priority = 0, Order = ToolbarItemOrder.Primary });
        }

    }
}
