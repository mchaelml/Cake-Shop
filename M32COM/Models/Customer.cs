using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        //[Required(ErrorMessage = "Please Enter Membership Type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDateTime { get; set; }

        public List<Cake> orders { get; set; }
        
    }
}