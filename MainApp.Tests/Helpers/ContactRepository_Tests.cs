
using MainApp.Models;
using MainApp.Services;
using System.Text.Json;

namespace MainApp.Tests.Services;

public class ContactRepository_Tests
{

    [Fact]

    public void LoadContactsFromFile_FileDoesNotExist_ReturnEmptyList()
    {
        var testFilePath = "nonexistent_test_contacts.json";

        try
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }

            var repository = new ContactRepository(testFilePath);
            var result = repository.LoadContactsFromFile();

            Assert.Empty(result);
        }
        finally
        {
            if (File.Exists (testFilePath))
            {
                File.Delete (testFilePath);
            }
        }
    }

    [Fact]

    /*
        Detta är genererat av Chat GPT 4o - Testet kollar så att metoden korrekt laddar kontakter från en giltig JSON-fil. Testet skapar då en fil med testdata och sparar den i JSON format, sedan använder den metoden för
        att läsa in filen, och efter att filen har laddats så kontrolleras att antalet kontakter är korrekt och att all information stämmer. Och till sist så raderas testfilen för att städa upp.
    */

    public void LoadContactsFromFile_ValidFile_ReturnsContacts()
    {
        var testFilePath = "valid_test_contacts.json";
        var contacts = new List<Contact>
        {
            new Contact { FirstName = "Pete", LastName = "Smith", Email = "pete@example.com" },
            new Contact { FirstName = "Eve", LastName = "Smith", Email = "eve@example.com" }
        };

        try
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(testFilePath, json);

            var repository = new ContactRepository(testFilePath);
            var result = repository.LoadContactsFromFile();

            Assert.Equal(2, result.Count);
            Assert.Equal("Pete", result[0].FirstName);
            Assert.Equal("Eve", result[1].FirstName);
        }
        finally
        {
            if (!File.Exists (testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }

    [Fact]

    public void SaveContactToFile_NewContact_FileIsUpdated()
    {
        var testFilePath = "save_test_contacts.json";
        
        try
        {
            var initialContacts = new List<Contact>
            {
                new Contact { FirstName = "Susie", LastName = "Sommer", Email = "susie@example.com" }
            };

            var json = JsonSerializer.Serialize(initialContacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(testFilePath, json);

            var newContact = new Contact { FirstName = "Phil", LastName = "Sommer", Email = "phil@example.com" };
            var repository = new ContactRepository(testFilePath);

            repository.SaveContactToFile(newContact);

            var result = repository.LoadContactsFromFile();
            Assert.Equal(2, result.Count);
            Assert.Equal("Phil", result[1].FirstName);
        }
        finally
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }
    }
}