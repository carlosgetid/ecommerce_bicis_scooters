using System.Web;
using System.Web.Mvc;

namespace Venta_Bicis_Scooters
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
