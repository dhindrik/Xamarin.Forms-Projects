using System;
using System.Threading.Tasks;
using System.Windows.Input;
using News.Models;
using News.Services;
using Xamarin.Forms;

namespace News.ViewModels
{
    public class NewsViewModel : ViewModel
    {
        private readonly NewsService newsService;

        public NewsViewModel(NewsService newsService)
        {
            this.newsService = newsService;
        }

        public async Task Initialize(string scope)
        {
            var resolvedScope = scope.ToLower() switch
            {
                "local" => NewsScope.Local,
                "global" => NewsScope.Global,
                _ => NewsScope.Headlines
            };

            CurrentNews = await newsService.GetNews(resolvedScope);
        }

        public NewsResult CurrentNews { get; set; }

        public Article SelectedItem { get; set; }

        public ICommand SelectionChanged
            => new Command(() =>
            {
                var item = SelectedItem;
            });
    }
}
