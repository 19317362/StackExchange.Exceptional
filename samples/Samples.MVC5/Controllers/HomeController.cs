﻿using System.Web.Mvc;
using StackExchange.Exceptional;

namespace Samples.MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string validationTest)
        {
            ViewBag.Message = "This is a sample showing how to integrate Exceptional into your MVC4 application.";

            // For testing RequestValidationException, test something like: ?validationTest=<!2342!@#$!@#R<!#2, to throw an exception.
            var val = Request.QueryString[validationTest];

            return View();
        }

        /// <summary>
        /// This lets you access the error handler via a route in your application, secured by whatever
        /// mechanisms are already in place.
        /// </summary>
        /// <remarks>If mapping via RouteAttribute: [Route("errors/{path?}/{subPath?}")]</remarks>
        public ActionResult Exceptions()
        {
            var context = System.Web.HttpContext.Current;
            var page = new HandlerFactory().GetHandler(context, Request.RequestType, Request.Url.ToString(), Request.PathInfo);
            page.ProcessRequest(context);

            return null;
        }
    }
}
