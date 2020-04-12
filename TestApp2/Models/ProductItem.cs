using SQLite;
using System;

namespace TestApp2.Models
{
    public class ProductItem
    {
        [PrimaryKey]
        public string Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
    }
}