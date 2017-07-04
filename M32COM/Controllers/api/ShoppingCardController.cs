using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using AutoMapper;
using M32COM.dto;
using M32COM.Models;

namespace M32COM.Controllers.api
{
    [AllowAnonymous]
    public class ShoppingCardController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCardController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/cakes
        [HttpGet]
        public IEnumerable<ShoppingCard> GetShoppingCard()
        {
            //            Cake cake = new Cake();
            //            cake.Calories = 0;
            //            cake.InStock = 10;
            //            cake.Name = "donut";
            //            cake.Price = 4;
            //
            //            List<Cake> something = new List<Cake>();
            //            something.Add(cake);
            //
            //            return something;

            var cakesQuery = _context.ShoppingCards.ToList();

//            if (!String.IsNullOrWhiteSpace(query))
//            {
//                cakesQuery = cakesQuery;
//            }
            return cakesQuery;


        }




        //GET /api/cakes/1
        [HttpGet]
        public IHttpActionResult GetShoppingCard(int id)
        {
            var shopCard = _context.ShoppingCards.SingleOrDefault(m => m.Id == id);
            if (shopCard == null)
            {
                return NotFound();

            }
            //return Ok(Mapper.Map<Cake, CakeDto>(shopCard));
            return Ok();
        }

        [HttpPost]
        public HttpResponseMessage AddToCart(int id)
        {
            var checkcake = _context.Cakes.SingleOrDefault(c => c.Id == id);
            var thecake = _context.ShoppingCards.SingleOrDefault(c => c.Name == checkcake.Name);

            //var addQuantityCake = _context.ShoppingCards.SingleOrDefault(c => c.Id == id);
            

            if (checkcake == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if (thecake == null)
            {
                ShoppingCard item = new ShoppingCard();

                item.Name = checkcake.Name;
                item.Calories = checkcake.Calories;
                item.InStock = checkcake.InStock == 0 ? 1 : checkcake.InStock;
               
                item.Id = id;
                item.Price = checkcake.Price;
                item.Quantity = 1;

                _context.ShoppingCards.Add(item);
                _context.SaveChanges();
                _context.ShoppingCards.ToList();

                //_context.ShoppingCards.ToList().Count;
            }
            else
            {
                if (thecake.Quantity + 1 >= thecake.InStock)
                {
                    thecake.Quantity = thecake.InStock - 1; // ALWAYS BE 1
                    _context.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                } 
                else
                    thecake.Quantity++;
                _context.SaveChanges();
            }

//            if (addQuantityCake == null)
//            {
//                ShoppingCard cake = new ShoppingCard();
//
//                cake.Name = checkcake.Name;
//                cake.Calories = checkcake.Calories;
//                cake.InStock = checkcake.InStock == 0 ? 1 : checkcake.InStock;
//
//                // item.Id = checkcake.Id;
//                cake.Price = checkcake.Price;
//                cake.Quantity = 1;
//
//                _context.ShoppingCards.Add(cake);
//                _context.SaveChanges();
//            }
//            else
//            {
//                addQuantityCake.Quantity += 1;
//                _context.SaveChanges();
//            }





            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage AddToQuantity(int id)
        {
         

            var addQuantityCake = _context.ShoppingCards.SingleOrDefault(c => c.Id == id);

            if (addQuantityCake.Quantity + 1 >= addQuantityCake.InStock)
            {
                addQuantityCake.Quantity = addQuantityCake.InStock - 1; // ALWAYS BE 1
                _context.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            } 
            else
                addQuantityCake.Quantity++;

            _context.SaveChanges();
     
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //POST /api/cakes

        //        [HttpPost]
        //        [Authorize(Roles = RoleName.CanManageCakes)]
        //        public IHttpActionResult Add(CakeDto cakedto)
        //        {
        //
        //
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest();
        //            }
        //
        //
        //            var cake = Mapper.Map<CakeDto, Cake>(cakedto);
        //            cake.InStock = cake.InStock;
        //            _context.Cakes.Add(cake);
        //
        //
        //            _context.SaveChanges();
        //
        //            cakedto.Id = cake.Id;
        //
        //            return Created(new Uri(Request.RequestUri + "/" + cake.Id), cakedto);
        //
        //        }
        //PUT /api/cake/1

//        [HttpPut]
//        //[Authorize(Roles = RoleName.CanManageCakes)]
//        public HttpResponseMessage UpdateCart(int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                throw new HttpResponseException(HttpStatusCode.BadRequest);
//            }
//            var checkcake = _context.ShoppingCards.SingleOrDefault(c => c.Id == id);
//
//            if (checkcake == null)
//            {
//                throw new HttpResponseException(HttpStatusCode.NotFound);
//            }
//            //Mapper.Map<CakeDto, Movie>(cake, checkcake);
//            //            checkmovie.Name = customer.Name;
//            //            checkmovie.ReleaseDate = movie.ReleaseDate;
//            //            checkmovie.GenreId = movie.GenreId;
//            //            checkmovie.InStock = movie.InStock;
//
//            checkcake.Quantity -= 1;
//            _context.SaveChanges();
//            return new HttpResponseMessage(HttpStatusCode.OK);
//        }

        //DELETE /api/customer/1

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage DeleteCake(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkcake = _context.ShoppingCards.Single(c => c.Id == id);
            
            if (checkcake == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            if (checkcake.Quantity == 1 || checkcake.Quantity == 0)
            {
                _context.ShoppingCards.Remove(checkcake);
            }
            else
            {
                checkcake.Quantity -= 1;
            }

            
            _context.SaveChanges();

            //throw new  HttpResponseException(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }


}

