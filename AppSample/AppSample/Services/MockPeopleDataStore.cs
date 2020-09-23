using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppSample.Models;

namespace AppSample.Services
{
    public class MockPeopleDataStore : IDataStore<Person>
    {
        readonly List<Person> items;

        public MockPeopleDataStore()
        {
            items = new List<Person>()
            {
                new Person { _id = Guid.NewGuid().ToString(), personName = "First person", Description="This is an item description." },
                new Person { _id = Guid.NewGuid().ToString(), personName = "Second person", Description="This is an item description." },
                new Person { _id = Guid.NewGuid().ToString(), personName = "Third person", Description="This is an item description." },
                new Person { _id = Guid.NewGuid().ToString(), personName = "Fourth person", Description="This is an item description." },
                new Person { _id = Guid.NewGuid().ToString(), personName = "Fifth person", Description="This is an item description." },
                new Person { _id = Guid.NewGuid().ToString(), personName = "Sixth person", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Person item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            var oldItem = items.FirstOrDefault((Person arg) => arg._id == item._id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.FirstOrDefault((Person arg) => arg._id == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s._id == id));
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
    }
}