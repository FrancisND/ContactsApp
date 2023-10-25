using ContactsApp.UseCases.Interfaces;
using Contact = ContactsApp.CoreDomain.Contact;

namespace ContactsApp.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactInMemoryRepository : IContactRepository
    {
        public static List<Contact> contacts;

        public ContactInMemoryRepository()
        {
            contacts = new List<Contact>()
            {
                new Contact { ContactId=1, Name="John Doe", Email="johndoe@gmail.com", Phone="2347826001", Address="48 Lara Street" },
                new Contact { ContactId=2, Name="Frank Lukas", Email="franklukas@gmail.com", Phone="8965471253", Address="5 Kids Street" },
                new Contact { ContactId=3, Name="Janet Bauer", Email="janetbauer@gmail.com", Phone="1253698752", Address="117 Young Street" },
                new Contact { ContactId=4, Name="Nathan Ginger", Email="nathanginger@gmail.com", Phone="7023698741", Address="95 Project Street" }
            };
        }

        public Task<List<Contact>> GetContactsAsync(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return Task.FromResult(contacts);
            }

            var res = contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (res is null || res.Count <= 0)
                contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(res);

            if (res is null || res.Count <= 0)
                contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(res);

            if (res is null || res.Count <= 0)
                contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(res);

            return Task.FromResult(res);
        }


    }
}