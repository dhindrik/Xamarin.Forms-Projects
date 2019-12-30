using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GalleryApp
{
    public class FormsLocalStorage : ILocalStorage
    {
        public const string PropertyKey = "FavoritePhotos";

        public async Task<List<string>> Get()
        {
            if (Application.Current.Properties.ContainsKey(PropertyKey))
            {
                var filenames = (List<string>)Application.Current.Properties[PropertyKey];

                return filenames;
            }

            return new List<string>();
        }

        public async Task Store(string filename)
        {
            List<string> filenames;

            if(!Application.Current.Properties.ContainsKey(PropertyKey))
            {
                filenames = new List<string>();
                Application.Current.Properties.Add(PropertyKey, filenames);
            }
            else
            {
                filenames = (List<string>)Application.Current.Properties[PropertyKey];
            }

            filenames.Add(filename);

            Application.Current.Properties[PropertyKey] = filenames;

            await Application.Current.SavePropertiesAsync();
        }
    }
}
