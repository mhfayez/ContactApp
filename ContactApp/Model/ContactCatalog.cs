using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
//C:\Users\Homayoon\AppData\Local\Packages\ae82ddaf-6f69-4ff5-9c1b-fddb15b4a9b8_wys1rpvef35kg\LocalState
namespace ContactApp.Model
{
    public class ContactCatalog
    {
        private const string FileName = "contactsList.txt";
        readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
        private static ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();

        public ObservableCollection<Contact> Contacts => _contacts;

        public async void AddContact(Contact c)
        {
            _contacts.Add(c);
            string json = JsonConvert.SerializeObject(_contacts);
            await FileIO.WriteTextAsync(await OpenOrCreateFile(), json);
        }

        public async Task LoadDomainObjects()
        {
            string contacts = await FileIO.ReadTextAsync(await OpenOrCreateFile());
            _contacts = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(contacts);
        }

        public async void Delete(string phone)
        {
            var contact = _contacts.FirstOrDefault(c => c.Phone == phone);
            _contacts.Remove(contact);
            string json = JsonConvert.SerializeObject(_contacts);
            await FileIO.WriteTextAsync(await OpenOrCreateFile(), json);
        }

        public async Task<StorageFile> OpenOrCreateFile()
        {
            return await _storageFolder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
        }

    }
}
