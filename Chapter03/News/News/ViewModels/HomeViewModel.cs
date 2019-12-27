using System;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using News.Models;
using News.Services;
using News.Views;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly NewsService newsService;

        public HomeViewModel(NewsService newsService)
        {
            this.newsService = newsService;

            Task.Run(Initialize);
        }

        public async Task Initialize()
        {
            CurrentNews = await newsService.GetNews(NewsScope.Headlines);
        }

        public NewsResult CurrentNews { get; set; }

        public ICommand SelectionChanged
            => new Command(async (selectedItem) =>
            {
                var selectedArticle = selectedItem as Article;
                var url = HttpUtility.UrlEncode(selectedArticle.Url);
                await Navigation.NavigateTo($"articleview?url={url}");
            });
    }
}
