using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;
using ContactList.Data;
using ContactList.UI;

namespace ContactList.Controller
{
    public class ContactController
    {
        private UserInterface userInterface;
        private ContactRepository repository;
        private UserIO userIO;

        public ContactController()
        {
            userInterface = new UserInterface();
            repository = new ContactRepository();
            userIO = new UserIO();
        }

        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                int menuChoice = userInterface.ShowMenuAndGetUserChoice();

                switch (menuChoice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ShowAllContacts();
                        break;
                    case 3:
                        SearchContact();
                        break;
                    case 4:
                        EditContact();
                        break;
                    case 5:
                        DeleteContact();
                        break;
                    case 6:
                        //Exit Application
                        keepRunning = false;
                        break;
                }
            }
        }

        private void AddContact()
        {
            Contact newContact = userInterface.GetNewContactInformation();
            Contact addedContact = repository.CreateContact(newContact);

            if (addedContact != null) // Successfully added to the repository
            {
                // Show the new contact, including the ID that came from the repository
                userInterface.DisplayContact(addedContact);

                userInterface.ShowActionSuccess("Add Contact");
            }
            else // Failed to add to repository
            {
                userInterface.ShowActionFailure("Add Contact");
            }
        }

        private void ShowAllContacts()
        {
            Contact[] contacts = repository.RetrieveAllContacts();

            for (int c = 0; c < contacts.Length; c++)
            {
                if(contacts[c] == null)
                {
                    //userInterface.ShowActionFailure("Show all Contacts");
                    break;
                }
                else
                {
                    userInterface.DisplayContact(contacts[c]);
                    //userInterface.ShowActionSuccess("Show all Contacts");
                }
            }
            userInterface.ShowActionSuccess("Show All Contacts");
        }

        private void SearchContact()
        {
            int contactNumber = userIO.ReadInt("Which contact would you like to see?", 0, 9); // choose a contactID to search by
            Contact contactRequested = repository.RetrieveContactByID(contactNumber); // use ID to retrieve a contact

            if (contactRequested == null)
            {
                userInterface.ShowActionFailure("Search Contact");
            }
            else
            { 
                userInterface.DisplayContact(contactRequested); // display contact
                userInterface.ShowActionSuccess("Search Contact");
            }
        }

        private void EditContact()
        {
            int contactNumber = userIO.ReadInt("Which contact would you like to edit?", 0, 9);
            Contact contactEdited = repository.RetrieveContactByID(contactNumber);

            if(contactEdited == null)
            {
                userInterface.ShowActionFailure("Edit Contact");
            }
            else
            {
                contactEdited = userInterface.GetNewContactInformation();
                contactEdited.ContactID = contactNumber;
                repository.EditContact(contactEdited);
                userInterface.ShowActionSuccess("Edit Contact");
            }
        }

        private void DeleteContact()
        {
            int contactNumber = userIO.ReadInt("Which contact would you like to delete?", 0, 9);
            Contact contactDeleted = repository.RetrieveContactByID(contactNumber);

            if(contactDeleted == null)
            {
                userInterface.ShowActionFailure("Delete Contact");
            }
            else
            {
                repository.DeleteContact(contactNumber);
                userInterface.ShowActionSuccess("Delete Contact");
            }
        }
    }
}
