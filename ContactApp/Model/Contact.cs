using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Model
{
    public class Contact
    {
        public Contact(string name, string phone, string country, string imageSource)
        {
            Name = name;
            Phone = phone;
            ImageSource = imageSource;
            Country = country;  
        }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ImageSource { get; set; }
        public string Country { get; set; }
    }
}
