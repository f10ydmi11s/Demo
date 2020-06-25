using Demo.CustomFilter;
using System.Web;
using System.Web.Mvc;

namespace Demo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
