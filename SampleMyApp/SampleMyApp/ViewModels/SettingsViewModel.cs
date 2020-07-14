using SampleMyApp.Themes;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class SettingsViewModel:BaseViewModel
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        public bool IsSwitchedToggled { get; set; } = false;
        public ICommand OnSwitchCommand { get; set; }

        public SettingsViewModel() 
        {
            OnSwitchCommand = new Command(ChangeTheme);

            

        }
        public void ChangeTheme() {
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if (IsSwitchedToggled)
                {
                    mergedDictionaries.Add(new DarkTheme());
                }
                else
                    mergedDictionaries.Add(new LightTheme());
            }
        }
    }
}
