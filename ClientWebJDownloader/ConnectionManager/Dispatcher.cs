using ClientWebJDownloader.Content;
using Common.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebJDownloader.ConnectionManager
{
    public class Dispatcher
    {
        private bool isLoggingPage;

        private HttpContext context;
        public HttpContext Context { get => context; }

        private IdentificationService identificationService;
        public IdentificationService IdentificationService { get => identificationService; }

        public Dispatcher(HttpContext context)
        {
            this.context = context;
            this.identificationService = new IdentificationService(context);
        }
        public Dispatcher(HttpContext context, bool isLoggingPage)
        {
            this.context = context;
            this.identificationService = new IdentificationService(context);
            this.isLoggingPage = isLoggingPage;
        }

        public void Dispatch()
        {
            var user = IdentificationService.GetLoggedUser();
            var isStored = IdentificationService.HasStoredSession();
            if (isStored && user.IsEmpty())
            {
                user = IdentificationService.RestoreUser();
                IdentificationService.SetLoggedUser(user);
            }
            else if (!isStored && !user.IsEmpty())
            {
                IdentificationService.StoreSession(user);
            }
            else if(!isStored && user.IsEmpty() && !isLoggingPage)
            {
                this.Context.Response.RedirectToRoute("Login");
            }
        }

    }
}