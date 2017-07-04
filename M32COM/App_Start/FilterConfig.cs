using System.Web;
using System.Web.Mvc;

namespace M32COM
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
