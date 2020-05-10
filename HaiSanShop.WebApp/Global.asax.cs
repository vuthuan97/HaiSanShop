using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace HaiSanShop.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["PageView"] = 0;
            Application["Online"] = 0;
        }
        protected void Session_Start()
        {
            Application.Lock();
            Application["PageView"] = (int)Application["PageView"] + 1;
            Application["Online"] = (int)Application["Online"] + 1;
            Application.UnLock();
        }
        protected void Session_End()
        {
            Application.Lock();
            Application["Online"] = (int)Application["Online"] -1;
            Application.UnLock();
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var taikhoancookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (taikhoancookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(taikhoancookie.Value);
                var Quyen = authTicket.UserData.Split(new char[] { ',' });
                var userPrinpycial = new GenericPrincipal(new GenericIdentity(authTicket.Name), Quyen);
                
                Context.User = userPrinpycial;
            }
        }
        
        
    }
}
