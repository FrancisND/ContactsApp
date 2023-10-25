namespace ContactsApp.UseCases.Interfaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(CoreDomain.Contact contact);
    }
}