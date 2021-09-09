using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace EF_Code1st_Movie_Catalog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}