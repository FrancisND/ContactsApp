using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;


namespace ContactsApp.UseCases
{
    public class ViewContactUseCase : IViewContactUseCase
    {
        private readonly IContactRepository contactRepository;


        public ViewContactUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Contact> ExecuteAsync(int contactId)
        {
            return await contactRepository.GetContactByIdAsync(contactId);
        }

    }
}
