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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = IdentificationService.GetCurrentUser();
                lblUserName.Text = user.Nom + " " + user.Prenom;
                lblUserType.Text = user.UserType.NameStr;
            }
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
            this.Response.RedirectToRoute("AccountManager");
        }

        protected void lkDeconnect_Click(object sender, EventArgs e)
        {
            this.Response.RedirectToRoute("Logout");
        }
    }
}