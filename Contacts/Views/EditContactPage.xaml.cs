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
			labelName.Text = $"{contact.FirstName} \n {contact.LastName} \n {contact.PhoneNumber} \n {contact.Email} \n";
		}
	}
}