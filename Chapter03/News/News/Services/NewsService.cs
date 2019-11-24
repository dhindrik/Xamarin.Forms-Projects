using System;
using System.Net;
using System.Threading.Tasks;
using News.Models;

namespace News.Services
{
    public class NewsService
    {
        public async Task<NewsResult> GetNews()
        {
            var url = "https://newsapi.org/v2/top-headlines?" +
                      "country=us&" +
                      $"apiKey={Settings.NewsApiKey}";

            var webclient = new WebClient();
            var json = await webclient.DownloadStringTaskAsync(url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<NewsResult>(json);
        }
    }
}
