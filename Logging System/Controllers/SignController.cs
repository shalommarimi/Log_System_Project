using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Logging_System.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign
        [Authorize]
        public ActionResult Sign()
        {
            return View();
        }

        public ActionResult Logout()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Mentor");
        }

        [HttpPost]
        public ViewResult Sign(Logging_System.Models._Email _objModelMail)
        {


            if (ModelState.IsValid)
            {
                string mails = "learnerslogsystem@gmail.com";
                _objModelMail.SentFrom = mails;


                if (_objModelMail.Sendto == "Log System Support")
                {
                    _objModelMail.Sendto = "logsystemsupp@gmail.com";
                }
                else if (_objModelMail.Sendto == "Administrator")
                {
                    _objModelMail.Sendto = "logsystemadmn@gmail.com";
                }
                else
                {
                    _objModelMail.Sendto = "logsystemsupp@gmail.com";
                }


                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.Sendto);
                mail.From = new MailAddress(mails);
                mail.Subject = _objModelMail.Subject + " Ticket|Reference: " + _objModelMail.Ticket ;
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
                _objModelMail.Error= "Your email has been successfully sent!";
                ViewBag.Message = _objModelMail.Error;
                return View("Sign");
            }
            else
            {
                return View();
            }
        }
    }
}