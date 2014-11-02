namespace WebScheduler
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using AsyncWebScheduler;
    using AsyncWebScheduler._Interfaces;

    using WebScheduler.Tasks;

    public class MvcApplication : HttpApplication
    {
        private static IScheduler scheduler;

        protected void Application_Start()
        {
            if (scheduler == null)
            {
                scheduler = new AsyncWebScheduler("http://localhost/webscheduler");
            }

            //scheduler.RunEvery<CreateFileTask>(TimeSpan.FromSeconds(240));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
