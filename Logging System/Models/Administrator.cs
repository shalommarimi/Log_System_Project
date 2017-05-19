using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logging_System.Models
{
    public class Administrator
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
      







    }
}