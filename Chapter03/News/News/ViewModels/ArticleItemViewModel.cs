using System;
using System.Web;
using System.Windows.Input;
using News.Models;
using News.ViewModels;
using Xamarin.Forms;

namespace News.Models
{
    //// Istället för att skapa en vymodell, men detta känns helt fel :)
    //public partial class Article
    //{
    //    public ICommand ViewArticle => new Command(async (item) =>
    //    {
    //        var selectedArticle = item as Article;
    //        var url = HttpUtility.UrlEncode(selectedArticle.Url);

    //        var navigator = new Navigator();
    //        await navigator.NavigateTo($"articleview?url={url}");
    //    });
    //}
}
