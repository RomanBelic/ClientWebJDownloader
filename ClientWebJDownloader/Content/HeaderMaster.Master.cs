using Common.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebJDownloader.Content
{
    public partial class HeaderMaster : System.Web.UI.MasterPage
    {

        public void Execute(EventHandler hander, object sender, EventArgs args)
        {
            hander(sender, args);
        }

        public Label LblLoggedUser
        {
            get { return lblUserName; }
        }

        public Label LblLoggedUserType
        {
            get { return lblUserType; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = IdentificationService.GetCurrentUser();
            lblUserName.Text = String.Format("{0} {1}", user.Nom,user.Prenom);
            lblUserType.Text = user.UserType.NameStr;
        }

        protected void lkHome_Click(object sender, EventArgs e)
        {
            this.Response.RedirectToRoute("Index");
        }

        protected void lkLinks_Click(object sender, EventArgs e)
        {
            this.Response.RedirectToRoute("LinkManager");
        }

        protected void lkAccount_Click(object sender, EventArgs e)
        {
            this.Response.RedirectToRoute("Profile");
            HttpContext.Current.Cache["prev_page" + Session.SessionID] = "Index";
        }

        protected void lkDeconnect_Click(object sender, EventArgs e)
        {
            this.Response.RedirectToRoute("Logout");
        }
    }
}