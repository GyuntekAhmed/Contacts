namespace Contacts.Models;

using System;
using System.Collections.Generic;

public static class ContactRepository
{
    public static List<Contact> contacts = new List<Contact>()
        {
            new() {
                ContactId = 1,
                FirstName = "Gyuntek",
                LastName = "Ahmed",
                PhoneNumber = "+359893794549",
                Email = "gyuntekahmed@gmail.com",
            },
            new() {
                ContactId = 2,
                FirstName = "Gyunay",
                LastName = "Ahmed",
                PhoneNumber = "0893794549",
                Email = "gyunayahmed@abv.bg",
            },
        };

    public static List<Contact> GetContacts() => contacts;

    public static Contact? GetContactById(int id)
    {
        var currentContact = contacts.FirstOrDefault(c => c.ContactId == id);

        if (currentContact != null)
        {
            return new Contact
            {
                ContactId = currentContact.ContactId,
                FirstName = currentContact.FirstName,
                LastName = currentContact.LastName,
                PhoneNumber = currentContact.PhoneNumber,
                Email = currentContact.Email,
            };
        }

        return null;
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId)
        {
            return;
        }

        var contactToUpdate = contacts.FirstOrDefault(c => c.ContactId == contactId);

        if (contactToUpdate != null)
        {
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
        }
    }

    public static void AddContact(Contact contact)
    {
        var maxId = contacts.Max(c => c.ContactId);
        contact.ContactId = maxId + 1;
        contacts.Add(contact);
    }

    public static void DeleteContact(int contactId)
    {
        var contact = contacts.FirstOrDefault(c => c.ContactId == contactId);

        if (contact != null)
        {
            contacts.Remove(contact);
        }
    }

    public static List<Contact> SearchContacts(string filterText)
    {
        var contactsList = contacts
            .Where(c => !string.IsNullOrWhiteSpace(c.FirstName) &&
            c.FirstName.StartsWith
            (filterText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (contactsList == null || contactsList.Count <= 0)
        {
            contactsList = contacts
            .Where(c => !string.IsNullOrWhiteSpace(c.PhoneNumber) &&
            c.PhoneNumber.StartsWith
            (filterText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
        else
        {
            return contactsList;
        }

        if (contactsList == null || contactsList.Count <= 0)
        {
            contactsList = contacts
            .Where(c => !string.IsNullOrWhiteSpace(c.LastName) &&
            c.LastName!.StartsWith
            (filterText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
        else
        {
            return contactsList;
        }

        if (contactsList == null || contactsList.Count <= 0)
        {
            contactsList = contacts
            .Where(c => !string.IsNullOrWhiteSpace(c.Email) &&
            c.Email.StartsWith
            (filterText, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }
        else
        {
            return contactsList;
        }

        return contactsList;
    }
}
