
using MainApp.Models;
using MainApp.Services;
using System.Text.Json;

namespace MainApp.Tests.Services;

public class ContactRepository_Tests
{

    [Fact]

    public void LoadContactsFromFile_FileDoesNotExist_ReturnEmptyList()
    {
        var repository = new ContactRepository();
        var testFilePath = "nonexistent.json";

        var result = repository.LoadContactsFromFile();

        Assert.Empty(result);
    }

    [Fact]

    public void LoadContactsFromFile_ValidFile_ReturnsContacts()
    {
        var testFilePath = "test_contacts.json";
        var contacts = new List<Contact>
        {
            new Contact { FirstName = "Pete", LastName = "Smith", Email = "pete@example.com" },
            new Contact { FirstName = "Eve", LastName = "Smith", Email = "eve@example.com" }
        };

        var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(testFilePath, json);

        var repository = new ContactRepository();

        var result = repository.LoadContactsFromFile();

        Assert.Equal(2, result.Count);
        Assert.Equal("Pete", result[0].FirstName);
        Assert.Equal("Eve", result[1].FirstName);

        File.Delete(testFilePath);
    }

    [Fact]

    public void SaveContactToFile_NewContact_FileIsUpdated()
    {
        var testFilePath = "test_contacts.json";
        var initialContacts = new List<Contact>
        {
            new Contact { FirstName = "Susie", LastName = "Sommer", Email = "susie@example.com" }
        };

        var json = JsonSerializer.Serialize(initialContacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(testFilePath, json);

        var newContact = new Contact { FirstName = "Phil", LastName = "Sommer", Email = "phil@example.com" };
        var repository = new ContactRepository();

        repository.SaveContactToFile(newContact);

        var result = repository.LoadContactsFromFile();
        Assert.Equal(2, result.Count);
        Assert.Equal("Phil", result[1].FirstName);

        File.Delete(testFilePath);
    }
}