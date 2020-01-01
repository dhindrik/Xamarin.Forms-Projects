using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                var filenames = (string)Application.Current.Properties[PropertyKey];

                return JsonConvert.DeserializeObject<List<string>>(filenames);
            }

            return new List<string>();
        }

        public async Task Store(string filename)
        {
            List<string> filenames = await Get();

            filenames.Add(filename);

            Application.Current.Properties[PropertyKey] = JsonConvert.SerializeObject(filenames);

            await Application.Current.SavePropertiesAsync();
        }
    }
}
