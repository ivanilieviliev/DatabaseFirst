using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer
{
    public class OrderProductQuantity
    {
        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        [MaxLength(20)]
        public string ProductBarcode { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "Quantity must be between 1 and 5000!")]
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public OrderProductQuantity(string productBarcode, int quantity)
        {
            this.ProductBarcode = productBarcode;
            this.Quantity = quantity;
        }

    }
}
