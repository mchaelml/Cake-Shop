using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using M32COM.Models;

namespace M32COM.dto
{
    public class CakeDto
    {

        public int Id { get; set; }
        [Required]
        public String Name { get; set; }


        public MovieGenreDto MovieGenre { get; set; }
        //[Required]
        public DateTime? ReleaseDateTime { get; set; }

        [Required]
        [Range(1, 20)]
       
        public int InStock { get; set; }
        
        public int AvailableInStockNow { get; set; }



        [Required]
        
        public byte MovieGenreId { get; set; }
    }
}