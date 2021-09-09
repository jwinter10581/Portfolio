using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;

namespace ContactList.UI
{
    public class UserInterface
    {
        private UserIO userIO;

        public UserInterface()
        {
            userIO = new UserIO();
        }

        public int ShowMenuAndGetUserChoice()
        {
            Console.WriteLine("\nEnter a choice from the menu below:");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. Show All Contacts");
            Console.WriteLine("3. Look Up Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Remove Contact");
            Console.WriteLine("6. Exit Program");

            // call ReadInt method, supply prompt, min, and max values
            int userChoice = userIO.ReadInt("Enter your choice: ", 1, 6);

            return userChoice;
        }

        public Contact GetNewContactInformation()
        {
            Contact contact = new Contact();

            contact.FirstName = userIO.ReadString("\nEnter the contact's first name: ");
            contact.LastName = userIO.ReadString("Enter the contact's last name: ");
            contact.Email = userIO.ReadString("Enter the contact's email adress: ");
            contact.PhoneNumber = userIO.ReadString("Enter the contact's phone number: ");

            return contact;
        }

        public void DisplayContact (Contact contact)
        {
            Console.WriteLine($"\nContact ID:   {contact.ContactID}");
            Console.WriteLine($"First Name:   {contact.FirstName}");
            Console.WriteLine($"Last Name:    {contact.LastName}");
            Console.WriteLine($"Email:        {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
        }

        public void ShowActionSuccess (string actionName)
        {
            Console.WriteLine($"\n{actionName} executed successfully!");
        }

        public void ShowActionFailure (string actionName)
        {
            Console.WriteLine($"\n{actionName} failed to execute properly!");
        }
    }
}
