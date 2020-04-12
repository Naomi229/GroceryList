using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestApp2.Models;
using TestApp2.ViewModels;

namespace TestApp2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ProductItemDetailPage : ContentPage
    {
        ProductItemDetailViewModel viewModel;

        public ProductItemDetailPage(ProductItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ProductItemDetailPage()
        {
            InitializeComponent();

            var item = new ProductItem
            {
                Name = "Item 1",
                Quantity = 1,
                Location = "no Location"

            };

            viewModel = new ProductItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ShowMapPage()));
           
        }
    }
}