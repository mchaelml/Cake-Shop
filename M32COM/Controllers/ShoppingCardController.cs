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
    [System.Web.Mvc.AllowAnonymous]

    public class ShoppingCardController : Controller
    {
        private ApplicationDbContext _context;
        //private ShoppingCard Cart;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ShoppingCardController()
        {
         // Cart = new ShoppingCard();
          

        _context
        =
        new ApplicationDbContext();
    }

        public ActionResult Index()
        {
            var cart = _context.ShoppingCards;

            return View("ShoppingCardView",cart);
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



        //        private ActionResult AddToCart(int id)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                throw new HttpResponseException(HttpStatusCode.BadRequest);
        //            }
        //            var cake = _context.Cakes.SingleOrDefault(c => c.Id == id);
        //            if (cake == null)
        //            {
        //                return HttpNotFound();
        //            }
        //
        //            //Cart.ShopCard.Add(cake);
        //            return RedirectToAction("Index", "Cakes");
        //        }



        //        public ActionResult Details(int id)
        //        {
        //            var cake = _context.Cakes.SingleOrDefault(m => m.Id == id);
        //            if (cake == null)
        //            {
        //                HttpNotFound();
        //            }
        //
        //            return View("ShoppingCardView");
        //        }
        //
        //        public ActionResult New()
        //        {
        //            var genretypes = _context.MovieGenres.ToList();
        //            var viewmodel = new MovieFormViewModel
        //            {
        //                Movie = new Movie(),
        //                MovieGenres = genretypes
        //            };
        //            return View("MovieForm", viewmodel);
        //        }
        //
        //        [HttpPost]
        //        public ActionResult Save(Movie movie)
        //        {
        //
        //            if (!ModelState.IsValid)
        //            {
        //                var viewmodel = new MovieFormViewModel()
        //                {
        //
        //                    Movie = movie,
        //                    MovieGenres = _context.MovieGenres.ToList()
        //
        //
        //                };
        //
        //                return View("MovieForm", viewmodel);
        //            }
        //            if (movie.Id == 0 && movie.AvailableInStockNow == 0)
        //            {
        //                movie.AvailableInStockNow = movie.InStock;
        //                _context.Movies.Add(movie);
        //
        //            }
        //            else
        //            {
        //                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
        //
        //                movieInDb.Name = movie.Name;
        //                movieInDb.ReleaseDateTime = movie.ReleaseDateTime;
        //                movieInDb.InStock = movie.InStock;
        //
        //                movieInDb.MovieGenreId = movie.MovieGenreId;
        //
        //            }
        //            _context.SaveChanges();
        //
        //            return RedirectToAction("Index", "Movies");
        //        }
        //
        //        public ActionResult Edit(int id)
        //        {
        //            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(c => c.Id == id);
        //            if (movie == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            var viewmodel = new MovieFormViewModel()
        //            {
        //                Movie = movie,
        //                MovieGenres = _context.MovieGenres.ToList()
        //            };
        //            return View("MovieForm", viewmodel);
        //        }
    }
}