

using MainApp.Models;
using System.Text.Json;

namespace MainApp.Services
{
    public class CreateContact
    {

        private readonly ContactRepository contactRepository = new ContactRepository();

        public void ContactCreate()
        {
            var newContact = new Contact();

            Console.WriteLine("Create a new contact below.");

            Console.Write("First name: ");
            newContact.FirstName = Console.ReadLine();

            Console.Write("Last name: ");
            newContact.LastName = Console.ReadLine();

            Console.Write("Email: ");
            newContact.Email = Console.ReadLine();

            Console.Write("Phone Number: ");
            newContact.PhoneNumber = Console.ReadLine();

            Console.Write("Address: ");
            newContact.Address = Console.ReadLine();

            Console.Write("Postal code: ");
            newContact.PostalCode = Console.ReadLine();

            Console.Write("City: ");
            newContact.City = Console.ReadLine();

            Console.WriteLine("\nYour contact has been created successfully!");
            Console.WriteLine($"ID: {newContact.Id}\n");
            
            contactRepository.SaveContactToFile(newContact);
        }
    }
}
