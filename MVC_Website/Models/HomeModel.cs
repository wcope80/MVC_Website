using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Website.Models
{
    public class HomeModel
    {
        
    }

    public class Message
    {
        public int MessageID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }

}