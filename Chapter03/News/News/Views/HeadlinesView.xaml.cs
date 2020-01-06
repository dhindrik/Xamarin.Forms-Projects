using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.Services;
using News.ViewModels;
using Xamarin.Forms;

namespace News.Views
{
    public partial class HeadlinesView : ContentPage
    {
        public HeadlinesView()
        {
            InitializeComponent();
            var viewModel = Resolver.Resolve<NewsViewModel>();

            BindingContext = viewModel;
            Task.Run(async () => await viewModel.Initialize(NewsScope.Headlines));
        }

        public HeadlinesView(string scope)
        {
            InitializeComponent();
            Title = $"{scope} news";

            var viewModel = Resolver.Resolve<NewsViewModel>();
            BindingContext = viewModel;
            Task.Run(async () => await viewModel.Initialize(scope));
        }
    }
}
