using Logging_System.EFramework;
using Mentors.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logging_System.Models;
namespace Logging_System.Controllers
{
    public class _ChangePasswordController : Controller
    {
        // GET: _ChangePassword


        // GET: ChangePassword
        [Authorize]
        public ActionResult _ChangePassword()
        {
            return View();
        }
        [Authorize]
        public ActionResult _EnterNewPassword()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult _EnterNewPassword(_NewPassword _pass)
        {
            if (ModelState.IsValid)
            {
                _NewPassword pass = new _NewPassword();
                string result = pass.Update(_pass);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could not update password");
                return View();
            }

        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Mentor");
        }


        public ActionResult CheckChecks(string txtUsername, string txtPassword)
        {
            Dal dal = new Dal();
            MentorsBL change = new MentorsBL();
            ViewBag.Error = "Username does not exist. Please verify your Username or Password";

            try
            {
                change = (
                from frm in dal.mentors.ToList()
                where frm.Username == txtUsername && frm.Password == txtPassword && frm.IsActive == true
                select frm).Single();
            }
            catch (Exception)
            {

                ViewBag.Error = "Username does not exist. Please verify your Username or Password";
                return View("_ChangePassword");
            }



            if (change != null)
            {

                FormsAuthentication.SetAuthCookie(change.Username, false);
                return RedirectToAction("_EnterNewPassword", "_ChangePassword");

            }
            else
            {
                return View("_ChangePassword");
            }

        }

    }
}