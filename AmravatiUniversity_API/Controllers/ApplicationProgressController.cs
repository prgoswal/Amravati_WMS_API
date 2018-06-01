using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models.DL;


namespace AmravatiUniversity_API.Controllers
{
    public class ApplicationProgressController : Controller
    {
        PL_ApplicationProgress plapplicationprogress = new PL_ApplicationProgress();
        DL_ApplicationProgress dlapplicationprogress = new DL_ApplicationProgress();
        [HttpGet]
        public DataSet GetEntryProcess(int Ind, int ApplicationID)
        {
            plapplicationprogress.Ind = Ind;
            plapplicationprogress.ApplicationID =ApplicationID;
            DataSet ds = new DataSet();
            ds = dlapplicationprogress.GetEntryProcess(plapplicationprogress);
            return ds;
        }

    }
}
