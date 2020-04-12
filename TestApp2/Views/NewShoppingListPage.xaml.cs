using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewShoppingListPage : ContentPage
    {
        public ShoppingList ShoppingList { get; set; }

        public NewShoppingListPage()
        {
            InitializeComponent();

            ShoppingList = new ShoppingList
            {
                Name = "Shopping List Name",
                isFinished = false,
                Priority = ShoppingList.PriorityLevel.MEDIUM
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddShoppingList", ShoppingList);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}