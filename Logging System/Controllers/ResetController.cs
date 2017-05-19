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
    public class ResetController : Controller
    {
        // GET: Reset
        public ActionResult Reset()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Reset(Reset _reset)
        {
            if (ModelState.IsValid)
            {
                Reset pass = new Reset();
                string result = pass.ResetPassword(_reset);
                ViewData["result"] = result;
                ViewBag.Err = "Password reset succesful. You will receive an email with your new Password. Go to 'Login Page'";
                ModelState.Clear();
               
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could not reset password");
                return View();
            }

        }

        public ActionResult CheckRSAID(string txtUsername, string txtPassword)//Email and R Number
        {
            Dal dal = new Dal();
            LearnersDetails change = new LearnersDetails();
         

            try
            {
                change = (
                from frm in dal.learners.ToList()
                where frm.RSAID == txtUsername && frm.Email == txtPassword && frm.IsUserActive == true
                select frm).Single();
              
            }
            catch (Exception)
            {
                Reset rrr = new Models.Reset();

                ViewBag.Error = "Learner does not exist. Please verify your Identity Number and Email Address";
               // ViewBag.Err = rrr.error;
                return View("Reset");
            }



            if (change != null)
            {

                FormsAuthentication.SetAuthCookie(change.Username, false);
                return RedirectToAction("Reset", "Reset");
             

            }
            else
            {
                //return View("Reset");
                return RedirectToAction("Administrator", "Login");
            }

        }
    }
}