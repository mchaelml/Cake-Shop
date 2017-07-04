using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using M32COM.Models;
using M32COM.ViewModels;
using Microsoft.Ajax.Utilities;
using System.IO;

namespace M32COM.Controllers
{
    [AllowAnonymous]
    public class CakesController : Controller
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public CakesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: /Movies/Random
        public ActionResult Index()
            {

            if (User.IsInRole(RoleName.CanManageCakes))
                return View("CakeDetails");
            

            return View("Index");
        }

        //   /cakes/ + id
        [Authorize(Roles = RoleName.CanManageCakes)]
        public ActionResult Details(int id)
        {
            var cake = _context.Cakes.SingleOrDefault(m => m.Id == id);
            if (cake == null)
            {
                HttpNotFound();
            }

            return View("CakeDetails", cake);
        }

        [Authorize(Roles = RoleName.CanManageCakes)]
        public ActionResult New()
        {
            Cake cake = new Cake();

            return View("CakeForm", cake);
        }


        [Authorize(Roles = RoleName.CanManageCakes)]
        [HttpPost]
        public ActionResult Save(Cake cake, HttpPostedFileBase imageFile)
        {
            bool isImageInput = false;
            try
            {
                if (imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Cakes"), fileName);
                    imageFile.SaveAs(path);
                    isImageInput = true;
                }
                ViewBag.Message = "Upload successful";
            }
            catch
            {
                ViewBag.Message = "Upload failed";
            }
            if (!ModelState.IsValid)
            {

                var thicake = new Cake
                {
                    Id = cake.Id,
                    Calories = cake.Calories,
                    Price = cake.Price,
                    InStock = cake.InStock,
                    Name = cake.Name,
                    imageSource = ""
            };


                return View("CakeForm", thicake);
            }
            if (cake.Id == 0)
            {
                if (isImageInput)
                    cake.imageSource = "Images/Cakes/" + imageFile.FileName;
                else
                    cake.imageSource = "";
                _context.Cakes.Add(cake);

            }
            else
            {
                var cakeInDb = _context.Cakes.SingleOrDefault(c => c.Id == cake.Id);

                cakeInDb.Id = cake.Id;
                cakeInDb.Name = cake.Name;
                cakeInDb.Calories = cake.Calories;
                cakeInDb.InStock = cake.InStock;
                cakeInDb.Price = cake.Price;
                if (isImageInput)
                {
                    cakeInDb.imageSource = "Images/Cakes/" + imageFile.FileName;
                }
                else
                {
                    cakeInDb.imageSource = cakeInDb.imageSource;
                }
                

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Cakes");
        }

        [Authorize(Roles = RoleName.CanManageCakes)]
        public ActionResult Edit(int id)
        {
            var cake = _context.Cakes.SingleOrDefault(c => c.Id == id);
            if (cake == null)
            {
                return HttpNotFound();
            }
            var cakeit = new Cake
            {
                Id = cake.Id,
                Price = cake.Price,
                Calories = cake.Calories,
                InStock = cake.InStock,
                Name = cake.Name,
                imageSource = cake.imageSource
            };
            return View("CakeForm", cakeit);
        }


        public void Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Cakes"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
            }
            catch
            {
                ViewBag.Message = "Upload failed";
            }
        }
    }
}