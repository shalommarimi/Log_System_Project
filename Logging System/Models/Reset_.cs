using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Logging_System.Models
{
    public class Reset_
    {


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(25)]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }



        [Required(ErrorMessage = "This field is required")]

        [Display(Name = "Retrieval Number")]
        public string RSAID { get; set; }
        //  public string error { get; set; }

        SqlConnection con = new SqlConnection("Server=tcp:logsystemserver.database.windows.net,1433;Initial Catalog=DVTLearnership;Persist Security Info=False;User ID=logsystemserver;Password=shalommarimi.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand cmd = new SqlCommand();

        // My Array 


        public string ResetPasswords(Reset_ _lean)
        {


            // My array of characters
            string[] alphas = new string[52];
            alphas[0] = "a";
            alphas[1] = "b";
            alphas[2] = "c";
            alphas[3] = "d";
            alphas[4] = "e";
            alphas[5] = "f";
            alphas[6] = "g";
            alphas[7] = "h";
            alphas[8] = "i";
            alphas[9] = "j";
            alphas[10] = "k";
            alphas[11] = "l";
            alphas[12] = "m";
            alphas[13] = "n";
            alphas[14] = "o";
            alphas[15] = "p";
            alphas[16] = "q";
            alphas[17] = "r";
            alphas[18] = "s";
            alphas[19] = "t";
            alphas[20] = "u";
            alphas[21] = "v";
            alphas[22] = "w";
            alphas[23] = "x";
            alphas[24] = "y";
            alphas[25] = "z";
            alphas[26] = "A";
            alphas[27] = "B";
            alphas[28] = "C";
            alphas[29] = "D";
            alphas[30] = "E";
            alphas[31] = "F";
            alphas[32] = "G";
            alphas[33] = "H";
            alphas[34] = "I";
            alphas[35] = "J";
            alphas[36] = "K";
            alphas[37] = "L";
            alphas[38] = "M";
            alphas[39] = "N";
            alphas[40] = "O";
            alphas[41] = "P";
            alphas[42] = "Q";
            alphas[43] = "R";
            alphas[44] = "S";
            alphas[45] = "T";
            alphas[46] = "U";
            alphas[47] = "V";
            alphas[48] = "W";
            alphas[49] = "X";
            alphas[50] = "Y";
            alphas[51] = "Z";

            Random r = new Random();
            string randomPassword;
            randomPassword = ((alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)] + r.Next(0, 100) + alphas[r.Next(0, 52)]));


            cmd.CommandText = "UPDATE [MentorsCredentials] SET [Password] = '" + randomPassword + "' WHERE [RSAID] = '" + _lean.RSAID + "' ";



            MailMessage mail = new MailMessage();
            mail.To.Add(_lean.Email);
            mail.From = new MailAddress("learnerslogsystem@gmail.com");
            mail.Subject = ("Password Reset Confirmation");
            string Body = ("Hi Log System User(Mentor) ,                                                                                                    Your Login Password has been reset to " + randomPassword + " .Please NOTE that you are permitted to change your Password to what suits you. For any queries please send an email to mhuna@jhb.dvt.co.za or pmabitsela@jhb.dvt.co.za");
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

                return "Password reset successful";
            }
            catch (Exception es)
            {
                throw es;
            }
        }


    }
}