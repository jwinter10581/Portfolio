using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;

namespace ContactList.Data
{
    public class ContactRepository
    {
        Contact[] contacts;
        public ContactRepository()
        {
            contacts = new Contact[10];

            Contact contact1 = new Contact();
            contact1.ContactID = 0;
            contact1.FirstName = "Bill";
            contact1.LastName = "Gates";
            contact1.PhoneNumber = "605-555-1234";

            contacts[0] = contact1;

            Contact contact2 = new Contact();
            contact2.ContactID = 1;
            contact2.FirstName = "Elon";
            contact2.LastName = "Musk";
            contact2.PhoneNumber = "605-555-1235";

            contacts[1] = contact2;
        }

        public Contact CreateContact(Contact contact)
        {
            for (int i = 0; i < contacts.Length; i++)  // find the first open slot in the contacts array
            {
                if (contacts[i] == null)
                {
                    contact.ContactID = i; // Set the id for the contact

                    contacts[i] = contact; // add the contact to the list
                    return contact;
                }
            }

            return null;  // if it iterates through the whole array and returns null if full
        }

        public Contact[] RetrieveAllContacts()
        {
            return contacts;
        }

        public Contact RetrieveContactByID(int contactID)
        {
            return contacts[contactID];
        }

        public void DeleteContact(int contactID)
        {
            contacts[contactID] = null;
        }

        public Contact EditContact(Contact contact)
        {
            DeleteContact(contact.ContactID); // remove contact with the ID from the array
            Contact updatedContact = CreateContact(contact);
            return updatedContact;
        }
    }
}
