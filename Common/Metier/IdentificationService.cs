using Common.Entities;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Common.Metier
{
    public class IdentificationService
    {
        private HttpContext context;

        public IdentificationService(HttpContext context)
        {
            this.context = context;
        }

        public User GetLoggedUser()
        {
            return (context.Session[Constants.UserKey] as User != null) ? (User)context.Session[Constants.UserKey] : new User();
        }

        public void SetLoggedUser(User user)
        {
            context.Session[Constants.UserKey] = user;
        }

        public bool HasStoredSession()
        {
            var cookie = context.Request.Cookies.Get(Constants.UserKey);
            if (cookie == null)
                return false;

            var userId = cookie.Values.Get(Constants.UserIdKey);
            var sessionId = cookie.Values.Get(Constants.SessionKey);
            return context.Session.SessionID.Equals(sessionId) && !String.IsNullOrEmpty(userId);
        }

        public User RestoreUser()
        {
            var storedId = context.Request.Cookies[Constants.UserKey][Constants.UserIdKey];
            int userId = !String.IsNullOrEmpty(storedId) ? Convert.ToInt32(storedId) : 0;
            return UserMetier.GetUser(userId);
        }

        public void StoreSession(User user)
        {
            var c = new HttpCookie(Constants.UserKey);
            c.Values.Add(Constants.UserIdKey, user.Id.ToString());
            c.Values.Add(Constants.SessionKey, context.Session.SessionID);
            c.Expires = DateTime.Now.AddDays(1);
            context.Response.Cookies.Remove(Constants.UserKey);
            context.Response.Cookies.Add(c);
        }

        public void RemoveStoredSession()
        {
            var cookie = context.Request.Cookies.Get(Constants.UserKey);
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                cookie.Values.Clear();
                context.Response.SetCookie(cookie);
            }
        }

        public void RemoveLoggedUser()
        {
            context.Session.Remove(Constants.UserKey);
        }

        public static User GetCurrentUser()
        {
            return (HttpContext.Current.Session[Constants.UserKey] as User != null) ? (User)HttpContext.Current.Session[Constants.UserKey] : new User();
        }

        public static void SetCurrentUser(User user)
        {
            HttpContext.Current.Session[Constants.UserKey] = user;
        }
    }
}
