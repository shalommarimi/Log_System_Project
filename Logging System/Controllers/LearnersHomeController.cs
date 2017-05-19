using Learn.BL;
using Logging_System.EFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{   
    public class LearnersHomeController : Controller
    {
        // GET: LearnersHome
      
        [Authorize]
        public ActionResult Learner_Home()
        {
            return View();
        }



        private bool isValidContentType(string contentType)
        {
            return contentType.Equals("application/pdf") || contentType.Equals("application/vnd.openxmlformats-officedocument.wordprocessingml.document") || contentType.Equals("application/msword");
        }

        private bool isValidSizeLength(int contentLength)
        {
            return ((contentLength / 1024) / 1024) < 1; //1MB
        }

        [Authorize]
        [HttpPost]
        public ActionResult Process(HttpPostedFileBase photo)
        {
            try
            {
                if (!isValidContentType(photo.ContentType))
                {
                    ViewBag.Error = "Only Pdf & Docx files are accepted.";
                    return View("Learner_Home");
                }
                else if (!isValidSizeLength(photo.ContentLength))
                {
                    ViewBag.Error = "File Size Limit, Document should be less than 2MB";
                    return View("Learner_Home");
                }
                else
                {
                    if (photo.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(photo.FileName);
                        var path = Path.Combine(Server.MapPath("~/ProofOfAbsence"), fileName);
                        photo.SaveAs(path);
                        ViewBag.fileName = photo.FileName;
                    }
                }
            }
            catch (Exception)
            {


                ViewBag.Error = "Please select a PDF or Word file.";
                return View("Learner_Home");
            }
         
            ViewBag.fileName = photo.FileName;
            ViewBag.fileName = photo.FileName;

          
           // LearnersDetails obj = new LearnersDetails();
            
           MailMessage mail = new MailMessage();
            mail.To.Add("smarimi@jhb.dvt.co.za");
            mail.From = new MailAddress("learnerslogsystem@gmail.com");
            mail.Subject = "File Uploaded";
            string Body = " Notification (Mentor), a learner has just uploaded a file. You may go to http://learnerslogsystem.azurewebsites.net Mentors Portal ---> Download POA to acces it.";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            //smtp.Port = 465;
            //smtp.Port = 2525;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("learnerslogsystem@gmail.com", "Jedia.01");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Success");

        }
        //Downloading

        [Authorize]
        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/ProofOfAbsence/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/ProofOfAbsence/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Learner");
        }


        [HttpPost]
        public ViewResult Learner_Home(Logging_System.Models.Email _objModelMail)
        {
            

            if (ModelState.IsValid)
            {

                string mails = "learnerslogsystem@gmail.com";
                _objModelMail.SentFrom = mails;


                if (_objModelMail.Sendto == "Log System Support")
                {
                    _objModelMail.Sendto = "logsystemsupp@gmail.com";
                }
                else if (_objModelMail.Sendto == "Prudence Mabitsela")
                {
                    _objModelMail.Sendto = "pmabitsela@jhb.dvt.co.za";
                }
                else if (_objModelMail.Sendto == "Mthunzi Huna")
                {
                    _objModelMail.Sendto = "mhuna@jhb.dvt.co.za";
                }
                else if (_objModelMail.Sendto == "Mojalefa Tsao")
                {
                    _objModelMail.Sendto = "mtsao@jhb.dvt.co.za";
                }
                else
                {
                    _objModelMail.Sendto = "logsystemsupp@gmail.com";
                }

                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.Sendto);
                mail.From = new MailAddress(mails);
                mail.Subject = _objModelMail.Subject + " Ticket|Reference: " + _objModelMail.Ticket;
                string Body = _objModelMail.Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //smtp.Port = 465;
                //smtp.Port = 2525;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("learnerslogsystem@gmail.com", "Jedia.01");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                _objModelMail.Error = "Your email has been successfully sent!";
                ViewBag.Message = _objModelMail.Error;
                return View("Learner_Home");
            }
            else
            {
                return View();
            }
        }
    }
}