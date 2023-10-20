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

        LoadContacts();
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

    private void MenuDeleteItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();     // Refresh list in listview. (even though list in memory it's already deleted)
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }
}