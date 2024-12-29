﻿
using MainApp.Services;

namespace MainApp.Services;

public class MenuDialogs
{

    private readonly ListContacts listContacts;

    public MenuDialogs()
    {
        listContacts = new ListContacts();
    }

    public void MainMenu()
    {

        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome! Please choose an option.\n");
            Console.WriteLine("1. Contacts");
            Console.WriteLine("2. Create a contact");
            Console.WriteLine("3. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    listContacts.ShowContacts();
                    break;

                case "2":
                    CreateContact();
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