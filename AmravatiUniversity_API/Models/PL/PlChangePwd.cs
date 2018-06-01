using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmravatiUniversity_API.Models.PL
{
    public class PlChangePwd
    {
        public int Ind { get; set; }
        public string UserLoginId { get; set; }
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
        public int UserId { get; set; }
        public DateTime ChangePwdDate { get; set; }
    }
}