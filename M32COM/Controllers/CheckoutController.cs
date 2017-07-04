using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using M32COM.Models;
using M32COM.ViewModels;
using Microsoft.Ajax.Utilities;

namespace M32COM.Controllers
{
   

    public class CheckoutController : Controller
    {
        private ApplicationDbContext _context;
        //private ShoppingCard Cart;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public CheckoutController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Index()
        {
            var shopcart = _context.ShoppingCards;
            var cart = _context.ShoppingCards.ToList().Count();
            if (cart == 0 || shopcart.Equals(null))
            {
                Redirect("/ShoppingCard");
            }
            else
            {
                return View("CheckoutView");
            }
            return Redirect("/ShoppingCard");

        }

        private ActionResult Details(int id)
        {

            var cake = _context.ShoppingCards.SingleOrDefault(c => c.Id == id);
            if (cake == null)
            {
                return HttpNotFound();
            }

            return View(cake);
        }

        public double getTotalPrice()
        {
            double price = 0;
            ApplicationDbContext db = new ApplicationDbContext();
            List<ShoppingCard> cart = db.ShoppingCards.ToList<ShoppingCard>();

            for (int i = 0; i < cart.Count; i++)
            {
                for (int j=0; j<cart[i].Quantity; j++)
                    price += cart[i].Price;
            }

            return price;
        }

    }
}