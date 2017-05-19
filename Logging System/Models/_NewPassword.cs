using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Logging_System.Models
{
    public class _NewPassword
    {

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string New_Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("New_Password", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress]
        public string Username { get; set; }




        SqlConnection con = new SqlConnection("Server=tcp:logsystemserver.database.windows.net,1433;Initial Catalog=DVTLearnership;Persist Security Info=False;User ID=logsystemserver;Password=shalommarimi.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand cmd = new SqlCommand();



        public string Update(_NewPassword _lean)
        {
            cmd.CommandText = "UPDATE [MentorsCredentials] SET [Password] = '" + _lean.New_Password + "' WHERE [Username] = '" + _lean.Username + "' ";

            MailMessage mail = new MailMessage();
            mail.To.Add(_lean.Username);
            mail.From = new MailAddress("learnerslogsystem@gmail.com");
            mail.Subject = ("Password Change Confirmation");
            string Body = ("Hi Log System User ,                                                                                                    Your Login Password has been changed to " + _lean.New_Password + " If you did not request a password change please contact your Log System administrator or send an email to mhuna@jhb.dvt.co.za or  pmabitsela@jhb.dvt.co.za for any queries");
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("learnerslogsystem@gmail.com", "Jedia.01");
            smtp.EnableSsl = true;
            smtp.Send(mail);


            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return "Successfully Registered ";

            }
            catch (Exception es)
            {
                throw es;
            }
        }


    }
}