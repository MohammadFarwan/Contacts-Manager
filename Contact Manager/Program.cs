using System;
using System.Collections.Generic;

namespace Contact_Manager
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactsManager();
        }

        static void ContactsManager()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:\n1. Add a contact\n2. Remove a contact\n3. View all contacts\n4. Exit\n");
                
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter contact name: ");
                        var nameToAdd = Console.ReadLine();
                        try
                        {
                            ContactManager.AddContact(nameToAdd);
                            Console.WriteLine("Contact added successfully.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter contact name to remove: ");
                        var nameToRemove = Console.ReadLine();
                        try
                        {
                            ContactManager.RemoveContact(nameToRemove);
                            Console.WriteLine("Contact removed successfully.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        var contacts = ContactManager.ViewAllContacts();
                        Console.WriteLine("Contacts:");
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine(contact);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Exiting application.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
