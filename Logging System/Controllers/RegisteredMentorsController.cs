using Mentors.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logging_System.Controllers
{
    public class RegisteredMentorsController : Controller
    {
        MentorsBusinessLogic MentorsBL = new MentorsBusinessLogic();
        // GET: RegisteredMentors
        [Authorize]
        public ActionResult RegisteredMentors()
        {
            return View();
        }
        public JsonResult SelectMentors()
        {
            return Json(MentorsBL.Mentor.ToList(), JsonRequestBehavior.AllowGet);
        }
        public string InsertMentor(MentorsBL MentorDe)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (MentorsBL.InsertMentor(MentorDe) > 0)
                {
                    msg = "Sucessfully Inserted Mentor's Record";
                }
                else
                {
                    msg = "Error! Could Not Insert Mentor's Record";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }
            return msg;

        }
        public string UpdateMentor(MentorsBL MentorDe)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (MentorsBL.UpdateMentor(MentorDe) > 0)
                {
                    msg = "Sucessfully Updated Mentor's Details";
                }
                else
                {
                    msg = "Error! System Could Not Update  Mentor's Details";
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

            if (MentorsBL.DeleteMentor(ID) > 0)
            {
                msg = "Sucessfully Deleted Mentor's Record";
            }
            else
            {
                msg = "Error! Could Not Delete  Mentor's Record";
            }

            return msg;

        }
    }
}