using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMyApp.Models
{
    
    public class NavigationMenuItem
    {
        public string Title { get; set; }
        public Type TargetType { get; internal set; }

    }
}
