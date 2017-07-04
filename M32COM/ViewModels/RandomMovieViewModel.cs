using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M32COM.Models;

namespace M32COM.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customer { get; set; }
    
        
    }
}