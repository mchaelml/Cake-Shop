using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        
        [Display(Name = "Date of Release")]
        [Required]
        public DateTime? ReleaseDateTime { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "In stock")]
        public int InStock { get; set; }

        public int AvailableInStockNow { get; set; }

        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }

        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte MovieGenreId { get; set; }
    }
}