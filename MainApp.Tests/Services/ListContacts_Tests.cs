
using MainApp.Models;
using MainApp.Services;
using System.Text.Json;

namespace MainApp.Tests.Services
{
    public class ListContacts_Tests
    {

        /*
         Detta är genererat av Chat GPT 4o - Detta testet kontrollerar att metoden ShowContacts hanterar fallet där inga kontakter existerar. För att testa detta så skapas en testfil som innehåller en tom lista ( [] )
         Sedan omdirigeras konsolutmatningen till en StringWriter för att kunna fånga det som skrivs ut på konsolen. När denna metoden då anropas, i fallet där inga kontakter finns, så förväntas den skriva ut
         "No contacts were found.". Därefter kontrollerar testet att detta meddelande finns i konsolutmatningen. Till sist så återställs konsolutmatningen till standard och testfilen som tidigare skapades
         tas nu bort för att hålla systemet rent.
         */

        [Fact]

        public void ShowContacts_NoContacts_FindsNoContactsMessage()
        {

            var testFilePath = "empty_contacts_test.json";
            var listContacts = new ListContacts(testFilePath);

            try
            {

                Console.SetOut(Console.Out);

                File.WriteAllText(testFilePath, "[]");

                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    listContacts.ShowContacts();

                    var result = sw.ToString();
                    Assert.Contains("No contacts were found.", result);
                }
            }
            finally
            {
                Console.SetOut(Console.Out);

                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }

        [Fact]

        public void ShowContacts_WithContacts_DisplaysContactInformation()
        {
            var contacts = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Contact { FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" }
            };

            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            var testFilePath = "test_contacts.json";
            
            try
            {
                File.WriteAllText(testFilePath, json);

                var listContacts = new ListContacts(testFilePath);

                using (var sw = new StringWriter())
                {
                    Console.SetOut(sw);

                    listContacts.ShowContacts();

                    var result = sw.ToString();
                    Assert.Contains("John", result);
                    Assert.Contains("Doe", result);
                    Assert.Contains("john@example.com", result);
                    Assert.Contains("Jane", result);
                    Assert.Contains("Doe", result);
                    Assert.Contains("jane@example.com", result);
                }
            }
            finally
            {
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }
    }
}
