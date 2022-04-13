using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class OPQContext : IDB<OrderProductQuantity, Dictionary<int, string>>
    {
        private OnlineShopDBContext _context;

        public OPQContext(OnlineShopDBContext context)
        {
            _context = context;
        }

        public void Create(OrderProductQuantity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Dictionary<int, string> key)
        {
            throw new NotImplementedException();
        }

        public OrderProductQuantity Read(Dictionary<int, string> key)
        {
            try
            {
                int orderID = Convert.ToInt32(key);
                string productBarcode = key[orderID];
                OrderProductQuantity opq = _context.OPQs.Include(opq => opq.Product).Single(opq => opq.OrderID == orderID && opq.ProductBarcode == productBarcode);

                /* II way:
                OrderProductQuantity opq = _context.OPQs.Find(orderID, productBarcode);
                _context.Entry(opq).Reference(opq => opq.Product).Load();
                */

                return opq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<OrderProductQuantity> ReadAll()
        {
            try
            {
                return _context.OPQs.Include(opq => opq.Product).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(OrderProductQuantity item)
        {
            throw new NotImplementedException();
        }
    }
}
