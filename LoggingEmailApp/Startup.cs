using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using LoggingEmailApp.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LoggingEmailApp.Startup))]

namespace LoggingEmailApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.Configure(GlobalFilters.Filters);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ReturnUrlParameter = "returnUrl",
                AuthenticationType = "ApplicationCookie",
                CookieName = "LoggingEmailApp",
                LoginPath = new PathString("/Auth/Login")
            });
        }
    }
}
