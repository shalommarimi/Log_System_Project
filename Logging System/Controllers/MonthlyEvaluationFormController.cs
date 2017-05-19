using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logging_System.Models;

namespace Logging_System.Controllers
{
    public class MonthlyEvaluationFormController : Controller
    {
        // GET: MonthlyEvaluationForm
        [Authorize]
        public ActionResult CompleteMonthlyEvaluationForm(Evaluation _evaluate )
        {
            if (ModelState.IsValid)
            {
               Evaluation _eve = new Evaluation();
                string results = _eve.CreateEvaluation(_evaluate);
                ViewData["result"] = results;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please ensure that all required fieds are filled.");
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