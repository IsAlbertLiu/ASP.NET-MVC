using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBorad.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string 姓名 { get; set; }
        public string 内容 { get; set; }
        public string Email { get; set; }
    }
}