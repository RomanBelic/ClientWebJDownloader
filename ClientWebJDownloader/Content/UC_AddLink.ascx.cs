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
    public partial class UC_AddLink : System.Web.UI.UserControl
    {
        public Panel LinkPanel
        {
            get => this.pnlNewLink;
        }

        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current);

        public event EventHandler OnQuit = (sender, args) => { };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValider_Click(object sender, EventArgs e)
        {
            var sqlParams = new Dictionary<string, object>(4)
            {
                {"Url", tbURL.Text},
                {"IdUser", dispatcher.IdentificationService.GetLoggedUser().Id },
                {"DateCreated", DateTime.Now },
                {"Name", tbName.Text },
            };
            LinkMetier.InsertLink(sqlParams);
            btnClose_Click(sender, e);
        }

        private void ClearPanel()
        {
            tbName.Text = tbURL.Text = String.Empty;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            OnQuit(sender, new EventArgs());
            ClearPanel();
            this.pnlNewLink.Visible = false;
        }
    }
}