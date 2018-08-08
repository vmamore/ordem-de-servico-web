using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tecdisa.OS.Site.UI.Controllers
{
    public class BaseController : Controller
    {
        public string UserId
        {
            get
            {
                return ControllerContext.HttpContext.Request.IsAuthenticated ? ControllerContext.HttpContext.User.Identity.GetUserId() : "Anônimo";
            }
        }

        protected const int PageSize = 5;

    }
}