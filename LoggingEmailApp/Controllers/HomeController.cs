using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace LoggingEmailApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Nlog()
        {
            try
            {
                var x = 12;
                var y = x / 0;
            }
            catch (DivideByZeroException ex)
            {

                Logger logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Debug(ex, "An error has occured");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Log4net()
        {
            try
            {
                var x = 2;
                var y = x / 0;
            }
            catch (Exception ex)
            {
                log.Debug("There was a fatal error", ex);
                
            }
            return View();
        }

        public ActionResult SuccessPage()
        {
            return View();
        }
    }
}