using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Logging_System.Models
{
    public class _Password
    {


        [Required]
        [EmailAddress]
        public string Username { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool IsUserActive { get; set; }
       





        SqlConnection con = new SqlConnection("Server=tcp:logsystemserver.database.windows.net,1433;Initial Catalog=DVTLearnership;Persist Security Info=False;User ID=logsystemserver;Password=shalommarimi.01;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlCommand cmd = new SqlCommand();



        public string Update(_Password _lean)
        {
            cmd.CommandText = "Insert into [MentorsCredentials] values('" + _lean.NewPassword + "')";


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