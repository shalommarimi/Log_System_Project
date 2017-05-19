using Learn.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class RegisteredLearnersController : Controller
    {
        LearnersBusinessLogic LearnersBL = new LearnersBusinessLogic();
        // GET: RegisteredLearners
        [Authorize]
        public ActionResult RegLearners()
        {
            return View();
        }
        public JsonResult SelectLearners()
        {
            return Json(LearnersBL.Learner.ToList(), JsonRequestBehavior.AllowGet);
        }
        public string InsertLearner(LearnersDetails LearnersDe)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (LearnersBL.InsertLearner(LearnersDe) > 0)
                {
                    msg = "Sucessfully Inserted Learner's Record";
                }
                else
                {
                    msg = "Error! Could Not Insert Learner's Record";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }
            return msg;

        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Mentor");
        }

        public string UpdateLearner(LearnersDetails LearnersDe)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (LearnersBL.UpdateLearner(LearnersDe) > 0)
                {
                    msg = "Sucessfully Updated Learner's Details";
                }
                else
                {
                    msg = "Error! System Could Not Update Learner's Details";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }
            return msg;

        }



        public string DeleteLearner(int ID)
        {
            string msg;

            if (LearnersBL.DeleteLearner(ID) > 0)
            {
                msg = "Sucessfully Deleted Learner's Record";
            }
            else
            {
                msg = "Error! Could Not Delete Learner's Record";
            }

            return msg;

        }
    }
}