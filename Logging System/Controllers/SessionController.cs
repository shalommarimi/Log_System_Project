using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
      
        public ActionResult SessionExpired()
        {

            FormsAuthentication.SignOut();
            return View("SessionExpired");
        }
    }
}