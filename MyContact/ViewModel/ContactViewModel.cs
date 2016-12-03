using System.Collections.Generic;
using MyContact.Models;

namespace MyContact.ViewModel
{
    public class ContactViewModel
    {

        public string FirstAlphabet { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}