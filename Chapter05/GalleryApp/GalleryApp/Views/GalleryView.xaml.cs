using System;
using System.Collections.Generic;
using System.Linq;
using GalleryApp.Models;
using GalleryApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GalleryApp.Views
{
    public partial class GalleryView : ContentPage
    {
        private ToolbarItem selectToolBarItem;

        private GalleryViewModel ViewModel => BindingContext as GalleryViewModel;

        public GalleryView()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<GalleryViewModel>();
        }

        private void SelectToolBarItem_Clicked(object sender, EventArgs e)
        {
            if (!Photos.SelectedItems.Any())
            {
                DisplayAlert("No photos", "No photos selected", "OK");
                return;
            }

            ViewModel.AddFavorites.Execute(Photos.SelectedItems.Select(x => (Photo)x).ToList());

            DisplayAlert("Added", "Selected photos has been added to favorites", "OK");

            Photos.SelectedItems = null;
        }
    }
}
