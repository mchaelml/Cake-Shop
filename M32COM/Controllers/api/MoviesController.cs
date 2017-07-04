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
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        public IEnumerable<CakeDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(m => m.MovieGenre).Where(m => m.AvailableInStockNow > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }
            return moviesQuery    
                .ToList().Select(Mapper.Map<Movie, CakeDto>);

           // return Ok(movies);
        }
        

        //GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();

            }
            return Ok(Mapper.Map<Movie, CakeDto>(movie));
        }

        //POST /api/movies
        
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public IHttpActionResult CreateMovie(CakeDto moviedto)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            
            var movie = Mapper.Map<CakeDto, Movie>(moviedto);
            movie.AvailableInStockNow = movie.InStock;
            _context.Movies.Add(movie);


            _context.SaveChanges();

            moviedto.Id = movie.Id;
            
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);

        }
        //PUT /api/movies/1
   
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage UpdateMovie(int id, CakeDto movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkmovie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (checkmovie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CakeDto, Movie>(movie, checkmovie);
            //            checkmovie.Name = customer.Name;
            //            checkmovie.ReleaseDate = movie.ReleaseDate;
            //            checkmovie.GenreId = movie.GenreId;
            //            checkmovie.InStock = movie.InStock;

            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //DELETE /api/customer/1
    
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkmovie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (checkmovie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(checkmovie);
            _context.SaveChanges();

            //throw new  HttpResponseException(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }


}

