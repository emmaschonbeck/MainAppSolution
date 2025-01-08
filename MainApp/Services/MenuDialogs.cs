

namespace MainApp.Services;

public class MenuDialogs
{

    private readonly ListContacts listContacts;
    private readonly CreateContact createContact;

    public MenuDialogs()
    {
        listContacts = new ListContacts();
        createContact = new CreateContact();
    }

  

    public void MainMenu()
    {

        bool running = true;

        while (running)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("                  MAIN MENU                     ");
            Console.WriteLine("================================================\n");

            Console.WriteLine("Welcome! Please choose an option.");
            Console.WriteLine("1. Contacts");
            Console.WriteLine("2. Create a contact");
            Console.WriteLine("3. Exit\n");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    listContacts.ShowContacts();
                    Console.WriteLine("\nPress any key to return to the menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    Console.Clear();
                    createContact.ContactCreate();
                    break;

                case "3":
                    Console.WriteLine("Closing the application. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose a different option.");
                    break;
            }
        }
    }
}
