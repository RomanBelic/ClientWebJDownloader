using ClientWebJDownloader.ConnectionManager;
using Common.Entities;
using Common.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebJDownloader.Content
{
    public partial class Page_Profil : System.Web.UI.Page
    {
        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current);

        private string previous_Page
        {
            get { return (ViewState["prev_page"] != null) ? (string)ViewState["prev_page"] : String.Empty; }
            set { ViewState["prev_page"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.Dispatch();
            if (!IsPostBack)
            {
                LoadUserInfo(dispatcher.IdentificationService.GetLoggedUser());
                object param;
                if ((param = HttpContext.Current.Cache["prev_page" + Session.SessionID]) != null)
                {
                    previous_Page = param.ToString();
                }
            }
        }

        private void LoadUserInfo(User user)
        {
            tbLogin.Text = user.Login;
            tbPass.Attributes["value"] = user.Pass;
            tbPass.Text = user.Pass;
            lblNom.Text = user.Nom;
            lblPrenom.Text = user.Prenom;
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            var route = !String.IsNullOrEmpty(previous_Page) ? previous_Page : "Index";
            dispatcher.Context.Cache.Remove("prev_page" + Session.SessionID);
            this.Response.RedirectToRoute(route);
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            lblSuccessUpdate.Visible = lblErrorLogin.Visible = false;
            var curUser = dispatcher.IdentificationService.GetLoggedUser();
            var updUser = GetClonedUser(curUser);
            var sqlParams = new Dictionary<string, object>(8);
            var typeCompte = !String.IsNullOrEmpty(ddlTypeCompte.SelectedValue) ? Convert.ToInt32(ddlTypeCompte.SelectedValue) : 0;
            if (!tbLogin.Text.Equals(curUser.Login))
            {
                var user = UserMetier.GetUser(tbLogin.Text);
                if (!user.IsEmpty())
                {
                    lblErrorLogin.Visible = true;
                    return;
                }
                sqlParams.Add("Login", tbLogin.Text);
                updUser.Login = tbLogin.Text;
            }
            if (!tbPass.Text.Equals(curUser.Pass))
            {
                sqlParams.Add("Pass", tbPass.Text);
                updUser.Pass = tbPass.Text;
                tbPass.Attributes["value"] = tbPass.Text;
            }
            if (typeCompte != curUser.IdType)
            {
                sqlParams.Add("IdType", typeCompte);
                updUser.IdType = typeCompte;
                updUser.UserType.Id = typeCompte;
                updUser.UserType.NameStr = ddlTypeCompte.SelectedItem.Text;
            }
            if (sqlParams.Count > 0)
                sqlParams.Add("Id", curUser.Id);
            int rows;
            if ((rows = UserMetier.UpdateUser(sqlParams)) > 0)
            {
                ReloadUserData(ref curUser, updUser);
                LoadUserInfo(curUser);
                UpdateMasterReference(curUser);
                lblSuccessUpdate.Visible = true;
            }
        }

        private void ReloadUserData(ref User origUser, User updUser)
        {
            origUser.Login = updUser.Login;
            origUser.Nom = updUser.Nom;
            origUser.Prenom = updUser.Prenom;
            origUser.Pass = updUser.Pass;
            origUser.Id = updUser.Id;
            origUser.IdType = updUser.IdType;
            origUser.DateRegister = updUser.DateRegister;
            origUser.UserType.Id = updUser.UserType.Id;
            origUser.UserType.NameStr = updUser.UserType.NameStr;
        }

        private User GetClonedUser(User orig)
        {
            var clone = new User();
            clone.Nom = orig.Nom;
            clone.Login = orig.Login;
            clone.Pass = orig.Pass;
            clone.Prenom = orig.Prenom;
            clone.Id = orig.Id;
            clone.IdType = orig.IdType;
            clone.DateRegister = orig.DateRegister;
            clone.UserType.Id = orig.UserType.Id;
            clone.UserType.NameStr = orig.UserType.NameStr;
            return clone;
        }

        private void UpdateMasterReference(User user)
        {
            var mpage = (HeaderMaster)this.Master;
            var userName = String.Format("{0} {1}", user.Nom, user.Prenom);

            EventHandler handler = (object sender, EventArgs args) =>
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "startup", "javascript:UpdateLabelText('" + mpage.LblLoggedUserType.ClientID + "','" + user.UserType.NameStr + "');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "startup", "javascript:UpdateLabelText('" + mpage.LblLoggedUser.ClientID + "','" + userName + "');", true);
            };
            mpage.Execute(handler, this, new EventArgs());
        }

        protected void ddlTypeCompte_PreRender(object sender, EventArgs e)
        {
            var user = dispatcher.IdentificationService.GetLoggedUser();
            var it = ddlTypeCompte.Items.FindByValue(user.IdType.ToString());
            if (it != null) it.Selected = true;
        }
    }
}