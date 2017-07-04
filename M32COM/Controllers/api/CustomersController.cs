using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using M32COM.dto;
using M32COM.Models;

namespace M32COM.Controllers.api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

         public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

       //GET /api/customers
        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery =  _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customers = customersQuery    
                .ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customers);

        }

        //GET /api/customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();

            }
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/customer
        
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            var checkcustomer = _context.Customers.ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

//            foreach (Customer c in checkcustomer)
//            {
//                if (c.Equals(customerdto))
//                {
//                    throw new HttpResponseException(HttpStatusCode.Conflict);
//                }
//            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(customer);
            

            _context.SaveChanges();

            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto );
            
        }
        //PUT /api/customer/1
        
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage UpdateCustomer(int id,CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkcustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (checkcustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<CustomerDto, Customer>(customer, checkcustomer);
//            checkcustomer.Name = customer.Name;
//            checkcustomer.BirthDateTime = customer.BirthDateTime;
//            checkcustomer.MembershipTypeId = customer.MembershipTypeId;
//            checkcustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
            
        }

        //DELETE /api/customer/1
       
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCakes)]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var checkcustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (checkcustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }


            _context.Customers.Remove(checkcustomer);
            _context.SaveChanges();

            //throw new HttpResponseException(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
