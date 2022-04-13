using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Product
    {
        [Key]
        [MaxLength(20)]
        public string Barcode { get; private set; }

        [Required] // not null
        [MaxLength(40)]
        public string Name { get; set; } // null

        [Required]
        public int Quantity { get; set; } // not null

        [Required]
        public decimal Price { get; set; }

        public List<Customer> FavouriedForCustomers { get; set; }

        private Product()
        {

        }

        public Product(string barcode, string name, int quantity, decimal price)
        {
            this.Barcode = barcode;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

    }
}
