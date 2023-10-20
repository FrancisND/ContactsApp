using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Models
{
    public static class ContactRepository
    {
        public static List<Contact> contacts = new List<Contact>()
        {
            new Contact { ContactId=1, Name="John Doe", Email="johndoe@gmail.com", Phone="2347826001", Address="48 Lara Street" },
            new Contact { ContactId=2, Name="Frank Lukas", Email="franklukas@gmail.com", Phone="8965471253", Address="5 Kids Street" },
            new Contact { ContactId=3, Name="Janet Bauer", Email="janetbauer@gmail.com", Phone="1253698752", Address="117 Young Street" },
            new Contact { ContactId=4, Name="Nathan Ginger", Email="nathanginger@gmail.com", Phone="7023698741", Address="95 Project Street" }
        };

        public static List<Contact> GetContacts() => contacts;

        public static Contact GetContactById(int contactId)
        {
            // Old code, working fine
            //return contacts.FirstOrDefault(x => x.ContactId == contactId);

            // New code // Create a copy
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);

            if (contact is not null)
            {
                return new Contact
                {
                    ContactId = contactId,
                    Address = contact.Address,
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            //var contactToUpdate = GetContactById(contactId);
            var contactToUpdate = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contactToUpdate != null)
            {
                // AutoMapper
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);
        }



    }
}
