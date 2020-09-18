using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Services
{
    public class MockDataStore : IDataStore<Contact>
    {
        readonly List<Contact> contacts;

        public MockDataStore()
        {
            contacts = new List<Contact>()
            {
                new Contact { Id = Guid.NewGuid().ToString(), FirstName = "David", LastName="Gerding", Description="Teaches codes..." },
                
            };
        }

        public async Task<bool> AddItemAsync(Contact contact)
        {
            contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Contact contact)
        {
            var oldItem = contacts.Where((Contact arg) => arg.Id == contact.Id).FirstOrDefault();
            contacts.Remove(oldItem);
            contacts.Add(contact);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = contacts.Where((Contact arg) => arg.Id == id).FirstOrDefault();
            contacts.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Contact> GetItemAsync(string id)
        {
            return await Task.FromResult(contacts.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Contact>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(contacts);
        }
    }
}