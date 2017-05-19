using Learn.BL;
using Logging_System.EFramework;
using Logging_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        public ActionResult EnterNewPassword()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult EnterNewPassword(NewPassword _pass)
        {
            if (ModelState.IsValid)
            {
                NewPassword pass = new NewPassword();
                string result = pass.Update(_pass);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string .Empty,"Could not update password");
                return View();
            }
           
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Learner");
        }


        public ActionResult CheckCheck(string txtUsername, string txtPassword)
        {
            Dal dal = new Dal();
            LearnersDetails change = new LearnersDetails();
            ViewBag.Error = "Username does not exist. Please verify your Username or Password";

            try
            {
              change = (
              from frm in dal.learners.ToList()
              where frm.Username == txtUsername && frm.Password == txtPassword && frm.IsUserActive == true
              select frm).Single();
            }
            catch (Exception)
            {

                ViewBag.Error = "Username does not exist. Please verify your Username or Password";
                return View("ChangePassword");
            }

          

            if (change != null)
            {
              
                FormsAuthentication.SetAuthCookie(change.Username, false);
                return RedirectToAction("EnterNewPassword", "ChangePassword");

            }
            else
            {
                return View("ChangePassword");
            }

        }

    }
}