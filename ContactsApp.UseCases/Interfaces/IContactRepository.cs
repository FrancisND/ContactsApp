using Contact = ContactsApp.CoreDomain.Contact;

namespace ContactsApp.UseCases.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(int contactId);
        Task<List<Contact>> GetContactsAsync(string filterText);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
