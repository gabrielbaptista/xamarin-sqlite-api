using AppSample.Helpers;
using AppSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSample.Services
{
    class SqliteItemDataStore : IDataStore<Item>
    {
        public SqliteItemDataStore()
        {
            SqliteConnectionHelper.GetConnection().CreateTableAsync<Item>().Wait();
        }
        public async Task<bool> AddItemAsync(Item item)
        {
            return await SqliteConnectionHelper.GetConnection().InsertAsync(item) == 1;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await SqliteConnectionHelper.GetConnection().DeleteAsync<Item>(id) == 1;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await SqliteConnectionHelper.GetConnection().Table<Item>().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            var list = await SqliteConnectionHelper.GetConnection().Table<Item>().OrderBy(r => r.Id).ToListAsync();
            return list;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            return await SqliteConnectionHelper.GetConnection().UpdateAsync(item) == 1;
        }
    }
}
