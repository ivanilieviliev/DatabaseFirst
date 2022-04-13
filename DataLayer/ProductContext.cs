using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class ProductContext : IDB<Product, string>
    {
        private OnlineShopDBContext _context;

        public ProductContext(OnlineShopDBContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            try
            {
                _context.Products.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Read(string key)
        {
            try
            {
                return _context.Products.Find(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> ReadAll()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Product item)
        {
            try
            {
                // I way:
                /*
                _context.Products.Update(item);
                _context.SaveChanges();
                */

                // II way:
                /*
                Product productFromDB = Read(item.Barcode);

                productFromDB.Name = item.Name;
                productFromDB.Price = item.Price;
                productFromDB.Quantity = item.Quantity;
                productFromDB.FavouriedForCustomers = item.FavouriedForCustomers;

                _context.SaveChanges();
                */

                // III way:
                Product productFromDB = Read(item.Barcode);

                _context.Entry(productFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string key)
        {
            try
            {
                Product productFromDB = Read(key);

                _context.Products.Remove(productFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
