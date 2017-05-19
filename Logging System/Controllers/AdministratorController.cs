using Logging_System.EFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logging_System.Models;

namespace Logging_System.Content
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        public ActionResult Home()
        {
            return View();
        }
       

        [Authorize]
        [HttpPost]
        public ActionResult Home(Register _learners)
        {

            if (ModelState.IsValid)
            {
                Register _lear = new Register();
                string result = _lear.InsertRegDetails(_learners);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Could Not Register Mentor");
                return View();
            }
        }

        public ActionResult DoLogin(string txtUsername, string txtPassword)
        {
            Dal dal = new Dal();
            Administrator adminlogin = new Administrator();
            ViewBag.Error = "Administrator Username or Password is incorret.";

            try
            {
                adminlogin = (
                from frm in dal.admin.ToList()
                where frm.Username == txtUsername && frm.Password == txtPassword
                select frm).Single();
            }
            catch (Exception)
            {

                ViewBag.Error = "Username or Password is incorret.";
                return View("Login");
            }



            if (adminlogin != null)
            {
                Session["FirstName"] = adminlogin.FirstName.ToString();
                Session["Surname"] = adminlogin.LastName.ToString();
                //Session["Surname"] = adminlogin.Role.ToString();





                FormsAuthentication.SetAuthCookie(adminlogin.Username, false);
                return RedirectToAction("Home","Administrator");

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