using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class CustomerContext : IDB<Customer, int>
    {
        private OnlineShopDBContext _context;

        public CustomerContext(OnlineShopDBContext context)
        {
            _context = context;
        }

        public void Create(Customer item)
        {
            try
            {
                _context.Customers.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Customer Read(int key)
        {
            try
            {
                return _context.Customers.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Customer> ReadAll()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Customer item)
        {
            try
            {
                Customer customerFromDB = Read(item.ID);
                
                _context.Entry(customerFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                Customer customerFromDB = Read(key);

                _context.Customers.Remove(customerFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
