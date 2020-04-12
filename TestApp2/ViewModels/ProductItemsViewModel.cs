using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestApp2.Models;
using TestApp2.Views;

namespace TestApp2.ViewModels
{
    public class ProductItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ProductItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ProductItemsViewModel()
        {
            Title = "My Products";
            Items = new ObservableCollection<ProductItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewProductItemPage, ProductItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ProductItem;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}