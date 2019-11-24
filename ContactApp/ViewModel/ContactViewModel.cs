using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Annotations;
using ContactApp.Model;
using UWP_MVVM_Weather.Common;

//using Contact = Windows.ApplicationModel.Contacts.Contact;

namespace ContactApp.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private Contact _domainObject;
        private readonly ContactCatalog _contactCatalog;
        private Contact _selectedContact;
        private readonly DeleteCommand _deletionCommand;
        private string _imageSource;
        
        public ContactViewModel()
        {
            _contactCatalog = new ContactCatalog();
            GetDomainObjects();
            _selectedContact = null;
            AddContactCommand = new RelayCommand(AddContact);
            _deletionCommand = new DeleteCommand(_contactCatalog, this);
        }

        public ICommand AddContactCommand { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }

        public string ImageSource
        {
            get => _imageSource;
            set => _imageSource = "..\\Assets\\" + value;
        }

        

        public void GetDomainObjects()
        {
            foreach (var c in _contactCatalog.Contacts)
            {
                _domainObject = c;
            }
        }

        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteCommand DeletionCommand => _deletionCommand;

        public ObservableCollection<Contact> ContactsCollection => _contactCatalog.Contacts;
       
        public void AddContact()
        {
            _contactCatalog.AddContact(new Contact(Name, Phone, Country, ImageSource));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
