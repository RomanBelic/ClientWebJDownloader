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
    public partial class Inscription : System.Web.UI.Page
    {
        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current, true);

        private string previous_Page
        {
            get { return (ViewState["prev_page"] != null) ? (string)ViewState["prev_page"] : String.Empty; }
            set { ViewState["prev_page"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.Dispatch();
            lblLoginError.Visible = false;
            if (!IsPostBack)
            {
                object param;
                if ((param = HttpContext.Current.Cache["prev_page" + Session.SessionID]) != null)
                {
                    previous_Page = param.ToString();
                }
            }
        }

        protected void btnInscrire_Click(object sender, EventArgs e)
        {
            var user = UserMetier.GetUser(tbLogin.Text);
            var date = DateTime.Now;
            var selectedType = ddlTypeUser.SelectedItem;
            var idType = Convert.ToInt32(selectedType.Value);

            if (!user.IsEmpty())
            {
                lblLoginError.Visible = true;
                return;
            }
            var sqlVals = new Dictionary<string, object>(8)
            {
                {"Login", tbLogin.Text },
                {"Pass", tbPassword.Text },
                {"Nom", tbNom.Text },
                {"Prenom", tbPrenom.Text },
                {"IdType", idType },
                {"DateRegister", date },
            };
            int id;
            if ((id = UserMetier.InsertUser(sqlVals)) > 0)
            {
                user.Id = id;
                user.DateRegister = date;
                user.IdType = idType;
                user.Login = tbLogin.Text;
                user.Pass = tbPassword.Text;
                user.Prenom = tbPrenom.Text;
                user.Nom = tbNom.Text;
                user.UserType.Id = idType;
                user.UserType.NameStr = selectedType.Text;

                dispatcher.IdentificationService.SetLoggedUser(user);
                dispatcher.IdentificationService.StoreSession(user);
                this.Response.RedirectToRoute("Index");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            var route = !String.IsNullOrEmpty(previous_Page) ? previous_Page : "Login";
            dispatcher.Context.Cache.Remove("prev_page" + Session.SessionID);
            this.Response.RedirectToRoute(route);
        }
    }
}