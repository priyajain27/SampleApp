using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SampleMyApp.Models
{
    class WidgetData:BaseViewModel
    {
        private int _postCount;

        public string Name { get; set; }

        public int PostCount
        {
            get
            {
                return _postCount;
            }
            set
            {
                _postCount = value;
                OnPropertyChanged("PostCount");
            }
        }


       // public int PostCount { get; set; }


        
    public bool IsBadgeVisible { get; set; }
        
    }
}
