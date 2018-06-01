using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmravatiUniversity_API.Models.PL
{
    public class PL_Print
    {
        public int Ind { get; set; }
        public int DocID { get; set; }
        public string DocType { get; set; }
        public int Cnt { get; set; }
        public int DocTypeId { get; set; }
        public int LevelID { get; set; }
        public int UserID { get; set; }
        public int ApplicationID { get; set; }
    }
}