using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SAPS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "Se capturó una exepción en el evento Application_Error\n" +
                    "Error en: " + Request.Url.ToString() +
                    "\nMensaje:" + objErr.Message.ToString() +
                    "\nStack Trace:" + objErr.StackTrace.ToString();
            EventLog.WriteEntry("SAPS", err, EventLogEntryType.Error);
        }
    }
}