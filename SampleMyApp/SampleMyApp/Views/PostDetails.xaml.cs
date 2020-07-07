using SampleMyApp.Models;
using SampleMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleMyApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetails : ContentPage
    {
        readonly PostDetailsViewModel ViewModel;
        public PostDetails(PostDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = viewModel;
        }
        public PostDetails()
        {
            InitializeComponent();
            BindingContext = ViewModel = new PostDetailsViewModel();

        }
      
    }
}