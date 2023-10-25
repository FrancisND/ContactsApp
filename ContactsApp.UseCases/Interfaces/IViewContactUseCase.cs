namespace ContactsApp.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<CoreDomain.Contact> ExecuteAsync(int contactId);
    }
}