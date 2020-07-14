using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPost : ContentPage
    {

        public AddPost()
        {
            InitializeComponent();
            BindingContext = new AddPostViewModel(Navigation);

        }
    }
}