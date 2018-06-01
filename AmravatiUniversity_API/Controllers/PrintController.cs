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
    public class PrintController : ApiController
    {
        DL_Print objDlPrint = new DL_Print();
        PL_Print objPlPrint = new PL_Print();

        [HttpGet]
        public DataTable GetAllPrintCount(int Ind, int UserID, int UserTypeID)
        {
            objPlPrint.Ind = Ind;
            objPlPrint.UserID = UserID;
            objPlPrint.LevelID = UserTypeID;
            DataTable dt = new DataTable();
            dt = objDlPrint.GetAllPrintCount(objPlPrint);
            return dt;
        }
        [HttpGet]
        public DataTable TestPrintDetail(int Ind, int UserID, int LevelID, int DocTypeId)
        {
            objPlPrint.Ind = Ind;
            objPlPrint.UserID = UserID;
            objPlPrint.LevelID = LevelID;
            objPlPrint.DocTypeId = DocTypeId;

            DataTable dt = new DataTable();
            dt = objDlPrint.TestPrintDetail(objPlPrint);
            return dt;
        }

        [HttpGet]
        public DataTable PrintCertificate(int Ind, int ApplicationID, int DocTypeId)
        {
            objPlPrint.Ind = Ind;
            objPlPrint.ApplicationID = ApplicationID;
            objPlPrint.DocTypeId = DocTypeId;

            DataTable dt = new DataTable();
            dt = objDlPrint.PrintCertificate(objPlPrint);
            return dt;
        }

        [HttpGet]
        public DataTable PrintFinalCertificate(int Ind, int ApplicationID, int DocTypeId)
        {
            objPlPrint.Ind = Ind;
            objPlPrint.ApplicationID = ApplicationID;
            objPlPrint.DocTypeId = DocTypeId;

            DataTable dt = new DataTable();
            dt = objDlPrint.PrintFinalCertificate(objPlPrint);
            return dt;
        }
    }
}
