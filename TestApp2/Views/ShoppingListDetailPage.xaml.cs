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
    public partial class ShoppingListDetailPage : ContentPage
    {
        ShoppingListDetailViewModel viewModel;
        public ShoppingListDetailPage(ShoppingListDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }


        public ShoppingListDetailPage() 
        {
            InitializeComponent();
            var item = new ShoppingList
            {
                Name = "List 1",
                Priority = ShoppingList.PriorityLevel.MEDIUM,
                isFinished = false

            };

            viewModel = new ShoppingListDetailViewModel();
            BindingContext = viewModel;

        }

    }
}