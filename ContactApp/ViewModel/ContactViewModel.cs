using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Annotations;
using ContactApp.Model;
//using Contact = Windows.ApplicationModel.Contacts.Contact;

namespace ContactApp.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private Contact _domainObject;
        private ContactCatalog _contactCatalog;
        private Contact _selectedContact;
        private DeleteCommand _deletionCommand;


        public ContactViewModel()
        {
            _contactCatalog = new ContactCatalog();
            DomainObject();
            _selectedContact = null;
            _deletionCommand = new DeleteCommand(_contactCatalog, this);
        }

        public void DomainObject()
        {
            foreach (var c in _contactCatalog.Contacts)
            {
                _domainObject = c;
            }
        }

        public Contact SelectedContact
        {
            get
            {
                return _selectedContact;
            }

            set
            {
                _selectedContact = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteCommand DeletionCommand
        {
            get { return _deletionCommand; }
        }

        public ObservableCollection<Contact> ContactsCollection
        {
            get { return _contactCatalog.Contacts; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
