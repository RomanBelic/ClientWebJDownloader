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
    public partial class Login : System.Web.UI.Page
    {
        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current, true);

        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.Dispatch();
            lblError.Visible = false;
        }
  
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var user = UserMetier.GetUser(tbLogin.Text, tbPass.Text);
            if (!user.IsEmpty())
            {
                dispatcher.IdentificationService.StoreSession(user);
                dispatcher.IdentificationService.SetLoggedUser(user);
                this.Response.RedirectToRoute("Index");
            }
            else
            {
                lblError.Visible = true;
            }
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            dispatcher.Context.Cache["prev_page" + Session.SessionID] = "Login";
            this.Response.RedirectToRoute("Subscribe");
        }
    }
}