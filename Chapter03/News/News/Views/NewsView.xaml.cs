using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.ViewModels;
using Xamarin.Forms;

namespace News.Views
{
    public partial class NewsView : ContentPage
    {
        public NewsView(string scope)
        {
            InitializeComponent();

            var viewModel = Resolver.Resolve<NewsViewModel>();
            BindingContext = viewModel;
            Task.Run(async () => await viewModel.Initialize(scope));
        }
    }
}
