using System;
using System.Collections.Generic;
using News.ViewModels;
using Xamarin.Forms;
using System.Web;

namespace News.Views
{
    [QueryProperty("Url", "url")]
    public partial class ArticleView : ContentPage
    {
        public string Url
        {
            set
            {
                BindingContext = new UrlWebViewSource
                {
                    Url = HttpUtility.UrlDecode(value)
                };
            }
        }

        public ArticleView()
        {
            InitializeComponent();
        }
    }
}
