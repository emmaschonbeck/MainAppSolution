
using MainApp.Models;
using System.Text.Json;

namespace MainApp.Services
{
    public class ContactRepository
    {
        private readonly string filePath = "test_contacts.json";


        /* 
           Denna kod är genererad av Chat GPT 4o - Denna kod är en metod som hämtar listan med kontakter.
           Vi börjar med att kolla ifall filen existerar i den första if-satsen, den kollar ifall "filePath" existerar och om den ej existerar så returneras en tom lista då det ej finns några sparade
           kontakter ännu.
           Om "filePath" existerar så läser koden av all text från filen och sparar det som en sträng i JSON.
           I den andra if-satsen så kontrollerar koden ifall JSON-strängen är tom eller innehåller tomma tecken som till exempel ett mellanslag. Om filen nu är tom så returneras en ny tom lista.
           Till sist så omvandlar vi JSON till en lista med kontakter. Först försöker koden konvertera JSON-strängen till en lista och om konverteringen lyckas så returneras en lista med de kontakter som finns
           sparade i filen. Om konverteringen skulle misslyckas så returneras en ny tom lista.
        */
        public List<Contact> LoadContactsFromFile()
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


        /* 
           Denna kod är genererad av Chat GPT 4o - Denna kod är en metod som börjar med att använda LoadContactsFromFile() för att kunna läsa in de kontakter som redan finns sparade i filen (filePath).
           Efter att de befintliga kontakter har laddats, så lägger den till de nya kontakter som har skapats i listan. 
           Sedan omvandlar vi hela listan till JSON, alltså vi gör om listan till en textsträng i JSON-format. Med hjälp av "WriteIndented = true" så gör vi JSON-strängen mer lättläst, allt staplas upp som en riktig
           lista. Utan den koden så hade JSON-strängen blivit en enda lång rad, som då skulle bli svårare att läsa av för oss.
           Till slut så används File.WriteAllText för att skriva JSON-strängen till min fil (filePath) och sparar alla kontakter.
        */
        public void SaveContactToFile(Contact contact)
        {
            var contacts = LoadContactsFromFile();

            contacts.Add(contact);

            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}

