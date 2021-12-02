using ElectronicNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ElectronicNotebook.Controllers
{
    public class CustomAuthAtribute: AuthorizeAttribute
    {
        private ElectronicNotebookDatabaseEntities db = new ElectronicNotebookDatabaseEntities();
        private readonly string[] allowedroles;
        public CustomAuthAtribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session["id"]);
            if (!string.IsNullOrEmpty(userId))
            {
                int id = Convert.ToInt32(userId);
                Secretary secretary = db.Secretaries.Find(id);
                if (secretary != null)
                    return true;
            }
                    return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                        { "controller", "Login" },
                     { "action", "Create" }
               });
        }
    }
}
