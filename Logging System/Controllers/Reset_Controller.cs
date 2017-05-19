using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logging_System.Models;
using Logging_System.EFramework;
using Learn.BL;
using Mentors.BL;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class Reset_Controller : Controller
    {
        // GET: Reset_
        public ActionResult Reset_()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Reset_(Reset_ _reset)
        {
            if (ModelState.IsValid)
            {
                Reset_ pass = new Reset_();
                string result = pass.ResetPasswords(_reset);
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

        public ActionResult CheckRSA(string txtUsername, string txtPassword)//Email and R Number
        {
            Dal dals = new Dal();
            MentorsBL changes = new MentorsBL();


            try
            {
                changes = (
                from frm in dals.mentors.ToList()
                where frm.RSAID == txtUsername && frm.Email == txtPassword && frm.IsActive == true
                select frm).Single();

            }
            catch (Exception)
            {
                Reset_ rrr = new Models.Reset_();

                ViewBag.Error = "Learner does not exist. Please verify your Identity Number and Email Address";
                // ViewBag.Err = rrr.error;
                return View("Reset");
            }



            if (changes != null)
            {

                FormsAuthentication.SetAuthCookie(changes.Username, false);
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