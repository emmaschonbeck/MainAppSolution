
using MainApp.Models;
using MainApp.Services;
using System.Text.Json;

namespace MainApp.Tests.Services
{
    public class ListContacts_Tests
    {
        [Fact]

        public void ShowContacts_NoContacts_FindsNoContactsMessage()
        {
            var repository = new ContactRepository();
            var testFilePath = "test_contacts.json";
            File.WriteAllText(testFilePath, "[]");

            var listContacts = new ListContacts();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                listContacts.ShowContacts();

                var result = sw.ToString();
                Assert.Contains("No contacts were found.", result);
            }

            File.Delete(testFilePath);
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
            File.WriteAllText(testFilePath, json);

            var listContacts = new ListContacts();

            using ( var sw = new StringWriter())
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

            File.Delete(testFilePath);
        }
    }
}
