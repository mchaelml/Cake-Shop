using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class ShoppingCard
    {

        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "In stock")]
        public int InStock { get; set; }

        [Required]
        public int Calories { get; set; }

        [Range(0, 999)]
        [Required]
        public double Price { get; set; }

        [Required]
        
        public int Quantity { get; set; }

        public double getTotalPrice()
        {
            double price = 0;
            ApplicationDbContext db = new ApplicationDbContext();
            List<ShoppingCard> cart = db.ShoppingCards.ToList<ShoppingCard>();

            for (int i=0; i<cart.Count; i++)
            {
                price += cart[i].Price;
            }

            return price;
        }

    }
}