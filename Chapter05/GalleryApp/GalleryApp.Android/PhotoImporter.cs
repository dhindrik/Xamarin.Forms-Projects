using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Android.Provider;
using Android.Support.V4.View;
using GalleryApp.Models;

namespace GalleryApp.Droid
{
    public class PhotoImporter : IPhotoImporter
    {
        private string[] result; 

        public async Task<ObservableCollection<Photo>> Get(int start, int count, Quality quality = Quality.Low)
        {

            if(result == null)
            {
                Import();
            }

            Index startIndex = start;
            Index endIndex = start + count;

            if (endIndex.Value >= result.Length)
            {
                endIndex = result.Length - 1;
            }

            if (startIndex.Value > endIndex.Value)
            {
                return new ObservableCollection<Photo>();
            }

            var photos = new ObservableCollection<Photo>();

            foreach (var path in result[startIndex..endIndex])
            {
                var filename = Path.GetFileName(path);

                var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

                var memoryStream = new MemoryStream();

                stream.CopyTo(memoryStream);

                var photo = new Photo()
                {
                    Bytes = memoryStream.ToArray(),
                    Filename = filename
                };

                photos.Add(photo);
            }

            return photos;
        }

        public Task<ObservableCollection<Photo>> Get(List<string> filenames, Quality quality = Quality.Low)
        {
            throw new NotImplementedException();
        }

        private void Import()
        {
            Android.Net.Uri imageUri = MediaStore.Images.Media.ExternalContentUri;
            var cursor = MainActivity.Current.ContentResolver.Query(imageUri, null, MediaStore.Images.ImageColumns.MimeType + "=? or " + MediaStore.Images.ImageColumns.MimeType + "=?", new string[] { "image/jpeg", "image/png" }, MediaStore.Images.ImageColumns.DateModified);

            var paths = new List<string>();

            while (cursor.MoveToNext())
            {
                string path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data));

                paths.Add(path);
            }

            result = paths.ToArray();
        }
    }
}
