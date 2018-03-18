using NexPayBankApp.Logging;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NexPayBankApp.Filters
{
    public class TraceFilterAttribute : ActionFilterAttribute
    {
        protected DateTime start_time;


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RouteData route_data = filterContext.RouteData;           
            string controller = (string)route_data.Values["controller"];
            string action = (string)route_data.Values["action"];          
            start_time = DateTime.Now;
            Log.LogInformation(controller, action,"Start time", start_time.ToString(), route_data.ToString());

        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            RouteData route_data = filterContext.RouteData;
            TimeSpan duration = (DateTime.Now - start_time);
            string controller = (string)route_data.Values["controller"];
            string action = (string)route_data.Values["action"];
            DateTime created_at = DateTime.Now;
            Log.LogInformation(controller, action,"Duration", duration.ToString(), route_data.ToString());
            
        }
    }
}