using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoggingEmailApp.App_Start
{
    public class FilterConfig
    {
        public static void Configure(GlobalFilterCollection filterCollection)
        {
            filterCollection.Add(new AuthorizeAttribute());
        }
    }
}