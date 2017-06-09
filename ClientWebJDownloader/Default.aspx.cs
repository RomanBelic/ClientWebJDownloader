using ClientWebJDownloader.ConnectionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebJDownloader
{
    
    public partial class Default : System.Web.UI.Page
    {
        private Dispatcher dispatcher = new Dispatcher(HttpContext.Current);

        protected void Page_Load(object sender, EventArgs e)
        {
            dispatcher.Dispatch();
        }
    }
}