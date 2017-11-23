using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Mail
    {
        public int MailId { get; set; }
        public string User_mail { get; set; }
        public string User_pass { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }
    }
}
