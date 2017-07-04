using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace M32COM.Models
{
    public class DateOfBirthVal
    {
        protected void valDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime minDate = DateTime.Parse("1/1/1920");
            DateTime maxDate = DateTime.Parse("1/1/2007");
            DateTime dt;

            args.IsValid = (DateTime.TryParse(args.Value, out dt)
                            && dt <= maxDate
                            && dt >= minDate);
        }
    }
}