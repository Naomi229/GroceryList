﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestApp2.Models;

namespace TestApp2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewProductItemPage : ContentPage
    {
        public ProductItem Item { get; set; }

        public NewProductItemPage()
        {
            InitializeComponent();

            Item = new ProductItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Product Item name",
                Quantity = 1,
                Location = "Address"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}