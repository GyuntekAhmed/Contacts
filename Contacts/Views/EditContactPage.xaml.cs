namespace Contacts.Views;

using Contacts.Models;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;

	public EditContactPage()
	{
		InitializeComponent();
	}

	private void BtnCancel_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

	public string ContactId
	{
		set
		{
            contact = ContactRepository.GetContactById(int.Parse(value));
			if (contact != null)
			{
                contactCtrl.FirstName = contact.FirstName;
                contactCtrl.LastName = contact.LastName!;
                contactCtrl.Email = contact.Email;
                contactCtrl.PhoneNumber = contact.PhoneNumber;
            }
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        contact.FirstName = contactCtrl.FirstName;
        contact.LastName = contactCtrl.LastName;
        contact.Email = contactCtrl.Email;
        contact.PhoneNumber = contactCtrl.PhoneNumber;

        ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}