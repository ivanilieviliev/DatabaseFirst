using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public static class DBContextManager
    {
        private static OnlineShopDBContext _context;

        static DBContextManager()
        {
            _context = new OnlineShopDBContext();
        }

        public static OnlineShopDBContext CreateContext()
        {
            _context = new OnlineShopDBContext();
            return _context;
        }

        public static OnlineShopDBContext GetContext()
        {
            return _context;
        }

        public static void SetAutoDetectChanges(bool value)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = value;
        }

    }
}
