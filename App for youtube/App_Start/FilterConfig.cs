﻿using System.Web;
using System.Web.Mvc;

namespace App_for_youtube
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
