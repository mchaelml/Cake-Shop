using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M32COM.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public byte Id { get; set; }

        public static readonly byte Unknown = 0;
        public static  byte PayAsYouGo = 1;
    }
}