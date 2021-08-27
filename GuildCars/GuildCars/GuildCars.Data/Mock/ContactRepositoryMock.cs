using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class ContactRepositoryMock : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact
            {ContactId = 1, Name = "John Smith", Email = "johnsmith@email.com", Phone = "555-555-5555", Message = "Hello, I would like one car please!", VINNumber = "3MZBM1U76FM220997"}
        };

        public static void Initialize()
        {
            _contacts = new List<Contact>
            {
                new Contact
                {ContactId = 1, Name = "John Smith", Email = "johnsmith@email.com", Phone = "555-555-5555", Message = "Hello, I would like one car please!", VINNumber = "3MZBM1U76FM220997"}
            };
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public void Insert(Contact newContact)
        {
            if (_contacts.Any())
            {
                newContact.ContactId = _contacts.Max(m => m.ContactId) + 1;
            }
            else
            {
                newContact.ContactId = 1;
            }
            _contacts.Add(newContact);
        }
    }
}
