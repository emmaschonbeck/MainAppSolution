

using MainApp.Models;
using System.Text.Json;


namespace MainApp.Services
{
    public class ListContacts
    {

        private readonly ContactRepository contactRepository;
        private readonly ContactDisplayer contactDisplayer;

        public ListContacts(string filePath)
        {
            contactRepository = new ContactRepository(filePath);
            contactDisplayer = new ContactDisplayer();
        }

        public ListContacts() : this("contacts.json") { }


        public void ShowContacts()
        {
            var contacts = contactRepository.LoadContactsFromFile();

            Console.WriteLine("\n================================================");
            Console.WriteLine("                   CONTACTS                     ");
            Console.WriteLine("================================================\n");

            Console.WriteLine("Here is a list of all the contacts:\n");

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts were found.");
                return;
            }

            foreach (var contact in contacts)
            {
                contactDisplayer.DisplayContact(contact);
            }
        }
    }
}
