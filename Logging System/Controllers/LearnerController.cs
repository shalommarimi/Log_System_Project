using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logging_System.Models;
using Logging_System.EFramework;
using System.Web.Security;
using Learn.BL;

namespace Logging_System.Controllers
{
  
    public class LearnerController : Controller
    {
        //
        // GET: /Learner/
        
        public ActionResult Login()
        {
            return View();

        }

        public ActionResult DoLogin(string txtUsername, string txtPassword)
        {
        //    string message = "Username or Password is incorrect";
            Dal odal = new Dal();
            LearnersDetails learnerlogin = new LearnersDetails();
           
            try
            {
              learnerlogin = (
              from frm in odal.learners.ToList()
              where frm.Username == txtUsername && frm.Password == txtPassword && frm.IsUserActive == true
              select frm).Single();
            }
            catch (Exception)
            {
                ViewBag.Error = "Username or Password is incorrect.";
                return View("Login");
            }


            if (learnerlogin != null)
            {


                Session["Names"] = learnerlogin.Names;
                Session["Username"] = learnerlogin.Username;
                Session["Surname"] = learnerlogin.Surname;
                FormsAuthentication.SetAuthCookie(learnerlogin.Username, false);
                return RedirectToAction("Learner_Home", "LearnersHome");

            }
            else
            {

                return View("Login");
            }

        }
        [Authorize]
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return View("Login");
        }


    }
}