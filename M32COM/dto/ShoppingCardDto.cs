using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using M32COM.Models;

namespace M32COM.dto
{
    public class ShoppingCardDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public List<Cake> shopCard { get; set; }
    }
}