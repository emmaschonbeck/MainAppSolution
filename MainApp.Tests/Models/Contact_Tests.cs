
using MainApp.Models;

namespace MainApp.Tests.Models;

public class Contact_Tests
{
    [Fact]

    public void Contact_ShouldGenerateUniqueId()
    {
        // Arrange & Act
        var contact = new Contact();

        // Assert
        Assert.False(string.IsNullOrEmpty(contact.Id));
    }



    [Fact]

    public void Contact_ShouldGenerateUniqueIdsForDifferentInstances()
    {
        // Arrange
        var contact1 = new Contact();
        var contact2 = new Contact();

        // Act & Assert
        Assert.NotEqual(contact1.Id, contact2.Id);
    }



    [Fact]

    /*
     Detta är genererat av Chat GPT 4o - Detta testet kollar så att en ny kontakt skapas med korrekt standardvärden. Testet ser till så att alla värden, som till exempel förnamn, efternamn, email osv, är tomma när
     kontakten skapas. Den sista raden i koden kontrollerar även så att ett unik Id skapas automatiskt och kollar så att den inte är tom. Syftet med testet är att kolla så att allt fungerar som det ska innan en ny
     kontakt skapas.
    */

    public void Contact_ShouldInitializePropertiesWithDefaultValues()
    {
        // Arrange
        var contact = new Contact();

        // Act & Assert
        Assert.Null(contact.FirstName);
        Assert.Null(contact.LastName);
        Assert.Null(contact.Email);
        Assert.Null(contact.PhoneNumber);
        Assert.Null(contact.Address);
        Assert.Null(contact.PostalCode);
        Assert.Null(contact.City);
        Assert.False(string.IsNullOrEmpty(contact.Id));
    }

    [Fact]

    public void Contact_ShouldAllowPropertyAssignment()
    {
        var contact = new Contact()
        {
            FirstName = "Paul",
            LastName = "Paulson",
            Email = "paul@example.com",
            PhoneNumber = "1234567890",
            Address = "1st avenue",
            PostalCode = "12345",
            City = "New York"
        };

        Assert.Equal("Paul", contact.FirstName);
        Assert.Equal("Paulson", contact.LastName);
        Assert.Equal("paul@example.com", contact.Email);
        Assert.Equal("1234567890", contact.PhoneNumber);
        Assert.Equal("1st avenue", contact.Address);
        Assert.Equal("12345", contact.PostalCode);
        Assert.Equal("New York", contact.City);
    }
}
