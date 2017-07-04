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
    [AllowAnonymous]
    public class CakesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CakesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/cakes
        [HttpGet]
        public IEnumerable<Cake> GetCakes(string query = null)
        {
            var cakesQuery = _context.Cakes.Where(c => c.InStock>1);

            if (!String.IsNullOrWhiteSpace(query))
            {
                cakesQuery = cakesQuery;
            }
            return cakesQuery;

            // return Ok(cakes);
        }


        //GET /api/cakes/1
        [HttpGet]
        public IHttpActionResult GetCake(int id)
        {
            var cake = _context.Cakes.SingleOrDefault(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();

            }
            return Ok(Mapper.Map<Cake, CakeDto>(cake));
        }

        //POST /api/cakes

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public IHttpActionResult CreateCake(CakeDto cakedto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var cake = Mapper.Map<CakeDto, Cake>(cakedto);
            cake.InStock = cake.InStock;
            _context.Cakes.Add(cake);


            _context.SaveChanges();

            cakedto.Id = cake.Id;

            return Created(new Uri(Request.RequestUri + "/" + cake.Id), cakedto);

        }
        //PUT /api/cake/1

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage UpdateMovie(int id, CakeDto cake)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkcake = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (checkcake == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CakeDto, Movie>(cake, checkcake);
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
        public HttpResponseMessage DeleteCake(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkcake = _context.Cakes.SingleOrDefault(c => c.Id == id);

            if (checkcake == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Cakes.Remove(checkcake);
            _context.SaveChanges();

            //throw new  HttpResponseException(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }


}

