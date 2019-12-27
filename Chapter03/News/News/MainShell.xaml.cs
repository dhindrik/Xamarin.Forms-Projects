using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using News.ViewModels;
using News.Views;
using Xamarin.Forms;

namespace News
{
    public partial class MainShell
    {
        public MainShell()
        {
            InitializeComponent();
           // BindingContext = viewModel;

            Routing.RegisterRoute("articleview", typeof(ArticleView));
        }
    }
        
    public class Navigator : INavigate
    {
        public async Task NavigateTo(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task PushModal(Page page)
        {
            await Shell.Current.Navigation.PushModalAsync(page);
        }

        public async Task PopModal()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
