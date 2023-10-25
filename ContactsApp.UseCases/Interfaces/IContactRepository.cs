using Contact = ContactsApp.CoreDomain.Contact;

namespace ContactsApp.UseCases.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync(string filterText);
    }
}
