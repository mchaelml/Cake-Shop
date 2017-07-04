using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class Cake
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

        
        [Required]
        [Range(1,999.99)]
        public double Price { get; set; }

        public string imageSource { get; set; }

    }
}