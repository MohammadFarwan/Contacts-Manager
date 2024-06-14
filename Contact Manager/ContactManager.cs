using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    public class ContactManager
    {
        private static List<string> contacts = new List<string>();

        public static List<string> AddContact(string contact)
        {
            if (string.IsNullOrWhiteSpace(contact))
            {
                throw new ArgumentException("Contact name cannot be empty or whitespace.");
            }

            if (contacts.Contains(contact))
            {
                throw new InvalidOperationException("Contact with the same name already exists.");
            }

            contacts.Add(contact);
            return contacts;
        }

        public static List<string> RemoveContact(string contact)
        {
            if (!contacts.Contains(contact))
            {
                throw new InvalidOperationException("Contact does not exist in the list.");
            }

            contacts.Remove(contact);
            return contacts;
        }

        public static List<string> ViewAllContacts()
        {
            return contacts;
        }
    }
}
