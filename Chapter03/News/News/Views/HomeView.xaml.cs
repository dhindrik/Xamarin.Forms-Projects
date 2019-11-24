using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.ViewModels;
using Xamarin.Forms;

namespace News.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = Resolver.Resolve<HomeViewModel>();
        }
    }
}
