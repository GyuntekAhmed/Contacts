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
                entryFirstName.Text = contact.FirstName;
                entryLastName.Text = contact.LastName;
                entryEmail.Text = contact.Email;
                entryPhoneNumber.Text = contact.PhoneNumber;
            }
		}
	}

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
		contact.FirstName = entryFirstName.Text;
		contact.LastName = entryLastName.Text;
		contact.Email = entryEmail.Text;
		contact.PhoneNumber = entryPhoneNumber.Text;

		ContactRepository.UpdateContact(contact.ContactId, contact);
        Shell.Current.GoToAsync("..");
    }
}