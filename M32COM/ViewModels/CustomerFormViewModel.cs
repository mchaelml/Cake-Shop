using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using M32COM.Models;

namespace M32COM.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Edit Customer";
                }
                return "New Customer";
            }
        }
        
    }

    
}