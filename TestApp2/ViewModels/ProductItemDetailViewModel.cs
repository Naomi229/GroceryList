using System;

using TestApp2.Models;

namespace TestApp2.ViewModels
{
    public class ProductItemDetailViewModel : BaseViewModel
    {
        public ProductItem Item { get; set; }
        public ProductItemDetailViewModel(ProductItem item = null)
        {
            Title = item?.Name;
            Item = item;

        }
    }
}
