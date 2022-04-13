using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Customer
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> FavouriedProducts { get; set; }

        private Customer()
        {

        }

        public Customer(string name, string email, string telephone)
        {
            this.Name = name;
            this.Email = email;
            this.Telephone = telephone;
            this.Orders = new List<Order>();
        }

    }
}
