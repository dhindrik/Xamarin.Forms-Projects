using System;
using System.Threading.Tasks;
using System.Windows.Input;
using News.Models;
using News.Services;
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
            CurrentNews = await newsService.GetNews();
        }

        public NewsResult CurrentNews { get; set; }

        public Article SelectedItem { get; set; }

        public ICommand SelectionChanged
            => new Command(() =>
            {
                var item = SelectedItem;
                int i = 42;
            });
    }
}
