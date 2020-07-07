using SampleMyApp.Themes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleMyApp.ViewModels
{
    class SettingsViewModel:BaseViewModel
    {
        private bool _isSwitchToggled = false;
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        public bool IsSwitchedToggled
        {
            get { return _isSwitchToggled; }
            set
            {
                _isSwitchToggled = value;
            }
        }
        public ICommand SwitchCommand { get; set; }

        public SettingsViewModel() 
        {
           SwitchCommand = new Command(ChangeTheme);

            

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
