using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Filters
{
    /// <summary>
    /// An action filter to check the url of the http-request.
    /// </summary>
    public class CheckContextAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.RawUrl != "/" && filterContext.HttpContext.Request.RawUrl != "/Home/Index/" && filterContext.HttpContext.Request.RawUrl != "/Home/Index")
            {
                filterContext.Result = null;
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.RawUrl != "/" && filterContext.HttpContext.Request.RawUrl != "/Home/Index/" && filterContext.HttpContext.Request.RawUrl != "/Home/Index")
            {
                filterContext.Result = null;
            }
        }
    }
}