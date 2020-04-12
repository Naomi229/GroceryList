using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Models;

namespace TestApp2.Services
{
    class MockDataStoreShoppingList : IDataStore<ShoppingList>
    {

        readonly List<ShoppingList> items;


        public MockDataStoreShoppingList() {

            items = new List<ShoppingList>
            {
                new ShoppingList { Id = Guid.NewGuid().ToString(), Name="Lista Alimente", Priority = ShoppingList.PriorityLevel.HIGH},
                new ShoppingList { Id = Guid.NewGuid().ToString(), Name="Lista Cosmetice", Priority = ShoppingList.PriorityLevel.HIGH},

            };
        
        }

        public async Task<bool> AddItemAsync(ShoppingList item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ShoppingList arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ShoppingList> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ShoppingList>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(ShoppingList item)
        {
            var oldItem = items.Where((ShoppingList arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
