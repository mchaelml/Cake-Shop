using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M32COM.Models;
using M32COM.ViewModels;

 
namespace M32COM.Controllers
{
    [AllowAnonymous]
    public class CustomersController : Controller
    {
        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }



//        // GET: Customer
//        public ViewResult Index()
//        {
//
//            var customers = GetCustomers();
//            
//            return View(customers);
//        }
//
//        private IEnumerable<Customer> GetCustomers()
//        {
//            return new List<Customer>
//            {
//                new Customer {Name = "Jhon",Id = 1},
//                new Customer {Name = "Lilly",Id = 2}
//            };
//        }
        public ViewResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm",viewmodel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewmodel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDateTime = customer.BirthDateTime;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer =_context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewmodel);
        }
    }
}