using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logging_System.Models
{
    public class Email
    {
        [Required(ErrorMessage = "To field is required")]
        [Display (Name = "Recipient")]
        public string Sendto { get; set; }

        //[Required(ErrorMessage = "From field is required")]
        [Display(Name = "Sender")]
        public string SentFrom { get; set; }

        [Required(ErrorMessage = "Subject field is required")]
        [Display(Name = "Reason")]

        public string Subject { get; set; }

        [Required(ErrorMessage = "Message field is required")]
        [Display(Name = "Message | Content")]
        public string Message { get; set; }

        public string Error { get; set; }
        [Display(Name = "Ticket | Reference")]
        public int Ticket { get; set; }



    }

}