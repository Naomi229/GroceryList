using System;
using System.Collections.Generic;
using System.Text;
using TestApp2.Models;

namespace TestApp2.ViewModels
{
    public class ShoppingListDetailViewModel : BaseViewModel
    {

        public ShoppingList Item { get; set; }
        public ShoppingListDetailViewModel(ShoppingList item = null)
        {
            Title = item?.Name;
            Item = item;

        }

    }
}
