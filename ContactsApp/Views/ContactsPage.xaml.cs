namespace ContactsApp.Views;
using ContactsApp.Models;
using System.Collections.ObjectModel;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		//List<Contact> contacts = ContactRepository.GetContacts();

        //listContacts.ItemsSource = contacts;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if(listContacts.SelectedItem != null)
		{
            var selectedItemId = ((Contact)listContacts.SelectedItem).ContactId;
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={selectedItemId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}