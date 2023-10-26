using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;

namespace ContactsApp.UseCases
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository contactRepository;

        public DeleteContactUseCase(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }

        public async Task ExecuteAsync(int contactId)
        {
            await contactRepository.DeleteContactAsync(contactId);
        }
    }
}
