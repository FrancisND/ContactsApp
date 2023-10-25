using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;

// One public method per Use Case

namespace ContactsApp.UseCases
{
    // All the code in this file is included in all platforms.
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContactRepository contactRepository;
        public ViewContactsUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await contactRepository.GetContactsAsync(filterText);
        }
    }
}