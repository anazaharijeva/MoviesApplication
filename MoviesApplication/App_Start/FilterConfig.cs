using System.Web;
using System.Web.Mvc;

namespace MoviesApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filer za login prozorec, prvo da se najavi, pa potoa da ja korsti platformata
            filters.Add(new AuthorizeAttribute()); 
        }
    }
}
