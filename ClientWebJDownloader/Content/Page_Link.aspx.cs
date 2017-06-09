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
    public partial class Page_Link : System.Web.UI.Page
    {
        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current);

        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.Dispatch();
        }

        protected void odsGvLinks_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["IdUser"] = dispatcher.IdentificationService.GetLoggedUser().Id;
        }

        protected void btnAddLink_Click(object sender, EventArgs e)
        {
            var sqlParams = new Dictionary<string, object>()
            {
                {"Url", tbUrl.Text},
                {"IdUser", dispatcher.IdentificationService.GetLoggedUser().Id },
                {"DateCreated", DateTime.Now },
            };
            int rows = 0;
            if ((rows = LinkMetier.InsertOrUpdateLink(sqlParams)) > 0)
            {
                gvLinks.DataBind();
                tbUrl.Text = String.Empty;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            var id = Convert.ToInt32(gvLinks.DataKeys[row]["Id"]);
            LinkMetier.DeleteLink(id);
            gvLinks.DataBind();
        }

        protected void gvLinks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLinks.PageIndex = e.NewPageIndex;
            gvLinks.DataBind();
        }
    }
}