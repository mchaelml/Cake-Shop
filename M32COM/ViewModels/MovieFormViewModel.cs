using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using M32COM.Models;

namespace M32COM.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<MovieGenre> MovieGenres { get; set; }

        public string Title 
        {
            get 
            { 
                if (Movie != null && Movie.Id != 0) 
                    return "Edit Movie"; 
                return "New Movie"; 
            } 
        } 
    }
}