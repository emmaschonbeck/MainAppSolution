

using MainApp.Models;
using MainApp.Services;

namespace MainApp.Tests.Services;

public class ContactDisplayer_Tests
{
    [Fact]

    public void DisplayContact_ShouldPrintCorrectInformation()
    {
        // Arrange
        var contact = new Contact
        {
            Id = "1",
            FirstName = "Test",
            LastName = "Test",
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            Address = "Test 2b",
            PostalCode = "12345",
            City = "Stockholm"
        };
        var contactDisplayer = new ContactDisplayer();

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            contactDisplayer.DisplayContact(contact);

            // Assert
            var output = sw.ToString();
            Assert.Contains("ID: 1", output);
            Assert.Contains("First name: Test", output);
            Assert.Contains("Last name: Test", output);
            Assert.Contains("Email: test@example.com", output);
            Assert.Contains("Phone number: 1234567890", output);
            Assert.Contains("Address: Test 2b", output);
            Assert.Contains("Postal code: 12345", output);
            Assert.Contains("City: Stockholm", output);
        }
    }
}
