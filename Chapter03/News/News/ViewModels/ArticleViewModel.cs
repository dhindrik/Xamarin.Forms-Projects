using System;
using News.Models;

namespace News.ViewModels
{
    public class ArticleViewModel : ViewModel
    {
        public Article Article { get; }

        public ArticleViewModel(Article article)
        {
            Article = article;
        }

        public static ArticleViewModel FromArticle(Article article)
            => new ArticleViewModel(article);
    }
}
