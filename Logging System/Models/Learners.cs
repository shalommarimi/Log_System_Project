using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Logging_System.Models
{
    public class Learners
    {

        public int LearnerID { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Names cannot contain numeric values")]
        public string Names { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Surname cannot contain numeric values")]
        public string Surname { get; set; }

        [Required]

        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        //[Required]
        [Display(Name = "Retrieval Code")]
        public string RSAID { get; set; }

        [Required]

        public string Learnership { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]



        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required]
        [EmailAddress]

        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "The Email and Username do not match.")]
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


        [Required]
        public bool IsUserActive { get; set; }



        SqlConnection con = new SqlConnection("Server=tcp:logsystemserver.database.windows.net,1433;Initial Catalog=DVTLearnership;Persist Security Info=False;User ID=logsystemserver;Password=shalommarimi.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        SqlCommand cmd = new SqlCommand();



        public string InsertRegDetails(Learners _lean)
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

            //RSAID

            Random rr = new Random();

            string randomRN;

            randomRN = ((alphas[rr.Next(0, 52)] + rr.Next(0, 111) + alphas[rr.Next(0, 52)] + rr.Next(0, 300) + alphas[rr.Next(0, 52)] + rr.Next(0, 200) + alphas[rr.Next(0, 52)]));

            _lean.LearnerID = r.Next(123, 2144);

            _lean.RSAID = randomRN;
            cmd.CommandText = "Insert into [Learners_Information] values('" + _lean.LearnerID
                + "','" + _lean.Names
                + "','" + _lean.Surname
                + "','" + _lean.Gender
                + "','" + _lean.DOB
                + "','" + _lean.RSAID
                + "','" + _lean.Learnership
                + "','" + _lean.Mobile
                + "','" + _lean.Email
                + "','" + _lean.Username
                + "','" + randomPassword
                + "','" + _lean.IsUserActive + "')";
            
            MailMessage mail = new MailMessage();

            mail.To.Add(_lean.Email);
            mail.From = new MailAddress("learnerslogsystem@gmail.com");
            mail.Subject = ("Learner's Login Details");
            string Body = ("Hi " + _lean.Names + " " + _lean.Surname + " ,                                                                                                   this is to confirm that you have been registered on the Learners Log System. Your login details for the Log System are " + "Username: " + _lean.Username + "  Password: " + randomPassword + " Keep the following Confidential Password Retrieval Code to reset your password " + randomRN + " .Please NOTE that you are permitted change your Password. For any queries please send an email to  logsystemsupp@gmail.com. Login to http://learnerslogsystem.azurewebsites.net/Learner/Login");
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
                return "Successfully Registered " + _lean.Names + " " + _lean.Surname;
            }
            catch (Exception es)
            {
                throw es;
            }
        }

    }
}


