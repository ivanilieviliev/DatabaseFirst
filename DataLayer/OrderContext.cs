using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class OrderContext : IDB<Order, int>
    {
        private OnlineShopDBContext _context;

        public OrderContext(OnlineShopDBContext context)
        {
            this._context = context;
        }

        public void Create(Order item)
        {
            try
            {
                Customer customerFromDB = _context.Customers.Find(item.CustomerID);

                if (customerFromDB != null)
                {
                    item.Customer = customerFromDB;
                }

                _context.Orders.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Order Read(int key)
        {
            try
            {
                return _context.Orders.Include(o => o.Customer).Include(o => o.OPQ).ThenInclude(opq => opq.Product).Single(o => o.ID == key);

                /* II nachin:
                Order order = _context.Orders.Find(key);
                _context.Entry(order).Reference(o => o.Customer).Load();
                _context.Entry(order).Collection(o => o.OPQ).Load();
                */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Order> ReadAll()
        {
            try
            {
                return _context.Orders.Include(o => o.Customer).Include(o => o.OPQ).ThenInclude(opq => opq.Product).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Order item)
        {
            try
            {
                Order orderFromDB = Read(item.ID);

                List<OrderProductQuantity> opqs = new List<OrderProductQuantity>();

                foreach (var opq in item.OPQ)
                {
                    var opqFromDatabase = _context.OPQs.Find(opq.OrderID, opq.ProductBarcode);

                    if (opqFromDatabase != null)
                    {
                        _context.Entry(opqFromDatabase).CurrentValues.SetValues(opq);
                        opqs.Add(opqFromDatabase);
                    }
                    else
                    {
                        opqs.Add(opq);
                    }
                }

                orderFromDB.OPQ = opqs;

                _context.Entry(orderFromDB).CurrentValues.SetValues(item);
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
                Order orderFromDB = Read(key);

                _context.Orders.Remove(orderFromDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddProductsToTheLastOrder(IEnumerable<OrderProductQuantity> orderProductQuantities)
        {
            Order order = _context.Orders.OrderBy(o => o.ID).Last();

            foreach (var item in orderProductQuantities)
            {
                item.OrderID = order.ID;
            }

            _context.SaveChanges();
        }

        public void CalculatePriceForTheLastOrder(IEnumerable<OrderProductQuantity> orderProductQuantities)
        {
            Order order = _context.Orders.OrderBy(o => o.ID).Last();

            foreach (var item in orderProductQuantities)
            {
                _context.Entry(item).Reference(opq => opq.Product).Load();
                order.Price += item.Quantity * item.Product.Price;
            }
        }

    }
}
