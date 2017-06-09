using Common.Connection;
using Common.Shared;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace ClientWebJDownloader
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Constants.Init();
            SqlAdapter.Init();
            RegisterRoutes(RouteTable.Routes);
        }
       
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.Clear();
            routes.MapPageRoute("Index", "Default", "~/Default.aspx", true);
            routes.MapPageRoute("Login", "Login", "~/Content/Login.aspx", true);
            routes.MapPageRoute("Logout", "Logout", "~/Content/Deconnection.aspx", true);
            routes.MapPageRoute("Subscribe", "Subscribe", "~/Content/Inscription.aspx", true);
            routes.MapPageRoute("LinkManager", "Links", "~/Content/Page_Link.aspx", true);
            routes.MapPageRoute("AccountManager", "Account", "~/Content/Account.aspx", true);
        }
    }
}