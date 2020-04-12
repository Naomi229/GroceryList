using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Models;
using TestApp2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingListsPage : ContentPage
    {

        ShoppingListsViewModel viewModel;

        public ShoppingListsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ShoppingListsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (ShoppingList)layout.BindingContext;
            await Navigation.PushAsync(new ShoppingListDetailPage(new ShoppingListDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewShoppingListPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }

    }
}