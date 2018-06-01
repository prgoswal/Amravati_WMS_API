using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models.DL;

namespace AmravatiUniversity_API.Controllers
{
    public class SecondLevelController : ApiController
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
        //   For Pending and complete Detail for zero level (Office Assistent)
        [HttpGet]
        public DataSet GetAppDetailZeroLevel(int ind, string UserID)
        {
            objPlSecondlevel.Ind = ind;
            objPlSecondlevel.UserID = UserID;
            objPlSecondlevel.ds = objDlSecondlevel.GetAppDetailZeroLevel(objPlSecondlevel);
            return objPlSecondlevel.ds;
        }
        //   For pending and Complete Detail for level 1 to 7 (greater than zero level)
        [HttpGet]
        public DataSet GetappDetail(int ind, int levelid)
        {
            objPlSecondlevel.Ind = ind;
            objPlSecondlevel.levelid = levelid;
            objPlSecondlevel.ds = objDlSecondlevel.GetAppDetail(objPlSecondlevel);
            return objPlSecondlevel.ds;
        }

        [HttpGet]
        public DataTable GetRecordId(int ind, int applicationid)
        {
            objPlSecondlevel.Ind = ind;
            objPlSecondlevel.ApplicationID = applicationid;
            objPlSecondlevel.dt = objDlSecondlevel.GetRecordId(objPlSecondlevel);

            return objPlSecondlevel.dt;
        }

        [HttpGet]
        public DataTable GetApprovalCount(int ind, int applicationid, int isconfirm, int doctype)
        {

            objPlSecondlevel.Ind = 4;
            objPlSecondlevel.ApplicationID = applicationid;
            objPlSecondlevel.isconfirmed = 1;
            objPlSecondlevel.DocType = doctype;

            objPlSecondlevel.dt = objDlSecondlevel.GetApprovalCount(objPlSecondlevel);

            return objPlSecondlevel.dt;
        }

        [HttpPost]
        public DataTable PostSubmitPopDetail(Pl_SubmitZeroLevel pl)
        {
            if (pl != null)
            {

                objPlSecondlevel.dt = objDlSecondlevel.SubmitPopDetail(pl);
            }
            objPlSecondlevel.dt.TableName = "MyTable";
            return objPlSecondlevel.dt;
        }

        [HttpPost]
        public DataTable PostRejectionRecord(Pl_SubmitZeroLevel pl)
        {
            DataTable dt = new DataTable();
            objPlSecondlevel.dt = objDlSecondlevel.SubmitRejection(pl);
            return objPlSecondlevel.dt;
        }
        [HttpPost]
        public DataTable PostCorrectionRecord(PL_SecondLevel objplSecondLevel)
        {

            objPlSecondlevel.dt = objDlSecondlevel.SubmitCorrection(objplSecondLevel);
            return objPlSecondlevel.dt;
        }
        [HttpPost]
        public DataTable PostApprovalRecord(Pl_SubmitZeroLevel objplSecondLevel)
        {

            objPlSecondlevel.dt = objDlSecondlevel.SubmitApproval(objplSecondLevel);
            return objPlSecondlevel.dt;
        }

        [HttpPost]
        public DataTable ShowExamDetail(int Ind, string Rollno, string ExamYear, int OccCtrl, string ExamSession)
        {
            PL_SecondLevel pl = new PL_SecondLevel();
            pl.Ind = Ind;
            pl.Rollno = Rollno;
            pl.ExamYear = ExamYear;
            pl.OccCtrl = OccCtrl;
            pl.ExamSession = ExamSession;
            return objDlSecondlevel.ShowExamDetail(pl);
        }

        // POST api/secondlevel
        public void Post([FromBody]string value)
        {
        }

        // PUT api/secondlevel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/secondlevel/5
        public void Delete(int id)
        {

        }

        //For Cancel Application
        [HttpPost]
        public DataTable PostCancelPopDetail(Pl_SubmitZeroLevel pl)
        {
            if (pl != null)
            {
                objPlSecondlevel.dt = objDlSecondlevel.CancelPopDetail(pl);
            }
            objPlSecondlevel.dt.TableName = "MyTable";
            return objPlSecondlevel.dt;
        }

        //For Cancel Application List
        [HttpPost]
        public DataTable CancelApplicationList(Pl_SubmitZeroLevel pl)
        {
            if (pl != null)
            {
                objPlSecondlevel.dt = objDlSecondlevel.CancelApplicationList(pl);
            }
            objPlSecondlevel.dt.TableName = "MyTable";
            return objPlSecondlevel.dt;
        }
    }
}
