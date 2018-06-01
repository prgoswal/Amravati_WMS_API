using AmravatiUniversity_API.Models.DL;
using AmravatiUniversity_API.Models.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmravatiUniversity_API.Controllers
{
    public class ZeroController : ApiController
    {
        DL_SecondLevel objDlSecondlevel = new DL_SecondLevel();
        PL_SecondLevel objPlSecondlevel = new PL_SecondLevel();

        [HttpGet]
        public DataTable GetLevelRemark(int Ind, int ApplicationId)
        {
            objPlSecondlevel.Ind = Ind;
            objPlSecondlevel.ApplicationID = ApplicationId;
            objPlSecondlevel.dt = objDlSecondlevel.GetLevelRemark(objPlSecondlevel);
            return objPlSecondlevel.dt;
        }
       
    }
}
