using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M32COM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;

namespace M32COM.Controllers
{
    public class OrderController : Controller
    {
        
        private ApplicationDbContext _context;
        //private ShoppingCard Cart;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public OrderController()
        {
            _context = new ApplicationDbContext();
            
        }

        public ActionResult Index()
        {
           

            return View("Index");
        }


        public ActionResult GetOrders()
        {
            if (User.IsInRole(RoleName.CanManageCakes))
            {
                var orderss = _context.Orders.ToList();
                return View("OrdersDetails", orderss);
            }
            var logginInUser = User.Identity.GetUserName();
            var orders = _context.Orders.Where(c => c.User.Equals(logginInUser)).ToList();

            return View("Orders",orders);
        }

        //        private ActionResult Details(int id)
        //        {
        //
        //            var cake = _context.ShoppingCards.SingleOrDefault(c => c.Id == id);
        //            if (cake == null)
        //            {
        //                return HttpNotFound();
        //            }
        //
        //            return View(cake);
        //        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Order order )
        {

            List<ShoppingCard> shopCard = _context.ShoppingCards.ToList();
            List<Cake> cakeList = _context.Cakes.ToList();
            String cartItems = "";

            for (int i=0; i < shopCard.Count; i++)
            {
                cartItems += shopCard[i].Name + " x" + shopCard[i].Quantity + " , ";
                int quant = shopCard[i].Quantity;

                //make changes here 2/4/17

                for (int j=0; j<cakeList.Count; j++)
                {
                    if (cakeList[j].Name == shopCard[i].Name)
                    {
                        int id = cakeList[j].Id;
                        var cakeInDb = _context.Cakes.Single(c => id == c.Id);

                        cakeInDb.Id = cakeList[j].Id;
                        cakeInDb.Name = cakeList[j].Name;
                        cakeInDb.Calories = cakeList[j].Calories;
                        cakeInDb.InStock = cakeList[j].InStock - quant;
                        cakeInDb.Price = cakeList[j].Price;
                        cakeInDb.imageSource = cakeInDb.imageSource;
                        _context.SaveChanges();
                    }
                }


            }

            if (!ModelState.IsValid)
            {

                var newOrder = new Order
                {

                    Id = order.Id,
                    OrderNumber = new Random().Next(10000, 20000),
                    surname = order.surname,
                    name = order.name,
                    address = order.address,
                    ccv = order.ccv,
                    creditCardNumber = order.creditCardNumber,
                    expMonth = order.expMonth,
                    expYear = order.expYear,
                    cardName = order.cardName,
                    User = User.Identity.GetUserName(),
                    postCode = order.postCode,
                    totalPrice = order.getTotalPrice(),
                    orderDate = DateTime.Now,
                    city = order.city, // only shopping card left
                    cart = shopCard,
                    Items = cartItems




                };
                

                _context.Orders.Add(newOrder);
                _context.SaveChanges();

                
                _context.ShoppingCards.RemoveRange(_context.ShoppingCards);
                _context.SaveChanges();
               
                return View("Index", newOrder);
            }

            if (order.Id == 0)
            {
                order.cart = shopCard;
                _context.Orders.Add(order);

            }
//            else
//            {
//                var orderInDb = _context.Orders.SingleOrDefault(o => o.Id == order.Id);
//
//                orderInDb.Id = order.Id;
//                orderInDb.surname = order.surname;
//                orderInDb.name = order.name;
//                orderInDb.address = order.address;
//                orderInDb.ccv = order.ccv;
//                orderInDb.creditCardNumber = order.creditCardNumber;
//                orderInDb.expMonth = order.expMonth;
//                orderInDb.expYear = order.expYear;
//                orderInDb.cardName = order.cardName;
//                orderInDb.totalPrice = order.totalPrice;
//                orderInDb.User = order.User;
//                orderInDb.city = order.city;
//                orderInDb.cart = shopCard;
//            }


            _context.ShoppingCards.RemoveRange(_context.ShoppingCards);
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Cakes");
        }
//        public double getTotalPrice()
//        {
//            double price = 0;
//            ApplicationDbContext db = new ApplicationDbContext();
//            List<ShoppingCard> cart = db.Orders.ToList<ShoppingCard>();
//
//            for (int i = 0; i < cart.Count; i++)
//            {
//                for (int j = 0; j < cart[i].Quantity; j++)
//                    price += cart[i].Price;
//            }
//
//            return price;
//        }


    }
}