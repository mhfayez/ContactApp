using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Newtonsoft.Json;

namespace ContactApp.Util
{
    class FilePersistence<T> where T : class
    {
        private const string FileName = "data.json";
        private CreationCollisionOption _options;
        private StorageFolder _folder;

        public FilePersistence()
        {
            _options = CreationCollisionOption.OpenIfExists;
            _folder = ApplicationData.Current.LocalFolder;
        }

        public async Task SaveAsync(List<T> data)
        {
            var dataFile = await _folder.CreateFileAsync(FileName, _options);
            string dataJSON = JsonConvert.SerializeObject(data);
            await FileIO.WriteTextAsync(dataFile, dataJSON);
        }

        public async Task<List<T>> LoadAsync()
        {
            try
            {
                StorageFile dataFile = await _folder.GetFileAsync(FileName);
                string dataJSON = await FileIO.ReadTextAsync(dataFile);
                return (dataJSON != null) ?
                    JsonConvert.DeserializeObject<List<T>>(dataJSON)
                    : new List<T>();
            }
            catch (FileNotFoundException)
            {
                await SaveAsync(new List<T>());
                return new List<T>();
            }
        }

        public async Task<string> PickSingleFileAsync()
        {
            var openPicker = new FileOpenPicker();
            StorageFile file = await openPicker.PickSingleFileAsync();
            string path = "";
            // Process picked file
            if (file != null)
            {
                // Store file for future access
                Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(file);
                await Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.GetFileAsync(file.Name);

               path = file.Path + file.Name;
            }
            else
            {
                path = "image not found";
            }

            return path;
        }

    }
}
