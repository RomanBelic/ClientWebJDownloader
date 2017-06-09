using ClientWebJDownloader.ConnectionManager;
using Common.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebJDownloader.Content
{
    public partial class Deconnection : System.Web.UI.Page
    {
        Dispatcher dispatcher = new Dispatcher(HttpContext.Current, true);
        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.IdentificationService.RemoveStoredSession();
            dispatcher.IdentificationService.RemoveLoggedUser();
            this.Response.RedirectToRoute("Login");
        }
    }
}