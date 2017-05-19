using Logging_System.EFramework;
using Logging_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.Data;
using Learn.BL;
using System.Net.Mail;
using System.IO;
using System.IO.Compression;
using Mentors.BL;


namespace Logging_System.Controllers
{

    public class MentorController : Controller
    {
        // GET: Mentor

        public ActionResult Login()
        {
            return View();
        }


        [Authorize]
        public ActionResult Register()
        {

           return View();
        }

        [HttpPost]
        public ActionResult ProcessForm(List<string> selectedfiles)
        {
            if (System.IO.File.Exists(Server.MapPath
                              ("~/ZippedWeeklyLogbooks/WeeklyLogbooks.zip")))
            {
                System.IO.File.Delete(Server.MapPath
                              ("~/ZippedWeeklyLogbooks/WeeklyLogbooks.zip"));
            }
            ZipArchive zip = ZipFile.Open(Server.MapPath
                     ("~/ZippedWeeklyLogbooks/WeeklyLogbooks.zip"), ZipArchiveMode.Create);
            foreach (string file in selectedfiles)
            {
                zip.CreateEntryFromFile(Server.MapPath
                     ("~/WeeklyLogbooks/" + file), file);
            }
            zip.Dispose();
            return File(Server.MapPath("~/ZippedWeeklyLogbooks/WeeklyLogbooks.zip"),
                      "application/zip", "WeeklyLogbooks.zip");
        }
        [HttpPost]
        public ActionResult ProcessEvaluation(List<string> selectedfiles)
        {
            if (System.IO.File.Exists(Server.MapPath("~/ZippedMonthlyEvaluationForms/MonthlyEvaluationForms.zip")))

            {
                System.IO.File.Delete(Server.MapPath("~/ZippedMonthlyEvaluationForms/MonthlyEvaluationForms.zip"));

            }
            ZipArchive zip = ZipFile.Open(Server.MapPath("~/ZippedMonthlyEvaluationForms/MonthlyEvaluationForms.zip"), ZipArchiveMode.Create);

            foreach (string file in selectedfiles)
            {
                zip.CreateEntryFromFile(Server.MapPath("~/Monthly Evaluation Forms/" + file), file);

            }
            zip.Dispose();
            return File(Server.MapPath("~/ZippedMonthlyEvaluationForms/MonthlyEvaluationForms.zip"),
                      "application/zip", "MonthlyEvaluationForms.zip");
        }
        //public FileResult Downloads(string ImageName)
        //{
        //    var FileVirtualPath = "~/WeeklyLogbooks/" + ImageName;
        //    return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        //}
        [Authorize]
        public ActionResult Download()
        {

            //var dir = new System.IO.DirectoryInfo(Server.MapPath("~/WeeklyLogbooks/"));
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            //foreach (var file in fileNames)
            //{
            //    items.Add(file.Name);
            //}
            //return View(items);


            string[] files = Directory.GetFiles(
                 Server.MapPath("~/WeeklyLogbooks"));
            List<string> downloads = new List<string>();
            foreach (string file in files)
            {
                downloads.Add(Path.GetFileName(file));
            }
            return View(downloads);
        }


       
        //public FileResult Downloadings(string Monthly)
        //{
        //    var FileVirtualPath = "~/Monthly Evaluation Forms/" + Monthly;
        //    return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        //}



        [Authorize]
        public ActionResult DownloadMEF()
        {


            //var dir = new System.IO.DirectoryInfo(Server.MapPath("~//Monthly Evaluation Forms/"));
            ////System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*"); List<string> items = new List<string>();
            //foreach (var file in fileNames)
            //{
            //    items.Add(file.Name);
            //}
            //return View(items);




            //string evaluationpath = "~/Monthly Evaluation Forms";

            //string[] files = Directory.GetFiles(Server.MapPath(evaluationpath));

            //List<string> downloads = new List<string>();
            //foreach (string file in files)
            //{
            //    downloads.Add(Path.GetFileName(file));
            //}
            //return View(downloads);

           

            string path = Server.MapPath(@"~/Monthly Evaluation Forms");
            List<string> picFolders = new List<string>();

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.GetFiles("*.*").Length > 0)
                picFolders.Add(dirInfo.Name);

            foreach (var dir in dirInfo.GetDirectories())
            {
                if (dir.GetFiles("*", SearchOption.AllDirectories).Length > 0)
                    picFolders.Add(dir.Name);
            }

            return View(picFolders);
          





        }


        [Authorize]
        [HttpPost]
        public ActionResult Register(Learners _learners)
        {
            if (ModelState.IsValid)
            {
                Learners _lear = new Learners();
                string result = _lear.InsertRegDetails(_learners);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError(string .Empty,"Could Not Register Learner");
                return View();
            }
           
        }


      
        public ActionResult DoLogin(string txtUsername, string txtPassword)
        {
            Dal dal = new Dal();
            MentorsBL mentorlogin = new MentorsBL();
            ViewBag.Error = "Username or Password is incorret";

            try
            {
              mentorlogin = (
              from frm in dal.mentors.ToList()
              where frm.Username == txtUsername && frm.Password == txtPassword && frm.IsActive == true
              select frm).Single();
            }
            catch (Exception)
            {

                ViewBag.Error = "Username or Password is incorrect.";
                return View("Login");
            }

          

            if (mentorlogin != null)
            {
                Session["FirstName"] = mentorlogin.FirstName.ToString();
                Session["Surname"] = mentorlogin.Surname.ToString();
                //Session["Role"] = mentorlogin.Role.ToString();

                FormsAuthentication.SetAuthCookie(mentorlogin.Username, false);
                return RedirectToAction("Sign", "Sign");

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