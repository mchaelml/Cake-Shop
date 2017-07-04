using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M32COM.Models;
using M32COM.ViewModels;
using Microsoft.Ajax.Utilities;

namespace M32COM.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: /Movies/Random
        public ActionResult Index()
            {

            if (User.IsInRole(RoleName.CanManageCakes))
                return View("Details");


            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=>m.MovieGenre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                HttpNotFound();
            }

            return View(movie);
        }

//        private IEnumerable<Movie> GetMovies()
//        {
//            return new List<Movie>
//            {
//                new Movie {Name = "Shrek",Id=1},
//                new Movie {Name = "Van Helsink",Id=2}
//            };
//        }
//
//        public ActionResult Edit(int id)
//        {
//            return Content("id" + id);
//        }

//        public ActionResult Index(int? pageIndex, String sortBy)
//        {
//            if (!pageIndex.HasValue) pageIndex = 1;
//            if (sortBy.IsNullOrWhiteSpace()) sortBy = "Name";
//
//            return Content(String.Format("pageIndex={0},sortBy={1}",pageIndex,sortBy));
//        }

        [Route("movies/release/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var genretypes = _context.MovieGenres.ToList();
            var viewmodel = new MovieFormViewModel
            {
                Movie = new Movie(),
                MovieGenres = genretypes
            };
            return View("MovieForm", viewmodel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel()
                {
                    
                    Movie = movie,
                    MovieGenres = _context.MovieGenres.ToList()
                    
                    
                };

                return View("MovieForm", viewmodel);
            }
            if (movie.Id == 0 && movie.AvailableInStockNow == 0)
            {
                movie.AvailableInStockNow = movie.InStock;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDateTime = movie.ReleaseDateTime;
                movieInDb.InStock = movie.InStock;
                
                movieInDb.MovieGenreId = movie.MovieGenreId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewmodel = new MovieFormViewModel()
            {
                Movie = movie,
                MovieGenres = _context.MovieGenres.ToList()
            };
            return View("MovieForm", viewmodel);
        }
    }
}