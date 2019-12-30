using System;
using System.Collections.Generic;
using GalleryApp.ViewModels;
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

        public void Selection_Changed(object sender, EventArgs e)
        {
            if(selectToolBarItem == null && Photos.SelectedItems.Count > 0)
            {
                selectToolBarItem = new ToolbarItem();

                selectToolBarItem.Command = ViewModel.AddFavorites;

                ToolbarItems.Add(selectToolBarItem);
            }

            if(Photos.SelectedItems.Count > 0)
            {
                selectToolBarItem.Text = $"Select ({Photos.SelectedItems.Count})";
            }
            else if(ToolbarItems.Count > 0)
            {  
                ToolbarItems.Remove(selectToolBarItem);
                selectToolBarItem = null;
            }
        }
    }
}
