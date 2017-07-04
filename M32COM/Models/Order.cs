using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using M32COM.Controllers;
using Microsoft.VisualBasic.ApplicationServices;

namespace M32COM.Models
{
    public class Order 
    {
        public int Id { get; set; }
        
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        [Required]
        public String User { get; set; }

        public String Items { get; set; }


        [Required]
        [Display(Name = "Your cakes")]
        public List<ShoppingCard> cart { get; set; }

        [Required]
        [RegularExpression("[0-9]{1,} [a-zA-Z]{1,}( [a-zA-Z]{1,}){1,}", ErrorMessage = "Example : 15 Peter Road ")]
        [Display(Name = "Address")]
        public String address { get; set; } 

        [Required]
        [RegularExpression("^[a-zA-Z]{1,2}([0-9]{1,2}|[0-9][a-zA-Z])\\s*[0-9][a-zA-Z]{2}$",ErrorMessage = "Enter a valid UK postcode")]
//        [RegularExpression("(?i)GIR[ ]?0AA|((AB|AL|B|BA|BB|BD|BH|BL|BN|BR|BS|BT|CA|CB|CF|CH|CM|CO|CR|CT|CV|CW|DA|DD|DE|DG|DH|DL|DN|DT|DY|E|EC|EH|EN|EX|FK|FY|G|GL|GY|GU|HA|HD|HG|HP|HR|HS|HU|HX|IG|IM|IP|IV|JE|KA|KT|KW|KY|L|LA|LD|LE|LL|LN|LS|LU|M|ME|MK|ML|N|NE|NG|NN|NP|NR|NW|OL|OX|PA|PE|PH|PL|PO|PR|RG|RH|RM|S|SA|SE|SG|SK|SL|SM|SN|SO|SP|SR|SS|ST|SW|SY|TA|TD|TF|TN|TQ|TR|TS|TW|UB|W|WA|WC|WD|WF|WN|WR|WS|WV|YO|ZE)(\\d[\\dA-Z]?[ ]?\\d[ABD-HJLN-UW-Z]{2}))|BFPO[ ]?\\d{1,4}",ErrorMessage = "UK PostCode Example : CV11AA")]
        [Display(Name = "Post Code")]
        public String postCode { get; set; } 

        [Required]
        //[RegularExpression("^[a-zA-Z\\s]+$", ErrorMessage = "")]
        [RegularExpression("^[A-z]*$", ErrorMessage = "Only alphabetical characters")]
        [Display(Name = "Name")]
        public String name { get; set; } 

        [Required]
        [RegularExpression("^[A-z]*$",ErrorMessage = "Only alphabetical characters")]
        // [RegularExpression("^[a-zA-Z\\s]+$",ErrorMessage = "")]
        [Display(Name = "Surname")]
        public String surname { get; set; } 

        [Required]
       // [Range(16,16)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Credit Card number must be numeric")]
        [Display(Name = "Credit Card Number")]
        public String creditCardNumber { get; set; } 

        [Required]
        [Range(1, 12)]
        [Display(Name = "Exp Month")]
        public int expMonth { get; set; } 

        [Required]
        [Range(17, 25)]
        [Display(Name = "Exp Year")]
        public int expYear { get; set; } 

        [Required]
        [RegularExpression("^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$", ErrorMessage = "Enter valid full name")]
        [Display(Name = "Full Card Name")]
        public String cardName { get; set; } 

        [Required]
        [RegularExpression("^[a-zA-Z\\u0080-\\u024F.]+((?:[ -.|'])[a-zA-Z\\u0080-\\u024F]+)*$",ErrorMessage = "Enter a valid city")]
        [Display(Name = "City")]
        public String city { get; set; }

        [Required]
        [Display(Name = "CCV")]
        public int ccv { get; set; }

        [Required]
        public double totalPrice { get; set; }

        [Required]
        public DateTime orderDate { get; set; }

        public double getTotalPrice()
        {
            double price = 0;
            ApplicationDbContext db = new ApplicationDbContext();
            List<ShoppingCard> carts = db.ShoppingCards.ToList<ShoppingCard>();

            for (int i = 0; i < carts.Count; i++)
            {
                for (int j = 0; j < carts[i].Quantity; j++)
                    price += carts[i].Price;
            }

            return price;
        }

    }
}