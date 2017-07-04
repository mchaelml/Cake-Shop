using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace M32COM.Models
{
    public class cartQuantity
    {
        ApplicationDbContext  _context = new ApplicationDbContext();

        public int GetQuantity()
        {
           return (int) _context.ShoppingCards.ToList().Count();
        }

        public cartQuantity()
        {
            GetQuantity();
        }
    }
}