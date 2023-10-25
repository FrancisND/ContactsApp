namespace ContactsApp.UseCases.Interfaces
{
    public interface IEditContactUseCase
    {
        Task ExecuteAsync(int contactId, CoreDomain.Contact contact);
    }
}