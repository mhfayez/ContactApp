using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Model
{
    public class ContactCatalog
    {
        private Contact _selectedContact;

        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>()
        {
            new Contact("Ann", "12345678", "Canada", "..\\Assets\\ann.jpg"),
            new Contact("Benny", "23456789", "England", "..\\Assets\\benny.jpg"),
            new Contact("Carol", "34567890", "USA", "..\\Assets\\carol.jpg")
        };


        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
        }

        public void Create(Contact c)
        {
            _contacts.Add(c);
        }

        public void Delete(string phone)
        {
           var contact =  _contacts.FirstOrDefault(c => c.Phone == phone);
           _contacts.Remove(contact);
        }

    }
}
