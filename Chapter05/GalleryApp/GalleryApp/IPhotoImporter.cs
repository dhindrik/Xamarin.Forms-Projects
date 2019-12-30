using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalleryApp.Models;

namespace GalleryApp
{
    public interface IPhotoImporter
    {
        Task<ObservableCollection<Photo>> Import();
        Task<ObservableCollection<Photo>> Get(int startIndex, int count);
    }
}
