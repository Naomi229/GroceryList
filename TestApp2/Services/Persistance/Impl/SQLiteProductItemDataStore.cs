using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Models;
using Xamarin.Forms;

namespace TestApp2.Services.Persistance.Impl
{
    class SQLiteProductItemDataStore : IDataStore<ProductItem>
    {

        private SQLiteAsyncConnection _connection;


        public SQLiteProductItemDataStore(ISQLLiteDb db) 
        {
            this._connection = db.GetConnection();
            _connection.CreateTableAsync<ProductItem>();
        }

        public async Task<bool> AddItemAsync(ProductItem item)
        {
            await _connection.InsertAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            await _connection.DeleteAsync(id);
            return await Task.FromResult(true);
        }

        public async Task<ProductItem> GetItemAsync(string id)
        {
            return await _connection.FindAsync<ProductItem>(id);
        }

        public async Task<IEnumerable<ProductItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _connection.Table<ProductItem>().ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(ProductItem item)
        {
            await _connection.UpdateAsync(item);
            return await Task.FromResult(true);
        }
    }
}
