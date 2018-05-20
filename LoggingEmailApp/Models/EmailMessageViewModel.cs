using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingEmailApp.Models
{
    public class EmailMessageViewModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}