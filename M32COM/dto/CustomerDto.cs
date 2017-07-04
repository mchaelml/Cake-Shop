using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using M32COM.Models;

namespace M32COM.dto
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


        public byte MembershipTypeId { get; set; }
        
       
        public DateTime? BirthDateTime { get; set; }
    }
}