using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using ServiceLayer;

namespace PresentationLayer
{
    public class CustomerView
    {
        private CustomerManager customerManager;

        public CustomerView()
        {
            customerManager = new CustomerManager(DBContextManager.CreateContext());
        }

        public CustomerView(CustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        public void Create()
        {
            try
            {
                string name, email, telephone;

                Console.Write("Enter name: ");
                name = Console.ReadLine();

                Console.Write("Enter email: ");
                email = Console.ReadLine();

                Console.Write("Enter telephone: ");
                telephone = Console.ReadLine();

                Customer customer = new Customer(name, email, telephone);
                customerManager.Create(customer);

                Console.WriteLine("Customer created successfully!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer Read()
        {
            try
            {
                int id;
                Console.Write("Enter customer id: ");
                id = Convert.ToInt32(Console.ReadLine());

                Customer customer = customerManager.Read(id);

                if (customer == null)
                {
                    throw new ArgumentException("There is no customer with that id!");
                }

                Console.WriteLine("Customer Info:");
                Console.WriteLine("Name = {0} ; Email = {1} ; Telephone = {2}; ID = {3}", 
                    customer.Name, customer.Email, customer.Telephone, customer.ID);

                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadAll()
        {
            try
            {
                List<Customer> customers = (List<Customer>)customerManager.ReadAll();

                for (int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine("Customer #{0} Info:", i + 1);
                    Console.WriteLine("Name = {0} ; Email = {1} ; Telephone = {2}; ID = {3}", 
                        customers[i].Name, customers[i].Email, customers[i].Telephone, customers[i].ID);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                Customer customer = Read();

                string name, email, telephone;

                Console.Write("Enter new name or press enter: ");
                name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    customer.Name = name;
                }

                Console.Write("Enter new email or press enter: ");
                email = Console.ReadLine();

                if (!string.IsNullOrEmpty(email))
                {
                    customer.Email = email;
                }

                Console.Write("Enter telephone  or press enter: ");
                telephone = Console.ReadLine();

                if (!string.IsNullOrEmpty(telephone))
                {
                    customer.Telephone = telephone;
                }

                customerManager.Update(customer);

                Console.WriteLine("Customer updated successfully!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                Customer customer = Read();

                customerManager.Delete(customer.ID);

                Console.WriteLine("Customer deleted successfully!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
