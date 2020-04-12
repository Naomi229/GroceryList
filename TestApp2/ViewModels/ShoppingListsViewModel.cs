using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Models;
using TestApp2.Views;
using Xamarin.Forms;

namespace TestApp2.ViewModels
{
    class ShoppingListsViewModel : BaseViewModel
    {

        public ObservableCollection<ShoppingList> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ShoppingListsViewModel()
        {
            Title = "My Lists";
            Items = new ObservableCollection<ShoppingList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewShoppingListPage, ShoppingList>(this, "AddShoppingList", async (obj, item) =>
            {
                var newItem = item as ShoppingList;
                Items.Add(newItem);
                await DataStoreShoppingList.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStoreShoppingList.GetItemsAsync(true);
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
