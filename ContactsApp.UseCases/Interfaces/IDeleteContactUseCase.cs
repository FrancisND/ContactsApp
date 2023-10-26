namespace ContactsApp.UseCases.Interfaces
{
    public interface IDeleteContactUseCase
    {
        Task ExecuteAsync(int contactId);
    }
}