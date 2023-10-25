namespace ContactsApp.Views;
using ContactsApp.Models;
using ContactsApp.UseCases.Interfaces;
using System.Collections.ObjectModel;

public partial class ContactsPage : ContentPage
{
    private readonly IViewContactsUseCase viewContactsUseCase;

    public ContactsPage(IViewContactsUseCase viewContactsUseCase)
	{
		InitializeComponent();
        this.viewContactsUseCase = viewContactsUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
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

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<CoreDomain.Contact>(await this.viewContactsUseCase.ExecuteAsync(string.Empty));
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        var contacts = new ObservableCollection<CoreDomain.Contact>(await this.viewContactsUseCase.ExecuteAsync(((SearchBar)sender).Text));

        listContacts.ItemsSource = contacts;
    }
}