using Logging_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class LogbookController : Controller
    {
        // GET: Logbook
        [Authorize]
        public ActionResult SignLogBook(Logbook logbooks)
        {
            if (ModelState.IsValid)
            {
                Logbook log = new Logbook();
                string results = log.CreateLogbook(logbooks);
                ViewData["result"] = results;
                ModelState.Clear();
                return View();
            }
            else
            {
                DateTime Monday = DateTime.Now;
                while (Monday.DayOfWeek != DayOfWeek.Monday) Monday = Monday.AddDays(-1);
                string Mondays = Monday.ToString("dd-MMMM-yyyy");
                ViewBag.Mondays = Mondays;


                DateTime Tuesday = DateTime.Now;
                while (Tuesday.DayOfWeek != DayOfWeek.Tuesday) Tuesday = Tuesday.AddDays(-1);
                string Tuesdays = Tuesday.ToString("dd-MMMM-yyyy");
                ViewBag.Tuesdays = Tuesdays;


                DateTime Wednesday = DateTime.Now;
                while (Wednesday.DayOfWeek != DayOfWeek.Wednesday) Wednesday = Wednesday.AddDays(-1);
                string Wednesdays = Wednesday.ToString("dd-MMMM-yyyy");
                ViewBag.Wednesdays = Wednesdays;

                DateTime Thursday = DateTime.Now;
                while (Thursday.DayOfWeek != DayOfWeek.Thursday) Thursday = Thursday.AddDays(-1);
                string Thursdays = Thursday.ToString("dd-MMMM-yyyy");
                ViewBag.Thursdays = Thursdays;

                DateTime Friday = DateTime.Now;
                while (Friday.DayOfWeek != DayOfWeek.Friday) Friday = Friday.AddDays(1);
                string Fridays = Friday.ToString("dd-MMMM-yyyy");
                ViewBag.Fridays = Fridays;


                ModelState.AddModelError(string.Empty, "Please ensure that all required fieds are filled. \r\n \r\n Note that Date Generator can be inaccurate, ensure that correct dates are entered");
                return View();
            }
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Learner");
        }

    }
}