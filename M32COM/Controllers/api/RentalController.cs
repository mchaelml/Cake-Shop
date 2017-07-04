using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using M32COM.dto;
using M32COM.Models;

namespace M32COM.Controllers.api
{
    public class RentalController : ApiController
    {

        private readonly ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newrental)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newrental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids were given.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newrental.CustomerID);

            if (customer == null)
            {
                return BadRequest("Customer ID is invalid.");
            }

            var movies = _context.Movies.Where(m => newrental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newrental.MovieIds.Count)
            {
                return BadRequest("One or more Movies were not loaded.");
            }



            foreach (var movie in movies)
            {
                if (movie.AvailableInStockNow == 0)
                {
                    return BadRequest("No available copies at the moment");
                }
                movie.AvailableInStockNow--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            
            _context.SaveChanges();

            return Ok();
        }
    }
}
