namespace ContactsApp.UseCases.Interfaces
{
    public interface IViewContactsUseCase
    {
        Task<List<CoreDomain.Contact>> ExecuteAsync(string filterText);
    }
}