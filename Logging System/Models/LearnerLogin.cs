using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logging_System.Models
{
    public class LearnerLogin 
    {
        public int UserID { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }


        [Required]
        public string Password { get; set; }


        public bool IsActive { get; set; }
       
    }
}