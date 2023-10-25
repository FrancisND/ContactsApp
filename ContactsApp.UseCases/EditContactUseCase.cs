using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;


namespace ContactsApp.UseCases
{
    public class EditContactUseCase : IEditContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public EditContactUseCase(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }

        public async Task ExecuteAsync(int contactId, Contact contact)
        {
            await contactRepository.UpdateContactAsync(contactId, contact);
        }
    }
}
