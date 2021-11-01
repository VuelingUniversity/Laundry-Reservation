using System.Web;
using System.Web.Mvc;

namespace KataMachineAPI.Reservations
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
