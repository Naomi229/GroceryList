using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp2.Models
{
    public enum MenuItemType
    {
        MyLists,
        MyProducts,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
