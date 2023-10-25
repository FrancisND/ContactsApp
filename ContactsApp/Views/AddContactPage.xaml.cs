using ContactsApp.Models;
using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;

namespace ContactsApp.Views;


public partial class AddContactPage : ContentPage
{
    private readonly IAddContactUseCase addContactUseCase;

	public AddContactPage(IAddContactUseCase _addContactUseCase)
	{
		InitializeComponent();
        addContactUseCase = _addContactUseCase;

    }

    //private void btnCancel_Clicked(object sender, EventArgs e)
    //{
    //    Shell.Current.GoToAsync("..");

    //    //Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");    // Same as above ("..")
    //}

    private async void contactCtrl_OnSave(object sender, EventArgs e)
    {
        await addContactUseCase.ExecuteAsync(new Contact
        {
            Name = contactCtrl.Name,
            Email = contactCtrl.Email,
            Address = contactCtrl.Address,
            Phone = contactCtrl.Phone
        });

        await Shell.Current.GoToAsync("..");
        //Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");    // Same as above ("..")
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("..");   //Works the same as below
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }
}