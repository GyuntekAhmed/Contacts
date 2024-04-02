namespace Contacts.Models;

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

    public static Contact GetContactById(int id) =>
        contacts.FirstOrDefault(c => c.ContactId == id);
}
