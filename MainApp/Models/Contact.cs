

namespace MainApp.Models;

public class Contact
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Address { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public Guid Id { get; private set; }

    public Contact()
    {
        Id = Guid.NewGuid();
    }
}
