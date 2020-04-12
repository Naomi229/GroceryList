using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestApp2.Models;
using TestApp2.Views;
using TestApp2.ViewModels;

namespace TestApp2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ProductItemsPage : ContentPage
    {
        ProductItemsViewModel viewModel;

        public ProductItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (ProductItem)layout.BindingContext;
            await Navigation.PushAsync(new ProductItemDetailPage(new ProductItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewProductItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}