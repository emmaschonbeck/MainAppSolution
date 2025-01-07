

using MainApp.Models;

namespace MainApp.Services;

public class ContactDisplayer
{

       /* 
          Denna kod är genererad av Chat GPT 4o - Metoden tar emot ett kontaktobjekt och visar deras information på skärmen. Syftet är att göra det lättläst att läsa informationen om en enskild kontakt i konsolen.
          Med hjälp av =-tecknet gör jag en avskiljare för att det ska vara mer lättläst i konsolen. Det gör så att varje kontakt blir lättare att läsa och sära på, det blir också lite snyggare.
          Till sist skriver vi ut all information om kontakten som ska synas i konsolen.
       */
    public void DisplayContact(Contact contact)
    {
        Console.WriteLine("\n==========================================");
        Console.WriteLine($"ID: {contact.Id}");
        Console.WriteLine($"First name: {contact.FirstName}");
        Console.WriteLine($"Last name: {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Phone number: {contact.PhoneNumber}");
        Console.WriteLine($"Address: {contact.Address}");
        Console.WriteLine($"Postal code: {contact.PostalCode}");
        Console.WriteLine($"City: {contact.City}");
        Console.WriteLine("==========================================\n");
    }
}
