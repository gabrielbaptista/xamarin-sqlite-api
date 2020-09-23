using AppSample.Helpers;
using AppSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSample.Services
{
    class SqlitePeopleDataStore : IDataStore<Person>
    {
        public SqlitePeopleDataStore()
        {
            MobileHelper.GetSqliteConnection().CreateTableAsync<Person>().Wait();
        }
        public async Task<bool> AddItemAsync(Person item)
        {
            return await MobileHelper.GetSqliteConnection().InsertAsync(item) == 1;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await MobileHelper.GetSqliteConnection().DeleteAsync<Person>(id) == 1;
        }

        public async Task<Person> GetItemAsync(string id)
        {
            return await MobileHelper.GetSqliteConnection().Table<Person>().FirstOrDefaultAsync(r => r._id == id);
        }

        public async Task<IEnumerable<Person>> GetItemsAsync()
        {
            var list = await MobileHelper.GetSqliteConnection().Table<Person>().OrderBy(r => r._id).ToListAsync();
            return list;
        }

        public async Task<bool> UpdateItemAsync(Person item)
        {
            return await MobileHelper.GetSqliteConnection().UpdateAsync(item) == 1;
        }
    }
}
