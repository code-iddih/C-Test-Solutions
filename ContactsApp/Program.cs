using System;
using System.Collections.Generic;
using System.Linq;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class ContactsManager
{
    private List<Contact> contacts = new List<Contact>();

    // Adding Contact
    public void AddContact()
    {
        Console.Write("\nEnter Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        
        contacts.Add(new Contact { Name = name, PhoneNumber = phoneNumber, Email = email });
        Console.WriteLine("✅ Contact added successfully!\n");
    }

    // Viewing All Contacts
    public void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\n⚠️ No contacts available.");
            return;
        }

        Console.WriteLine("\n📜 Contact List:");
        for (int i = 0; i < contacts.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {contacts[i].Name} | 📞 {contacts[i].PhoneNumber} | ✉️ {contacts[i].Email}");
        }
    }

    // Updating Contact
    public void UpdateContact()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\n⚠️ No contacts available to update.");
            return;
        }

        ViewContacts();
        Console.Write("\nEnter the number of the contact to update: ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= contacts.Count)
        {
            Contact contact = contacts[index - 1];

            Console.Write("Enter New Name (leave empty to keep unchanged): ");
            string newName = Console.ReadLine();
            contact.Name = string.IsNullOrWhiteSpace(newName) ? contact.Name : newName;

            Console.Write("Enter New Phone Number (leave empty to keep unchanged): ");
            string newPhoneNumber = Console.ReadLine();
            contact.PhoneNumber = string.IsNullOrWhiteSpace(newPhoneNumber) ? contact.PhoneNumber : newPhoneNumber;

            Console.Write("Enter New Email (leave empty to keep unchanged): ");
            string newEmail = Console.ReadLine();
            contact.Email = string.IsNullOrWhiteSpace(newEmail) ? contact.Email : newEmail;

            Console.WriteLine("✅ Contact updated successfully!\n");
        }
        else
        {
            Console.WriteLine("❌ Invalid selection.\n");
        }
    }

    // Deleting Contact
    public void DeleteContact()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("\n⚠️ No contacts available to delete.");
            return;
        }

        ViewContacts();
        Console.Write("\nEnter the number of the contact to delete: ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= contacts.Count)
        {
            contacts.RemoveAt(index - 1);
            Console.WriteLine("✅ Contact deleted successfully!\n");
        }
        else
        {
            Console.WriteLine("❌ Invalid selection.\n");
        }
    }
}

class Program
{
    static void Main()
    {
        ContactsManager contactsManager = new ContactsManager();

        while (true)
        {
            Console.WriteLine("\n📞 CONTACTS MANAGEMENT SYSTEM");
            Console.WriteLine("1️⃣ Add Contact");
            Console.WriteLine("2️⃣ View Contacts");
            Console.WriteLine("3️⃣ Update Contact");
            Console.WriteLine("4️⃣ Delete Contact");
            Console.WriteLine("5️⃣ Exit");
            Console.Write("🔢 Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    contactsManager.AddContact();
                    break;
                case "2":
                    contactsManager.ViewContacts();
                    break;
                case "3":
                    contactsManager.UpdateContact();
                    break;
                case "4":
                    contactsManager.DeleteContact();
                    break;
                case "5":
                    Console.WriteLine("👋 Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("❌ Invalid option. Please try again.");
                    break;
            }
        }
    }
}
