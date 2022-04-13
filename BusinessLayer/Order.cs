using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLayer
{
    public class Order
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [Required]
        public DateTime DateCreated { get; private set; }

        public DateTime? DeliveryDate { get; set; } // null

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public IEnumerable<OrderProductQuantity> OPQ { get; set; }

        private Order()
        {

        }

        public Order(string address, Customer customer)
        {
            this.Address = address;
            this.DateCreated = DateTime.Now;
            this.Customer = customer;
            this.OPQ = new List<OrderProductQuantity>();
        }

    }
}
