using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListService.Models
{
    public class ContactRepository
    {
        private static List<Contact> _contacts;

        static ContactRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact { FirstName="Ada", LastName="Lovelace", Company="Babbage Industries", Email="ada@babbage.com", Phone="555-555-1212", ContactId=1 },
                new Contact { FirstName="Sally", LastName="Smith", Company="Microsoft", Email="sally@ms.com", Phone="555-345-8756", ContactId=2 },
            };
        }

        public static List<Contact> GetAll()
        {
            return _contacts;
        }

        public static Contact Get(int contactId)
        {
            return _contacts.FirstOrDefault(c => c.ContactId == contactId);
        }

        public static void Create(Contact newContact)
        {
            if(_contacts.Any())
            {
                newContact.ContactId = _contacts.Max(c => c.ContactId) + 1;
            }
            else
            {
                newContact.ContactId = 0;
            }

            _contacts.Add(newContact);
        }

        public static void Update(Contact updatedContact)
        {
            _contacts.RemoveAll(c => c.ContactId == updatedContact.ContactId);
            _contacts.Add(updatedContact);
        }

        public static void Delete(int contactId)
        {
            _contacts.RemoveAll(c => c.ContactId == contactId);
        }
    }
}