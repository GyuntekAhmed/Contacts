namespace Contacts.Views.Controls;

public partial class ContactControl : ContentView
{
	public event EventHandler<string> OnError;
	public event EventHandler<EventArgs> OnSave;
	public event EventHandler<EventArgs> OnCancel;

	public ContactControl()
	{
		InitializeComponent();
	}

    public string FirstName
	{
		get
		{
			return entryFirstName.Text;
		}
		set
		{
			entryFirstName.Text = value;
		}
	}

	public string LastName
	{
		get
		{
			return entryLastName.Text;
		}
		set
		{
			entryLastName.Text = value;
		}
	}

	public string Email
	{
		get
		{
			return entryEmail.Text;
		}
		set
		{
			entryEmail.Text = value;
		}
	}

	public string PhoneNumber
	{
		get
		{
			return entryPhoneNumber.Text;
		}
		set
		{
			entryPhoneNumber.Text = value;
		}
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
			OnError?.Invoke(sender, "First Name is required.");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
				OnError?.Invoke(sender, error!.ToString()!);
            }

            return;
        }

        if (phoneValidator.IsNotValid)
        {
			OnError?.Invoke(sender, "Phone is required!");

            return;
        }

		OnSave?.Invoke(sender, e);
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
		OnCancel?.Invoke(sender, e);
    }
}