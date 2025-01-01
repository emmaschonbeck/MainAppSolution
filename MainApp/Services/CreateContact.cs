

using MainApp.Models;
using System.Text.Json;

namespace MainApp.Services
{
    public class CreateContact
    {

        private readonly string filePath = "contacts.json";

        public void ContactCreate()
        {
            var newContact = new Contact();

            // Kod för att skapa kontakter
            Console.WriteLine("Create a new contact below.");
            // Logik för att skapa kontakter

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

            newContact.Id = Guid.NewGuid();

            Console.WriteLine("\nYour contact has been created successfully!");
            Console.WriteLine($"ID: {newContact.Id}");
            
            SaveContactToFile( newContact );
        }

        // Denna kod är genererad av Chat GPT 4o - Denna kod gör...

        private void SaveContactToFile( Contact contact )
        {
            var contacts = LoadContactsFromFile();

            contacts.Add( contact );

            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true } );
            File.WriteAllText(filePath, json);
        }

        private List<Contact> LoadContactsFromFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Contact>();
            }

            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Contact>();
            }

            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
}
