using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp2.Models;

namespace TestApp2.Services
{
    public class MockDataStore : IDataStore<ProductItem>
    {
        readonly List<ProductItem> items;

        public MockDataStore()
        {
            items = new List<ProductItem>()
            {
                new ProductItem { Id = Guid.NewGuid().ToString(), Name = "Frisca", Quantity=3, Location="Penny Market"},
                new ProductItem { Id = Guid.NewGuid().ToString(), Name = "Oua", Quantity=20, Location="Corex"},
                new ProductItem { Id = Guid.NewGuid().ToString(), Name = "Banane", Quantity=2, Location="Aprozar"}
               
            };
        }

        public async Task<bool> AddItemAsync(ProductItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ProductItem item)
        {
            var oldItem = items.Where((ProductItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ProductItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ProductItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ProductItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}