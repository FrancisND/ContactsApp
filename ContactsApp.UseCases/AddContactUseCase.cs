using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;



namespace ContactsApp.UseCases
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public AddContactUseCase(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }

        public async Task ExecuteAsync(Contact contact)
        {
            await contactRepository.AddContactAsync(contact);
        }
    }


}
