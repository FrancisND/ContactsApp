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

        public Task<Contact> GetContactByIdAsync(int contactId)
        {
            // New code // Create a copy
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact is not null)
            {
                return Task.FromResult(new Contact
                {
                    ContactId = contactId,
                    Address = contact.Address,
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                });
            }

            return null;
        }

        public Task UpdateContactAsync(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return Task.CompletedTask;

            //var contactToUpdate = GetContactById(contactId);
            var contactToUpdate = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                // AutoMapper
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }

            return Task.CompletedTask;
        }

        public Task AddContactAsync(Contact contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);

            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(int contactId)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                contacts.Remove(contact);
            }

            return Task.CompletedTask;
        }
    }
}