using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Foundation;
using GalleryApp.Models;
using Photos;
using System.Linq;
using System.Collections.Generic;

namespace GalleryApp.iOS
{
    public class PhotoImporter : IPhotoImporter
    {
        private PHAsset[] results;

        public async Task<ObservableCollection<Photo>> Get(int start, int count)
        {
            if (results == null)
            {
                await Import();
            }

            var photos = new ObservableCollection<Photo>();

            var options = new PHImageRequestOptions()
            {
                NetworkAccessAllowed = true,
                DeliveryMode = PHImageRequestOptionsDeliveryMode.FastFormat
            };

            Index startIndex = start;
            Index endIndex = start + count;

            

            if(endIndex.Value >= results.Length)
            {
                endIndex = results.Length - 1;
            }

            if (startIndex.Value > endIndex.Value)
            {
                return new ObservableCollection<Photo>();
            }

            foreach (PHAsset asset in results[startIndex..endIndex])
            {
                var filename = (NSString)asset.ValueForKey((NSString)"filename");

                PHImageManager.DefaultManager.RequestImageForAsset(asset, PHImageManager.MaximumSize, PHImageContentMode.AspectFill, options, (image, info) =>
                {
                    using (NSData imageData = image.AsPNG())
                    {
                        var bytes = new Byte[imageData.Length];
                        System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, bytes, 0, Convert.ToInt32(imageData.Length));

                        var photo = new Photo()
                        {
                            Bytes = bytes,
                            Filename = filename
                        };

                        photos.Add(photo);

                    }
                });
            }

            return photos;
        }

        public async Task<ObservableCollection<Photo>> Import()
        {
            var status = await PHPhotoLibrary.RequestAuthorizationAsync();

            if (status != PHAuthorizationStatus.Authorized)
            {
                return new ObservableCollection<Photo>();
            }

            results = PHAsset.FetchAssets(PHAssetMediaType.Image, null).Select(x => (PHAsset)x).ToArray();

            return await Get(0, 20);
        }
    }
}
