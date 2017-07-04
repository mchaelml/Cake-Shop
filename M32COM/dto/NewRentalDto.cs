using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M32COM.dto
{
    public class NewRentalDto
    {
        public int CustomerID { get; set; }
        public List<int> MovieIds { get; set; }
    }
}